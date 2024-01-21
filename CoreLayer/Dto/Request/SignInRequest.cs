using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class SignInRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public SignInRequest() { }

        public SignInRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
