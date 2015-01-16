using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Nop.Core.Social;
using Nop.Web.Framework.Security;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Web.Infrastructure.Cache;

namespace Nop.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        private readonly ICacheManager _cacheManager;

        #region Constructors

        public HomeController(ICacheManager cacheManager)
        {
            this._cacheManager = cacheManager;
        }

        #endregion


        [NopHttpsRequirement(SslRequirement.No)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns Twitter Feeds in JSON format
        /// </summary>
        /// <returns></returns>
        public string TwitterFeeds()
        {
            // Get tweest from cache if possible
            var cacheKey = string.Format(ModelCacheEventConsumer.TWITTER_FEEDS_KEY);
            var tweets = _cacheManager.Get<string>(cacheKey);
            
            if (!string.IsNullOrEmpty(tweets)) return tweets;
            
            //no value in the cache yet so let's retrieve it

            var tm = new TwitterManager(
                ConfigurationManager.AppSettings["Twitter-Access-Token"],
                ConfigurationManager.AppSettings["Twitter-Access-Token-Secret"],
                ConfigurationManager.AppSettings["Twitter-Consumer-Key"],
                ConfigurationManager.AppSettings["Twitter-Consumer-Secret"]
                );

            int maximumTweets;
            if (!Int32.TryParse(ConfigurationManager.AppSettings["Twitter-MaximumTweets"], out maximumTweets))
            {
                maximumTweets = 6;
            }

            tweets = tm.GetUserTimeline(ConfigurationManager.AppSettings["Twitter-ScreenName"], maximumTweets);

            int tweetDuration;
            if (!Int32.TryParse(ConfigurationManager.AppSettings["Twitter-Cache-Duration"], out tweetDuration))
            {
                tweetDuration = 10; // 10 minutes
            }

            //let's cache the result
            _cacheManager.Set(cacheKey, tweets, tweetDuration);

            return tweets;
        }
    }
}
