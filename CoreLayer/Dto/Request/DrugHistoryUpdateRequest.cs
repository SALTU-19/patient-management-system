using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dto.Request
{
    public class DrugHistoryUpdateRequest
    {

        public DrugHistoryUpdateRequest() { }

        public DrugHistoryUpdateRequest(string name, DateTime startingDate, DateTime endingDate, string doctorComment)
        {
            Name = name;
            StartingDate = startingDate;
            EndingDate = endingDate;
            DoctorComment = doctorComment;
        }
        public required string Name { get; set; }
        public required DateTime StartingDate { get; set; }
        public required DateTime EndingDate { get; set; }
        public required string DoctorComment { get; set; }
    }
}
