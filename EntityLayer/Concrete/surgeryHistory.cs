using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SurgeryHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UId { get; set; }
        public Guid? OrganizationId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string DoctorComment { get; set; }
        public Patient Patient { get; set; }
        public Guid PatientUId { get; set; }

        public SurgeryHistory() { }

        public SurgeryHistory(string name, DateTime date, string doctorComment, Guid patientUId, Guid? organizationId)
        {
            Name = name;
            Date = date;
            DoctorComment = doctorComment;
            OrganizationId = organizationId;
            PatientUId = patientUId;
        }
    }
}
