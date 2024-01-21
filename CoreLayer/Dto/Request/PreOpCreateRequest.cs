using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class PreOpCreateRequest
    {
        public PreOpCreateRequest() { }

        public PreOpCreateRequest(int targetWeight, string doctorId, string surgeryType, DateTime surgeryDate, List<string> consultedSurgeryTypes, List<string> supplimentedSurgeryTypes, List<string> assistantDoctors, Guid patientUId)
        {
            TargetWeight = targetWeight;
            DoctorId = doctorId;
            SurgeryType = surgeryType;
            SurgeryDate = surgeryDate;
            ConsultedSurgeryTypes = consultedSurgeryTypes;
            SupplimentedSurgeryTypes = supplimentedSurgeryTypes;
            AssistantDoctors = assistantDoctors;
            PatientUId = patientUId;
        }
        public required int TargetWeight { get; set; }
        public required string DoctorId { get; set; }
        public required string SurgeryType { get; set; }
        public required DateTime SurgeryDate { get; set; }
        public required List<string> ConsultedSurgeryTypes { get; set; }
        public required List<string> SupplimentedSurgeryTypes { get; set; }
        public required List<string> AssistantDoctors { get; set; }
        public required Guid PatientUId { get; set; }
    }
}
