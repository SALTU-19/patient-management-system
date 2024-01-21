using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PreOp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UId { get; set; }
        public int TargetWeight { get; set; }
        public string DoctorId { get; set; }
        public string SurgeryType { get; set; }
        public DateTime SurgeryDate { get; set; }
        public Guid? OrganizationId { get; set; }
        public List<string> ConsultedSurgeryTypes { get; set; }
        public List<string> SupplimentedSurgeryTypes { get; set; }
        public List<string> AssistantDoctors { get; set; }
        public Patient Patient { get; set; }
        public Guid PatientUId { get; set; }

        public PreOp() { }

        public PreOp(int targetWeight, string doctorId, string surgeryType, DateTime surgeryDate, Guid? organizationId, List<string> consultedSurgeryTypes, List<string> supplimentedSurgeryTypes, List<string> assistantDoctors, Guid patientUId)
        {
            TargetWeight = targetWeight;
            DoctorId = doctorId;
            SurgeryType = surgeryType;
            SurgeryDate = surgeryDate;
            OrganizationId = organizationId;
            ConsultedSurgeryTypes = consultedSurgeryTypes;
            SupplimentedSurgeryTypes = supplimentedSurgeryTypes;
            AssistantDoctors = assistantDoctors;
            PatientUId = patientUId;
        }
    }
}
