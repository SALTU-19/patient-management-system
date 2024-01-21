using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class IrregularVisitHistoryUpdateRequest
    {

        public IrregularVisitHistoryUpdateRequest() { }

        public IrregularVisitHistoryUpdateRequest(DateTime date, int vKI, int eWL, List<string> img, string bloadSituation, string doctorComment)
        {
            Date = date;
            VKI = vKI;
            EWL = eWL;
            Img = img;
            BloadSituation = bloadSituation;
            DoctorComment = doctorComment;
        }

        public required DateTime Date { get; set; }
        public required int VKI { get; set; }
        public required int EWL { get; set; }
        public required List<string> Img { get; set; }
        public required string BloadSituation { get; set; }
        public required string DoctorComment { get; set; }
    }
}
