using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class UserCreateRequest
    {
        public UserCreateRequest() { }

        public UserCreateRequest(string email,string name, string surname, string mobile, string roleName, string password)
        {
            Email = email;
            Name = name;
            Surname = surname;
            Mobile = mobile;
            RoleName = roleName;
            Password = password;
        }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Mobile { get; set; }
        public required string Password { get; set; }
        public required string RoleName { get; set; }
    }
}
