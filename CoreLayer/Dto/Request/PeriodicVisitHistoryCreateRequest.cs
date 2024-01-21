using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class PeriodicVisitHistoryCreateRequest
    {
        public PeriodicVisitHistoryCreateRequest() { }

        public PeriodicVisitHistoryCreateRequest(int vKI, int eWL, List<string> img, string bloadSituation, string doctorComment, Guid patientUId)
        {
            VKI = vKI;
            EWL = eWL;
            Img = img;
            BloadSituation = bloadSituation;
            DoctorComment = doctorComment;
            PatientUId = patientUId;
        }
        public required int VKI { get; set; }
        public required int EWL { get; set; }
        public required List<string> Img { get; set; }
        public required string BloadSituation { get; set; }
        public required string DoctorComment { get; set; }
        public required Guid PatientUId { get; set; }
    }
}
