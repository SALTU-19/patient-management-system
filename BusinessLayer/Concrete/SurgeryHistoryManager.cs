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
    public class SurgeryHistoryManager : ISurgeryHistoryService
    {
        private readonly ISurgeryHistoryDal _surgeryHistory;
        private readonly IPatientDal _patient;
        public SurgeryHistoryManager(ISurgeryHistoryDal surgeryHistory, IPatientDal patient)
        {
            _surgeryHistory = surgeryHistory;
            _patient = patient;
        }
        public ResponseModel Add(SurgeryHistoryCreateRequest createRequest)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (createRequest == null)
            {
                //throw new ArgumentNullException(nameof(createRequest));
                _responseModel.Message = "createRequest is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.Name))
            {
                //throw new ArgumentNullException(nameof(createRequest.Name));
                _responseModel.Message = "createRequest.Name is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.DoctorComment))
            {
                //throw new ArgumentNullException(nameof(createRequest.DoctorComment));
                _responseModel.Message = "createRequest.DoctorComment is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (createRequest.Date == null)
            {
                //throw new ArgumentNullException(nameof(createRequest.Date));
                _responseModel.Message = "createRequest.Date is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (createRequest.PatientUId == Guid.Empty)
            {
                //throw new ArgumentNullException(nameof(createRequest.PatientUId));
                _responseModel.Message = "createRequest.PatientUId is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                Patient patient = _patient.GetByUId(createRequest.PatientUId);
                if (patient == null)
                {
                    //throw new ArgumentNullException(nameof(patient));
                    _responseModel.Message = "patient is null";
                    _responseModel.Code = HttpStatusCode.BadRequest;
                    return _responseModel;
                }
                else
                {
                    SurgeryHistory surgeryHistory = new SurgeryHistory(name: createRequest.Name, doctorComment: createRequest.DoctorComment, date: createRequest.Date, patientUId: createRequest.PatientUId,organizationId: null);
                    //return _surgeryHistory.Insert(surgeryHistory);
                    _responseModel.Message = "SurgeryHistory created successfully";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = _surgeryHistory.Insert(surgeryHistory);
                    return _responseModel;
                }
            }
        }

        public ResponseModel Delete(Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (uid == null)
            {
                //throw new ArgumentNullException(nameof(uid));
                _responseModel.Message = "uid is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                SurgeryHistory surgeryHistory = _surgeryHistory.GetByUId(uid);

                if (surgeryHistory == null)
                {
                    //return null;
                    _responseModel.Message = "SurgeryHistory is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }
                else
                {
                    //return _surgeryHistory.Delete(surgeryHistory);
                    _responseModel.Message = "SurgeryHistory deleted successfully";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = _surgeryHistory.Delete(surgeryHistory);
                    return _responseModel;
                }
            }
        }

        public ResponseModel GetAll()
        {
            ResponseModel _responseModel = new ResponseModel();
            List<SurgeryHistory> surgeryHistorys = _surgeryHistory.GetAll();


            //return surgeryHistorys;
            _responseModel.Message = "SurgeryHistorys are found";
            _responseModel.Code = HttpStatusCode.OK;
            _responseModel.Data = surgeryHistorys;
            return _responseModel;
        }

        public ResponseModel GetByUId(Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (uid == null)
            {
                //throw new ArgumentNullException(nameof(uid));
                _responseModel.Message = "uid is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;

            }
            else
            {
                SurgeryHistory surgeryHistory = _surgeryHistory.GetByUId(uid);

                if (surgeryHistory == null)
                {
                    //return null;
                    _responseModel.Message = "SurgeryHistory is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }
                else
                {
                    //return surgeryHistory;
                    _responseModel.Message = "SurgeryHistory is found";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = surgeryHistory;
                    return _responseModel;
                }
            }
        }

        public ResponseModel Update(SurgeryHistoryUpdateRequest updateRequest, Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (updateRequest == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest));
                _responseModel.Message = "updateRequest is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.Name))
            {
                //throw new ArgumentNullException(nameof(updateRequest.Name));
                _responseModel.Message = "updateRequest.Name is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.DoctorComment))
            {
                //throw new ArgumentNullException(nameof(updateRequest.DoctorComment));
                _responseModel.Message = "updateRequest.DoctorComment is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.Date == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest.Date));
                _responseModel.Message = "updateRequest.Date is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (uid == null)
            {
                //throw new ArgumentNullException(nameof(uid));
                _responseModel.Message = "uid is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                SurgeryHistory surgeryHistory = _surgeryHistory.GetByUId(uid);
                if (surgeryHistory == null)
                {
                    //return null;
                    _responseModel.Message = "SurgeryHistory is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }
                else
                {
                    surgeryHistory.Name = updateRequest.Name;
                    surgeryHistory.DoctorComment = updateRequest.DoctorComment;
                    surgeryHistory.Date = updateRequest.Date;
 

                        
                    //return _surgeryHistory.Update(surgeryHistory);
                    _responseModel.Message = "SurgeryHistory updated successfully";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = _surgeryHistory.Update(surgeryHistory);
                    return _responseModel;
                }
            }
        }
    }
}
