using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PostOp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UId { get; set; }
        public string DoctorId { get; set; }
        public string DoctorComment { get; set; }
        public string SurgeryType { get; set; }
        public int Drenaj { get; set; }
        public DateTime SurgeryDate { get; set; }
        public Guid? OrganizationId { get; set; }
        public List<string> ConsultedMedications { get; set; }
        public List<string> SupplimentedMedications { get; set; }
        public Patient Patient { get; set; }

        public Guid PatientUId { get; set; }

        public PostOp() { }

        public PostOp(string doctorId,string doctorComment, string surgeryType, int drenaj, DateTime surgeryDate, Guid? organizationId, List<string> consultedMedications, List<string> supplimentedMedications, Guid patientUId)
        {
            DoctorId = doctorId;
            DoctorComment = doctorComment;
            SurgeryType = surgeryType;
            Drenaj = drenaj;
            SurgeryDate = surgeryDate;
            OrganizationId = organizationId;
            ConsultedMedications = consultedMedications;
            SupplimentedMedications = supplimentedMedications;
            PatientUId = patientUId;
        }
    }
}
