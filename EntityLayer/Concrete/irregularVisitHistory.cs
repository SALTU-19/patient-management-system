using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class IrregularVisitHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UId { get; set; }
        public Guid? OrganizationId { get; set; }
        public DateTime Date { get; set; }
        public int VKI { get; set; }
        public int EWL { get; set; }
        public List<string> Img { get; set; }
        public string BloadSituation { get; set; }
        public string DoctorComment { get; set; }
        public Patient Patient { get; set; }
        public Guid PatientUId { get; set; }

        public IrregularVisitHistory() { }

        public IrregularVisitHistory(DateTime date, int vKI, int eWL, List<string> img, string bloadSituation, string doctorComment, Guid patientUId, Guid? organizationId)
        {
            Date = date;
            VKI = vKI;
            EWL = eWL;
            Img = img;
            BloadSituation = bloadSituation;
            DoctorComment = doctorComment;
            PatientUId = patientUId;
            OrganizationId = organizationId;
        }
        
    }
}
