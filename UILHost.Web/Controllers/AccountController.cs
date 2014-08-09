using System.Web.Mvc;
using UILHost.Infrastructure.Domain;
using UILHost.Infrastructure.Services.Interface;
using UILHost.Patterns.Repository.UnitOfWork;
using UILHost.Web.Models;
using UILHost.Web.Services;

namespace UILHost.Web.Controllers
{

    public partial class AccountController : BaseController
    {
        private readonly IUnitOfWorkAsync _uow;
        private readonly ITeacherService _teacherSvc;
        private readonly IAuthenticationService _authSvc;

        public AccountController(
            IUnitOfWorkAsync uow, ITeacherService teacherSvc, IAuthenticationService authSvc)
        {
            _uow = uow;
            _teacherSvc = teacherSvc;
            _authSvc = authSvc;
        }

        #region Login/Logoff

        [AllowAnonymous]
        public virtual ActionResult Login(string returnUrl)
        {
            //var m = Infrastructure.IoC.DependencyResolver.GetDependency<IRepositoryAsync<UserProfileMachine>>().Read("5ce123fe-e806-439d-93bc-8db340094105");
            //_teacherSvc.Update(m.Profile);

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public virtual ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);


            // READ PROFILE ---

            var profile = _teacherSvc.Read(model.UserName);


            // AUTHENTICATE PROFILE ---

            if (profile != null && profile.VerifyPassword(model.Password))
                return SignIn(profile, model.RememberMe, returnUrl);


            ModelState.AddModelError("", "Invalid username or password.");

            return View(model);
        }

        private ActionResult SignIn(Teacher profile, bool rememberMe, string returnUrl)
        {
            _authSvc.SignIn(profile, rememberMe);

            _teacherSvc.Update(profile);

            _uow.SaveChanges();

            return RedirectToLocal(returnUrl);
        }

        public virtual ActionResult LogOff()
        {
            _authSvc.SignOut();
            return RedirectToAction(MVC.Account.Login());
        }

        #endregion

    //    #region Login Account Verification

    //    [AllowAnonymous]
    //    public virtual ActionResult LoginAccountVerification(string returnUrl)
    //    {
    //        // HANDLE IF LINK WITH NO REQUEST

    //        if (this._sessionFacade.LoginSecurityQuestionVerificationRequest == null)
    //            return HttpNotFound();

    //        // READ USER PROFILE

    //        var profile = _teacherSvc.Read(this._sessionFacade.LoginSecurityQuestionVerificationRequest.UserProfileId);
    //        var model = LoginCreateAccountVerificationViewModel(profile.UserProfileSecurityQuestions);

    //        ViewBag.ReturnUrl = returnUrl;

    //        return View(model);
    //    }

    //    [AllowAnonymous]
    //    [HttpPost]
    //    public virtual ActionResult LoginAccountVerification(AccountVerificationViewModel model, string returnUrl)
    //    {
    //        // read the profile and get currect security question

    //        var userProfile = _teacherSvc.Read(this._sessionFacade.LoginSecurityQuestionVerificationRequest.UserProfileId);
    //        var securityQuestion = _userProfileSecurityQuestionSvc.Find(
    //            userProfile.UserProfileSecurityQuestions.Find(a => a.SecurityQuestion.Question == model.Question).Id);

    //        //Verify not blocked

    //        if (userProfile.Flags.HasFlag(UserProfileFlags.BadLoginAttemptLockedOut))
    //        {
    //            CreateLoginAudit(LoginAuditType.AccountBlocked, userProfile.Username, userProfile);
    //            _uow.SaveChanges();

    //            AddNotification(NextRequestNotificationType.Error, "Your account has been locked. Please contact your account administrator.");

    //            return RedirectToAction(MVC.Account.Login());
    //        }

    //        // validate security question answer

    //        if ((securityQuestion.DataMigrationFlags.HasFlag(SecurityQuestionDataMigrationFlags.MigrateAnswer)
    //            && _dataMigrationSvc.MigrateUserSecurityQuestionAnswer(securityQuestion, model.Answer))
    //            || !securityQuestion.VerifyAnswer(model.Answer))
    //        {

    //            //  add error to model state

    //            ModelState.AddModelError("", "Your answer does not match our records.");

    //            //add bad login audit

    //            CreateLoginAudit(LoginAuditType.FailedLogin, userProfile.Username, userProfile);
    //            userProfile.LogBadPasswordAttempt();
    //            _teacherSvc.Update(userProfile);

    //            //update security question

    //            securityQuestion.LastTimeAsked = DateTime.Now;
    //            _userProfileSecurityQuestionSvc.Update(securityQuestion);
    //            _uow.SaveChanges();

    //            if (userProfile.Flags.HasFlag(UserProfileFlags.BadLoginAttemptLockedOut))
    //            {
    //                AddNotification(NextRequestNotificationType.Error, "Your account has been locked. Please contact your account administrator.");
    //                return RedirectToAction(MVC.Account.Login());
    //            }

    //            //update view state

    //            ViewBag.ReturnUrl = returnUrl;
    //            ViewData = null;

    //            var newModel = LoginCreateAccountVerificationViewModel(userProfile.UserProfileSecurityQuestions);

    //            return View(newModel);
    //        }

    //        // success

    //        var machineId = Request.GetMachineId();
    //        if (_sessionFacade.LoginSecurityQuestionVerificationRequest.Reason ==
    //            LoginSecurityQuestionVerificationRequestReason.UnverfiedMachine)
    //        {
    //            machineId = Response.CreateNewMachineCookie();
    //            _userProfileMachineSvc.Insert(new UserProfileMachine(userProfile, machineId));
    //        }

    //        return SignIn(
    //            userProfile,
    //            _sessionFacade.LoginSecurityQuestionVerificationRequest.RememberMe,
    //            returnUrl,
    //            machineId);
    //    }

    //    #endregion

    //    #region ForgotPassword

    //    [AllowAnonymous]
    //    public virtual ActionResult ForgotPasswordRequest()
    //    {
    //        ExternalLoginConfirmationViewModel model = new ExternalLoginConfirmationViewModel();
    //        return View(model);
    //    }

    //    [AllowAnonymous]
    //    [HttpPost]
    //    public virtual ActionResult ForgotPasswordRequest(ExternalLoginConfirmationViewModel model)
    //    {
    //        if (!ModelState.IsValid)
    //            return View(model);

    //        //check username in system

    //        var userProfile = _teacherSvc.ReadByUsername(model.UserName);

    //        if (userProfile == null)
    //            return View(MVC.Account.Views.ForgotPasswordRecoveryRequestSuccess);

    //        // Add 6 hours to current time

    //        _teacherSvc.InitiateForgotPasswordProcess(userProfile);

    //        _uow.SaveChanges();

    //        return View(MVC.Account.Views.ForgotPasswordRecoveryRequestSuccess);
    //    }

    //    [AllowAnonymous]
    //    public virtual ActionResult ForgotPasswordRecoveryQuestion([Bind(Prefix = "id")]string requestToken)
    //    {
    //        var validRequestToken = _forgotPasswordRequestTokenSvc.ReadByToken(requestToken);

    //        ForgotPasswordRecoveryQuestionViewModel model = new ForgotPasswordRecoveryQuestionViewModel();

    //        if (validRequestToken == null || validRequestToken.UsedFlg)
    //            return RedirectToAction(MVC.Error.NotFound());

    //        if (validRequestToken.ExpirationDate <= DateTime.Now)
    //        {
    //            // Messaging for token expired
    //            ModelState.AddModelError("", "Your password reset request has expired. Please request a new password reset email.");
    //            ViewBag.HideQuestion = true;
    //            return View(model);
    //        }


    //        // Set Session facade
    //        this._sessionFacade.ForgotPasswordVerificationRequest =
    //            new ForgotPasswordVerificationRequest(
    //                        validRequestToken.UserProfileId,
    //                        validRequestToken.RequestToken,
    //                        false);

    //        // Valid, Unused, Active Token
    //        var userProfile = _teacherSvc.Read(validRequestToken.UserProfileId);
    //        model.Prompt = "Please enter your security question response to validate your request.";
    //        model.Question = userProfile.UserProfileSecurityQuestions.OrderBy(a => a.LastTimeAsked).First().SecurityQuestion.Question;
    //        model.UserProfileId = userProfile.Id;
    //        model.RequestToken = validRequestToken.RequestToken;

    //        ViewBag.HideQuestion = false;

    //        return View(model);
    //    }

    //    [AllowAnonymous]
    //    [HttpPost]
    //    public virtual ActionResult ForgotPasswordRecoveryQuestion(ForgotPasswordRecoveryQuestionViewModel model)
    //    {
    //        if (this._sessionFacade.ForgotPasswordVerificationRequest == null)
    //            return RedirectToAction(MVC.Error.NotFound());

    //        if (!ModelState.IsValid)
    //            return View(model);

    //        // Read the profile and validate the answer is correct

    //        var userProfile = _teacherSvc.Read(model.UserProfileId);
    //        var securityQuestion = _userProfileSecurityQuestionSvc.Find(
    //            userProfile.UserProfileSecurityQuestions.Find(a => a.SecurityQuestion.Question == model.Question).Id);

    //        if ((securityQuestion.DataMigrationFlags.HasFlag(SecurityQuestionDataMigrationFlags.MigrateAnswer)
    //             && _dataMigrationSvc.MigrateUserSecurityQuestionAnswer(securityQuestion, model.Answer))
    //            || securityQuestion.VerifyAnswer(model.Answer))
    //        {

    //            // Answer is correct
    //            userProfile.ResetBadPasswordAttempt();

    //            this._sessionFacade.ForgotPasswordVerificationRequest.IsAnswered = true;

    //            return RedirectToAction(MVC.Account.ActionNames.ForgotPasswordRecoveryPassword,
    //                new { id = model.RequestToken });
    //        }
    //        else
    //        {
    //            //  add error to model state
    //            ModelState.AddModelError("", "Your answer does not match our records.");

    //            //add bad login audit
    //            CreateLoginAudit(LoginAuditType.FailedLogin, userProfile.Username, userProfile);
    //            userProfile.LogBadPasswordAttempt();
    //            _teacherSvc.Update(userProfile);

    //            //update security question
    //            securityQuestion.LastTimeAsked = DateTime.Now;
    //            _userProfileSecurityQuestionSvc.Update(securityQuestion);
    //            _uow.SaveChanges();

    //            if (userProfile.Flags.HasFlag(UserProfileFlags.BadLoginAttemptLockedOut))
    //            {
    //                AddNotification(NextRequestNotificationType.Error, "Your account has been locked. Please contact your account administrator.");
    //                return RedirectToAction(MVC.Account.Login());
    //            }

    //            //update view state
    //            ViewData = null;
    //            ViewBag.HideQuestion = false;
    //            this._sessionFacade.LoginSecurityQuestionVerificationRequest =
    //                new LoginSecurityQuestionVerificationRequest(
    //                    LoginSecurityQuestionVerificationRequestReason.UnverfiedMachine + 1, userProfile.Id, false)
    //                {
    //                    Reason = LoginSecurityQuestionVerificationRequestReason.UnverfiedMachine + 1
    //                };

    //            var newModel = LoginCreateAccountVerificationViewModel(userProfile.UserProfileSecurityQuestions);
    //            model.Question = newModel.Question;

    //            return View(model);
    //        }
    //    }

    //    [AllowAnonymous]
    //    public virtual ActionResult ForgotPasswordRecoveryPassword([Bind(Prefix = "id")]string requestToken)
    //    {
    //        if (this._sessionFacade.ForgotPasswordVerificationRequest == null
    //            || !this._sessionFacade.ForgotPasswordVerificationRequest.IsAnswered)
    //            return RedirectToAction(MVC.Error.NotFound());

    //        // Security Question has been answered
    //        // Rebuild request data

    //        var token = _forgotPasswordRequestTokenSvc.ReadByToken(requestToken);

    //        ForgotPasswordRecoveryPasswordViewModel model = new ForgotPasswordRecoveryPasswordViewModel()
    //        {
    //            RequestToken = token.RequestToken,
    //            UserProfileId = token.UserProfileId
    //        };

    //        return View(model);
    //    }


    //    [AllowAnonymous]
    //    [HttpPost]
    //    public virtual ActionResult ForgotPasswordRecoveryPassword(ForgotPasswordRecoveryPasswordViewModel model)
    //    {
    //        if (!ModelState.IsValid)
    //            return View(model);

    //        //Update password
    //        var userProfile = _teacherSvc.Read(model.UserProfileId);
    //        userProfile.SetPassword(model.NewPassword);
    //        _teacherSvc.Update(userProfile);

    //        // Set token to used
    //        var requestToken = this._forgotPasswordRequestTokenSvc.ReadByToken(model.RequestToken);
    //        requestToken.UsedFlg = true;
    //        this._forgotPasswordRequestTokenSvc.Update(requestToken);

    //        _uow.SaveChanges();

    //        return RedirectToAction(MVC.Account.Login());
    //    }

    //    #endregion


    //    #region LOGIC

    //    private AccountVerificationViewModel LoginCreateAccountVerificationViewModel(IEnumerable<UserProfileSecurityQuestion> userProfileSecurityQuestions)
    //    {
    //        var model = Mapper.Map<AccountVerificationViewModel>(userProfileSecurityQuestions.OrderBy(a => a.LastTimeAsked).First());

    //        // SET MESSAGE

    //        switch (this._sessionFacade.LoginSecurityQuestionVerificationRequest.Reason)
    //        {
    //            case LoginSecurityQuestionVerificationRequestReason.UnverfiedMachine:
    //                model.Prompt = "You are accessing the site from an unrecognized location. Please enter your security question response.";
    //                break;
    //            default:
    //                model.Prompt = "Please enter your security question response to validate your account.";
    //                break;
    //        }

    //        return model;
    //    }

    //    private void CreateLoginAudit(LoginAuditType type, string username, UserProfile profile)
    //    {
    //        _loginAuditSvc.CreateLoginAudit(
    //            type,
    //            HttpContext.Request.UserHostAddress,
    //            _sessionFacade.Session.SessionID,
    //            username,
    //            profile == null ? null : (long?)profile.Id);
    //    }

    //    #endregion

    }
}