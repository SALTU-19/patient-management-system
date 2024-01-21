using BusinessLayer.Abstract;
using CoreLayer.Dto.Request;
using CoreLayer.Dto.Response;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BusinessLayer.Concrete
{
    public class SessionManager : ISessionService
    {
        private readonly ISessionDal _session;
        private readonly IPatientDal _patient;
        public SessionManager(ISessionDal session)
        {
            _session = session;
        }
        public ResponseModel GetAll()
        {
            ResponseModel _responseModel = new ResponseModel();
            List<Session> sessions = _session.GetAll();



            //return sessions;

            _responseModel.Message = "Sessions are found.";
            _responseModel.Code = HttpStatusCode.OK;
            _responseModel.Data = sessions;
            return _responseModel;
        }
    }
}
