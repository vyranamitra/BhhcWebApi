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
        }
    
}