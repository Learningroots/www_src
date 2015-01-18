using System;
using System.Configuration;
using System.Web.Mvc;
using Nop.Core.Caching;
using Nop.Core.Social;
using Nop.Services.Logging;
using Nop.Web.Framework.Security;
using Nop.Web.Infrastructure.Cache;

namespace Nop.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        #region Fields

        private readonly ICacheManager _cacheManager;
        private readonly ILogger _logger;

        #endregion

        #region Constructors

        public HomeController(ICacheManager cacheManager, ILogger logger)
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

        #region Twitter

        /// <summary>
        /// Returns Twitter Feeds in JSON format
        /// </summary>
        /// <returns></returns>
        public string TwitterFeed()
        {
            try
            {
                // Get feed from cache if possible
                var cacheKey = string.Format(ModelCacheEventConsumer.TWITTER_FEEDS_KEY);
                var feed = _cacheManager.Get<string>(cacheKey);

                if (!string.IsNullOrEmpty(feed)) return feed;

                //no value in the cache yet so let's retrieve it

                var tm = new TwitterManager(
                    ConfigurationManager.AppSettings["Twitter.AccessToken"],
                    ConfigurationManager.AppSettings["Twitter.AccessTokenSecret"],
                    ConfigurationManager.AppSettings["Twitter.ConsumerKey"],
                    ConfigurationManager.AppSettings["Twitter.ConsumerSecret"]
                    );

                int maximumTweets;
                if (!Int32.TryParse(ConfigurationManager.AppSettings["Twitter.MaximumTweets"], out maximumTweets))
                {
                    maximumTweets = 6;
                }

                feed = tm.GetUserTimeline(ConfigurationManager.AppSettings["Twitter.ScreenName"], maximumTweets);

                int cacheDuration;
                if (!Int32.TryParse(ConfigurationManager.AppSettings["Twitter.CacheDuration"], out cacheDuration))
                {
                    cacheDuration = 10; // 10 minutes
                }

                //let's cache the result
                _cacheManager.Set(cacheKey, feed, cacheDuration);

                return feed;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return string.Empty;
            }
        }

        #endregion

        #region Instagram

        /// <summary>
        /// Get recent media posted by the user. THe number to return is configurable 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string InstagramFeed()
        {
            try
            {
                // Get feed from cache if possible
                var cacheKey = string.Format(ModelCacheEventConsumer.INSTAGRAM_FEEDS_KEY);
                var feed = _cacheManager.Get<string>(cacheKey);

                if (!string.IsNullOrEmpty(feed)) return feed;

                //no value in the cache yet so let's retrieve it
                
                int count;
                if (!Int32.TryParse(ConfigurationManager.AppSettings["Instagram.MediaCount"], out count))
                {
                    count = 3;
                }
 
                var im = new InstagramManager();

                feed = im.GetRecentMedia(ConfigurationManager.AppSettings["Instagram.ClientId"],
                    ConfigurationManager.AppSettings["Instagram.UserId"], count);

                int cacheDuration;
                if (!Int32.TryParse(ConfigurationManager.AppSettings["Instagram.CacheDuration"], out cacheDuration))
                {
                    cacheDuration = 10; // 10 minutes
                }

                //let's cache the result
                _cacheManager.Set(cacheKey, feed, cacheDuration);

                return feed;

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return string.Empty;
            }
        }

        /// <summary>
        /// This is the method Instagram will callback to to provide the API auth token. 
        /// The callback will contain a code in the query string
        /// Once the auth token is retrieved, save the relevant properties in the app.config file
        /// Currently only the id is used and saved in Instagram.UserId
        /// This URL kicks it all off and it will callback to this method:
        /// https://api.instagram.com/oauth/authorize/?client_id=[clientId]&amp;response_type=code&amp;redirect_uri=[callbackUrl]
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string InstagramCallback()
        {
            try
            {
                var code = Request.QueryString["code"];
                
                if (string.IsNullOrEmpty(code))
                {
                    return string.Empty;
                }

                var im = new InstagramManager();

                return im.GetAuthToken(
                    ConfigurationManager.AppSettings["Instagram.ClientId"],
                    ConfigurationManager.AppSettings["Instagram.ClientSecret"],
                    ConfigurationManager.AppSettings["Instagram.CallbackUrl"],
                    code);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return string.Empty;
            }
        }

        #endregion
    }
}
