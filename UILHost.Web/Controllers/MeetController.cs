using System.Web.Mvc;
using UILHost.Infrastructure.Services.Interface;
using UILHost.Patterns.Repository.UnitOfWork;

namespace UILHost.Web.Controllers
{
    public partial class MeetController : Controller
    {
        private readonly IUnitOfWorkAsync _uow;
        private readonly IMeetService _meetSvc;

        public MeetController(IUnitOfWorkAsync uow, IMeetService meetSvc)
        {
            _uow = uow;
            _meetSvc = meetSvc;
        }

        // GET: Meet
        public virtual ActionResult Index()
        {
            return View(_meetSvc.Read());
        }
    }
}