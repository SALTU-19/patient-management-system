using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class DrugHistoryCreateRequest
    {

        public DrugHistoryCreateRequest() { }

        public DrugHistoryCreateRequest(string name, DateTime startingDate, DateTime endingDate, string doctorComment, Guid patientUId)
        {
            Name = name;
            StartingDate = startingDate;
            EndingDate = endingDate;
            DoctorComment = doctorComment;
            PatientUId = patientUId;
        }

        public required string Name { get; set; }
        public required DateTime StartingDate { get; set; }
        public required DateTime EndingDate { get; set; }
        public required string DoctorComment { get; set; }

        public required Guid PatientUId { get; set; }
    }
}
