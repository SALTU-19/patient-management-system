using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CoreLayer.Dto.Response
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public HttpStatusCode Code { get; set; }

        public ResponseModel()
        {

        }

        public ResponseModel(string message, object data, HttpStatusCode code)
        {
            Message = message;
            Data = data;
            Code = code;
        }
    }
}
