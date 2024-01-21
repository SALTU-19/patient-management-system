using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }

        public ResetPasswordRequest() { }

        public ResetPasswordRequest(string email)
        {
            Email = email;
        }
    }
}
