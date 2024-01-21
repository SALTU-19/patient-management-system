using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class OrganizationUpdateRequest
    {
        public OrganizationUpdateRequest() { }
        public OrganizationUpdateRequest(string name)
        {
            Name = name;
        }
        public required string Name { get; set; }
    }
}
