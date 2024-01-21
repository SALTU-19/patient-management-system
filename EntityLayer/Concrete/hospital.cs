using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Hospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string Coordinate { get; set; }
        public Guid? OrganizationId { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
        public string ZipCode { get; set; }
        public string? Image { get; set; }

        public Hospital() { }

        public Hospital(string name, string coordinate, Guid? organizationId, string address, string district, string city, string mobile, string zipCode, string? image)
        {
            Name = name;
            Coordinate = coordinate;
            OrganizationId = organizationId;
            Address = address;
            District = district;
            City = city;
            Mobile = mobile;
            ZipCode = zipCode;
            Image = image;
        }
    }
}
