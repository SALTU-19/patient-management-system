using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class HospitalCreateRequest
    {

        public HospitalCreateRequest() { }

        public HospitalCreateRequest(string name, string coordinate, string address, string district, string city, Guid organizationId, string? mobile, string? zipCode, string? image)
        {
            Name = name;
            Coordinate = coordinate;
            Address = address;
            District = district;
            City = city;
            OrganizationId = organizationId;
            Mobile = mobile;
            ZipCode = zipCode;
            Image = image;
        }
        public required string Name { get; set; }
        public required string Coordinate { get; set; }
        public required string Address { get; set; }
        public required string District { get; set; }
        public required string City { get; set; }
        public required Guid OrganizationId { get; set; }
        public string? Mobile { get; set; }
        public string? ZipCode { get; set; }
        public string? Image { get; set; }
    }
}
