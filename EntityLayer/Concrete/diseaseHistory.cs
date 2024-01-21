using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EntityLayer.Concrete
{

    public class DiseaseHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UId { get; set; }
        public Guid? OrganizationId { get; set; }
        public string Name { get; set; }
        public string Explonation { get; set; }
        public Patient Patient { get; set; }

        public Guid PatientUId { get; set; }

        public DiseaseHistory() { }

        public DiseaseHistory(string name, string explonation, Guid patientUId, Guid? organizationId)
        {
            Name = name;
            Explonation = explonation;
            OrganizationId = organizationId;
            PatientUId = patientUId;
        }
    }
}
