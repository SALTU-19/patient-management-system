using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class UserUpdateRequest
    {
        public UserUpdateRequest() { }

        public UserUpdateRequest(string email, string name, string surname, string mobile)
        {
            Email = email;
            Name = name;
            Surname = surname;
            Mobile = mobile;
        }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Mobile { get; set; }
    }
}
