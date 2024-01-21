using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class DecodedUserModel
    {
        public Guid UserUId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }

        public DecodedUserModel() { }

        public DecodedUserModel(Guid userUId, string email, string name, string surname, string role)
        {
            UserUId = userUId;
            Email = email;
            Name = name;
            Surname = surname;
            Role = role;
        }
    }
}
