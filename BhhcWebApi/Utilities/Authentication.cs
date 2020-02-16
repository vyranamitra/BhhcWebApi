using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BhhcWebApi.Utilities
{
        public static class Authentication
        {

            /// <summary>
            /// Encodes input token using Base64 scheme
            /// </summary>
            /// <param name="token"></param>
            /// <returns></returns>
            public static string EncodeToken(string token)
            {
                if (string.IsNullOrEmpty(token))
                {
                    throw new ArgumentNullException("token");
                }
                byte[] input = System.Text.Encoding.UTF8.GetBytes(token);
                return System.Convert.ToBase64String(input);
            }

            /// <summary>
            /// Decode input token using Base64 scheme
            /// </summary>
            /// <param name="token"></param>
            /// <returns></returns>
            public static string DecodeToken(string encodedToken)
            {
                if (string.IsNullOrEmpty(encodedToken))
                {
                    throw new ArgumentNullException("encodedToken");
                }

                byte[] input = System.Convert.FromBase64String(encodedToken);
                return System.Text.Encoding.UTF8.GetString(input);
            }

            /// <summary>
            /// Returns true if the decoded token matches the value of authToken
            /// otherwise returns false
            /// </summary>
            /// <param name="token"></param>
            /// <returns></returns>
            public static bool IsAuthorized(string authToken, string inputToken)
            {
                if (string.IsNullOrEmpty(authToken))
                {
                    throw new ArgumentNullException("authToken");
                }
                if (string.IsNullOrEmpty(inputToken))
                {
                    throw new ArgumentNullException("inputToken");
                }
                string decodedToken = Utilities.Authentication.DecodeToken(inputToken);
                return (authToken.Equals(decodedToken) ? true : false);
            }

    }
    
}