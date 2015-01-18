using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Text;
using Newtonsoft.Json;
using Nop.Core.Domain.Logging;

namespace Nop.Core.Social
{
    public class InstagramManager
    {
        private Exception _error;

        private const string AccessTokenUrl = "https://api.instagram.com/oauth/access_token";
        private const string RecentMediaUrl = "https://api.instagram.com/v1/users/{0}/media/recent/?client_id={1}&count={2}";

        #region Constructors

        public InstagramManager()
        {
        }

        #endregion

        #region Public Properties

        public Exception Error
        {
            get { return _error; }
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// Get specified number of media that was uploaded by the user
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="userId"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public string GetRecentMedia(string clientId, string userId, int count)
        {
            var media = GetRecentMediaByClientId(clientId, userId, count);
            return media;
        }

        #endregion

        #region Private Methods

        private string GetRecentMediaByClientId(string clientId, string userId, int count)
        {
            try
            {
                var result = string.Empty;

                var endPoint = string.Format(RecentMediaUrl, userId, clientId, count);
                
                using (var webClient = new WebClient())
                {
                    using (var stream = webClient.OpenRead(endPoint))
                    {
                        if (stream == null) return result;
                        
                        using (var streamReader = new StreamReader(stream))
                        {
                            result = streamReader.ReadToEnd();
                        }
                    }
                } 

                return result;
            }
            catch (Exception ex)
            {
                _error = ex;
                return string.Empty;
            }
        }
        

        /// <summary>
        /// Get Instagram auth token. The code is provided in the callback from Instagram
        /// The 2 properties in the response that we need is the "access_token" and "id" to call the
        /// API to get recent media
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="callbackUrl"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetAuthToken(string clientId, string clientSecret, string callbackUrl, string code)
        {
            if (string.IsNullOrEmpty(code)) return string.Empty;

            try
            {
                var parameters = new NameValueCollection
                {
                    {"client_id", clientId},
                    {"client_secret", clientSecret},
                    {"grant_type", "authorization_code"},
                    {"redirect_uri", callbackUrl},
                    {"code", code}
                };

                var client = new WebClient();
                var result = client.UploadValues(AccessTokenUrl, "POST", parameters);

                var response = Encoding.Default.GetString(result);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Instagram access token", ex);
            }
        }

        #endregion

    }
}
