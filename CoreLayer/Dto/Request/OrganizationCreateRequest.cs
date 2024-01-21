using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class OrganizationCreateRequest
    {
        public OrganizationCreateRequest() { }

        public OrganizationCreateRequest(string name)
        {
            Name = name;
        }

        public required string Name { get; set; }
    }
}
