using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class SurgeryHistoryUpdateRequest
    {
        public SurgeryHistoryUpdateRequest() { }

        public SurgeryHistoryUpdateRequest(string name, DateTime date, string doctorComment)
        {
            Name = name;
            Date = date;
            DoctorComment = doctorComment;
        }

        public required string Name { get; set; }
        public required DateTime Date { get; set; }
        public required string DoctorComment { get; set; }
    }
}
