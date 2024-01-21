using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class DiseaseHistoryUpdateRequest
    {

        public DiseaseHistoryUpdateRequest() { }

        public DiseaseHistoryUpdateRequest(string name, string explonation)
        {
            Name = name;
            Explonation = explonation;
        }

        public required string Name { get; set; }
        public required string Explonation { get; set; }
    }
}
