using System.Web.Mvc;
using Nop.Core.Caching;
using Nop.Services.Logging;
using Nop.Web.Framework.Security;

namespace Nop.Web.Controllers
{
    public class TheaterController : BasePublicController
    {
        #region Fields

        private readonly ICacheManager _cacheManager;
        private readonly ILogger _logger;

        #endregion

        #region Constructors

        public TheaterController(ICacheManager cacheManager, ILogger logger)
        {
            _cacheManager = cacheManager;
            _logger = logger;
        }

        #endregion

        [NopHttpsRequirement(SslRequirement.No)]
        public ActionResult Index()
        {
            return View();
        }
    }
}