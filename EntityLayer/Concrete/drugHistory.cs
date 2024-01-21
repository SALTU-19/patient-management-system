using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class DrugHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UId { get; set; }
        public Guid? OrganizationId { get; set; }
        public string Name { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string DoctorComment { get; set; }
        public Patient Patient { get; set; }
        public Guid PatientUId { get; set; }

        public DrugHistory() { }

        public DrugHistory(string name, DateTime startingDate, DateTime endingDate, string doctorComment, Guid patientUId, Guid? organizationId)
        {
            Name = name;
            StartingDate = startingDate;
            EndingDate = endingDate;
            DoctorComment = doctorComment;
            OrganizationId = organizationId;
            PatientUId = patientUId;
        }
 
    }
}
