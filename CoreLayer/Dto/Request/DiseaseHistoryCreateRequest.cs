using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class DiseaseHistoryCreateRequest
    {

        public DiseaseHistoryCreateRequest() { }

        public DiseaseHistoryCreateRequest(string name, string explonation, Guid patientUId)
        {
            Name = name;
            Explonation = explonation;
            PatientUId = patientUId;
        }

        public required string Name { get; set; }
        public required string Explonation { get; set; }

        public required Guid PatientUId { get; set; }
    }
}
