using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mobile { get; set; }
        public UserStatusEnum UserStatusEnum { get; set; }
        
        public string Password { get; set; }

        public string Role { get; set; }

        public string? UserImage { get; set; }

        public Guid? OrganizationId { get; set; }

        public User() { }

        public User(string email, string name, string surname, string mobile, UserStatusEnum userStatusEnum, string password, string role, Guid? organizationId, string? userImage)
        {
            Email = email;
            Name = name;
            Surname = surname;
            Mobile = mobile;
            UserStatusEnum = userStatusEnum;
            Password = password;
            Role = role;
            OrganizationId = organizationId;
            UserImage = userImage;
        }

    }

    public enum UserStatusEnum
    {
        [Key]
        CREATED,
        ACTIVATED,
        CONFIRMED,
        DELETED,
    }
}
