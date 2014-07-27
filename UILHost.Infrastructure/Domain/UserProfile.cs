using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenefitMall.Pavlos.Infrastructure.Entity;

namespace UILHost.Infrastructure.Domain
{
    [Flags]
    public enum UserProfileFlags : long
    {
        Undefined = 0,
        Active = 1,
        BadLoginAttemptLockedOut = 2
    }

    [Flags]
    public enum UserProfileDataMigrationFlags : long
    {
        Undefined = 0,
        MigratePassword = 1,
    }

    public class UserProfile : EntityBase<long>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public School School { get; set; }

        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }

        //public DateTime? LastUnsuccessfulLoginAttempt { get; set; }
        //public int? CurrentUnsuccessfulLoginCount { get; set; }

        //public UserProfileFlags Flags { get; set; }

        //public string DataMigrationProvider { get; set; }
        //public UserProfileDataMigrationFlags DataMigrationFlags { get; set; }

        //public List<UserProfileSecurityQuestion> UserProfileSecurityQuestions { get; set; }
        //public List<ClientUserProfile> ClientUserProfiles { get; set; }

        public UserProfile() : this(null, null, null, null) { }
        public UserProfile(string email, string firstName, string lastName, string clearTextPassword)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            SetPassword(clearTextPassword);
            //Flags = UserProfileFlags.Active;
            //DataMigrationFlags = UserProfileDataMigrationFlags.Undefined;

            //ClientUserProfiles = new List<ClientUserProfile>();
            //UserProfileSecurityQuestions = new List<UserProfileSecurityQuestion>();
        }

        public void SetPassword(string clearTextPassword)
        {
            var hash = new SaltedHash(clearTextPassword);
            PasswordHash = hash.Hash;
            PasswordSalt = hash.Salt;
        }

        public bool VerifyPassword(string clearTextPassword)
        {
            return new SaltedHash(PasswordSalt, PasswordHash).Verify(clearTextPassword);
        }

        public void LogBadPasswordAttempt()
        {
            //if (LastUnsuccessfulLoginAttempt == null ||
            //    LastUnsuccessfulLoginAttempt < DateTime.Now.AddMilliseconds(AppConfigFacade.LastBadLoginTimePeriodThreshold * -1))
            //{
            //    LastUnsuccessfulLoginAttempt = DateTime.Now;
            //    CurrentUnsuccessfulLoginCount = 0;
            //}

            //CurrentUnsuccessfulLoginCount++;

            //if (CurrentUnsuccessfulLoginCount >= AppConfigFacade.LastBadLoginAttemptsThreshold)
            //{
            //    Flags = Flags.SetFlag<UserProfileFlags>(UserProfileFlags.BadLoginAttemptLockedOut);
            //}
        }

        //public void ResetBadPasswordAttempt()
        //{
        //    CurrentUnsuccessfulLoginCount = 0;
        //}
    }
}
