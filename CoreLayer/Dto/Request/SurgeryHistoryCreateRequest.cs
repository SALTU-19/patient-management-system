using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class SurgeryHistoryCreateRequest
    {
        public SurgeryHistoryCreateRequest() { }

        public SurgeryHistoryCreateRequest(string name, DateTime date, string doctorComment, Guid patientUId)
        {
            Name = name;
            Date = date;
            DoctorComment = doctorComment;
            PatientUId = patientUId;
        }

        public required string Name { get; set; }
        public required DateTime Date { get; set; }
        public required string DoctorComment { get; set; }
        public required Guid PatientUId { get; set; }
    }
}
