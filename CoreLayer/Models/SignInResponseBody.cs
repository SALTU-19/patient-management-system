using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class SignInResponseBody
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DecodedUserModel DecodedUserModel { get; set; }

        public SignInResponseBody() { }

        public SignInResponseBody(string accessToken, string refreshToken, DecodedUserModel decodedUserModel)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            DecodedUserModel = decodedUserModel;
        }
    }
}
