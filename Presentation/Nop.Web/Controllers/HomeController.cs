using System;
using System.Configuration;
using System.Web.Mvc;
using Nop.Core.Social;
using Nop.Web.Framework.Security;

namespace Nop.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        [NopHttpsRequirement(SslRequirement.No)]
        public ActionResult Index()
        {
            return View();
        }

        public string TwitterFeeds()
        {
            var tm = new TwitterManager(
                           ConfigurationManager.AppSettings["Twitter-Access-Token"],
                           ConfigurationManager.AppSettings["Twitter-Access-Token-Secret"],
                           ConfigurationManager.AppSettings["Twitter-Consumer-Key"],
                           ConfigurationManager.AppSettings["Twitter-Consumer-Secret"]
                           );

            int maximumTweets;
            if (!Int32.TryParse(ConfigurationManager.AppSettings["Twitter-Consumer-Secret"], out maximumTweets))
            {
                maximumTweets = 5;
            }

            var tweets = tm.GetUserTimeline(ConfigurationManager.AppSettings["Twitter-ScreenName"], maximumTweets);
            
            return tweets;
        }
    }
}
