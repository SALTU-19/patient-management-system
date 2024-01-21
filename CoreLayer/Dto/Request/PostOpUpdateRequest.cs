using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class PostOpUpdateRequest
    {
        public PostOpUpdateRequest() { }

        public PostOpUpdateRequest(string doctorId, string doctorComment, string surgeryType, int drenaj,DateTime surgeryDate, List<string> consultedMedications, List<string> supplimentedMedications)
        {
            DoctorId = doctorId;
            DoctorComment = doctorComment;
            SurgeryType = surgeryType;
            Drenaj = drenaj;
            SurgeryDate = surgeryDate;
            ConsultedMedications = consultedMedications;
            SupplimentedMedications = supplimentedMedications;
        }
        public required string DoctorId { get; set; }
        public required string DoctorComment { get; set; }
        public required string SurgeryType { get; set; }
        public required int Drenaj { get; set; }
        public required DateTime SurgeryDate { get; set; }
        public required List<string> ConsultedMedications { get; set; }
        public required List<string> SupplimentedMedications { get; set; }
    }
}
