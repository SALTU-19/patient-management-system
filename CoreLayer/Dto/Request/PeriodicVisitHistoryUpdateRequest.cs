using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class PeriodicVisitHistoryUpdateRequest
    {
        public PeriodicVisitHistoryUpdateRequest() { }

        public PeriodicVisitHistoryUpdateRequest(int vKI, int eWL, List<string> img, string bloadSituation, string doctorComment)
        {
            VKI = vKI;
            EWL = eWL;
            Img = img;
            BloadSituation = bloadSituation;
            DoctorComment = doctorComment;
        }
        public required int VKI { get; set; }
        public required int EWL { get; set; }
        public required List<string> Img { get; set; }
        public required string BloadSituation { get; set; }
        public required string DoctorComment { get; set; }
    }
}
