using System.Collections.Generic;
using System.Web.Helpers;
using Tweetinvi;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Json;

namespace Nop.Core.Social
{
    /// <summary>
    /// Make calls to the Twitter API via this Manager which utilses the Tweetinvi library
    /// https://tweetinvi.codeplex.com
    /// </summary>
    public class TwitterManager
    {
        public TwitterManager(string accessToken, string accessTokenSecret, string consumerKey, string consumerSecret )
        {
            TwitterCredentials.SetCredentials(accessToken, accessTokenSecret, consumerKey, consumerSecret);
        }

        public string GetUserTimeline(string userScreenName, int maximumTweets)
        {
            var tweets = TimelineJson.GetUserTimeline(userScreenName, maximumTweets);
            return tweets;
        }
    }
}
