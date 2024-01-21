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
    public class PeriodicVisitHistoryManager : IPeriodicVisitHistoryService
    {
        private readonly IPeriodicVisitHistoryDal _drugHistory;
        private readonly IPatientDal _patient;
        public PeriodicVisitHistoryManager(IPeriodicVisitHistoryDal drugHistory, IPatientDal patient)
        {
            _drugHistory = drugHistory;
            _patient = patient;
        }
        public ResponseModel Add(PeriodicVisitHistoryCreateRequest createRequest)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (createRequest == null)
            {
                //throw new ArgumentNullException(nameof(createRequest));
                _responseModel.Message = "createRequest is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(string.IsNullOrWhiteSpace(createRequest.DoctorComment))
            {
                //throw new ArgumentNullException(nameof(createRequest.DoctorComment));
                _responseModel.Message = "createRequest.DoctorComment is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(string.IsNullOrWhiteSpace(createRequest.BloadSituation))
            {
                //throw new ArgumentNullException(nameof(createRequest.BloadSituation));
                _responseModel.Message = "createRequest.BloadSituation is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(createRequest.EWL == 0)
            {
                //throw new ArgumentNullException(nameof(createRequest.EWL));
                _responseModel.Message = "createRequest.EWL is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(createRequest.Img == null)
            {
                //throw new ArgumentNullException(nameof(createRequest.Img));
                _responseModel.Message = "createRequest.Img is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(createRequest.PatientUId == Guid.Empty)
            {
                //throw new ArgumentNullException(nameof(createRequest.PatientUId));
                _responseModel.Message = "createRequest.PatientUId is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(createRequest.VKI == 0)
            {
                //throw new ArgumentNullException(nameof(createRequest.VKI));
                _responseModel.Message = "createRequest.VKI is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                Patient patient = _patient.GetByUId(createRequest.PatientUId);
                if(patient == null)
                {
                    //throw new ArgumentNullException(nameof(patient));
                    _responseModel.Message = "patient is null";
                    _responseModel.Code = HttpStatusCode.BadRequest;
                    return _responseModel;
                }
                else
                {
                    PeriodicVisitHistory periodicVisitHistory = new PeriodicVisitHistory(eWL: createRequest.EWL, vKI: createRequest.VKI, img: createRequest.Img, bloadSituation: createRequest.BloadSituation, doctorComment: createRequest.DoctorComment, patientUId: createRequest.PatientUId, organizationId: null);
                    //return _drugHistory.Insert(periodicVisitHistory);

                    _responseModel.Message = "PeriodicVisitHistory created successfully";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = _drugHistory.Insert(periodicVisitHistory);
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
                PeriodicVisitHistory periodicVisitHistory = _drugHistory.GetByUId(uid);
                if(periodicVisitHistory == null)
                {
                    //return null;
                    _responseModel.Message = "PeriodicVisitHistory is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }
                else
                {
                    //return _drugHistory.Delete(periodicVisitHistory);
                    _responseModel.Message = "PeriodicVisitHistory deleted successfully";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = _drugHistory.Delete(periodicVisitHistory);
                    return _responseModel;
                }
            }
        }

        public ResponseModel GetAll()
        {
            ResponseModel _responseModel = new ResponseModel();
            List<PeriodicVisitHistory> periodicVisitHistories = _drugHistory.GetAll();

 
                //return periodicVisitHistories;

            _responseModel.Message = "PeriodicVisitHistories are found";
            _responseModel.Code = HttpStatusCode.OK;
            _responseModel.Data = periodicVisitHistories;
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
                PeriodicVisitHistory periodicVisitHistory = _drugHistory.GetByUId(uid);
                if(periodicVisitHistory == null)
                {
                    //return null;
                    _responseModel.Message = "PeriodicVisitHistory is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }
                else
                {
                    //return periodicVisitHistory;
                    _responseModel.Message = "PeriodicVisitHistory is found";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = periodicVisitHistory;
                    return _responseModel;
                }
            }
        }

        public ResponseModel Update(PeriodicVisitHistoryUpdateRequest updateRequest, Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (updateRequest == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest));
                _responseModel.Message = "updateRequest is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(string.IsNullOrWhiteSpace(updateRequest.DoctorComment))
            {
                //throw new ArgumentNullException(nameof(updateRequest.DoctorComment));
                _responseModel.Message = "updateRequest.DoctorComment is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(string.IsNullOrWhiteSpace(updateRequest.BloadSituation))
            {
                //throw new ArgumentNullException(nameof(updateRequest.BloadSituation));
                _responseModel.Message = "updateRequest.BloadSituation is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(updateRequest.EWL == 0)
            {
                //throw new ArgumentNullException(nameof(updateRequest.EWL));
                _responseModel.Message = "updateRequest.EWL is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(updateRequest.Img == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest.Img));
                _responseModel.Message = "updateRequest.Img is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(updateRequest.VKI == 0)
            {
                //throw new ArgumentNullException(nameof(updateRequest.VKI));
                _responseModel.Message = "updateRequest.VKI is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                PeriodicVisitHistory periodicVisitHistory = _drugHistory.GetByUId(uid);
                if(periodicVisitHistory == null)
                {
                    //return null;
                    _responseModel.Message = "PeriodicVisitHistory is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }
                else
                {
                    periodicVisitHistory.EWL = updateRequest.EWL;
                    periodicVisitHistory.VKI = updateRequest.VKI;
                    periodicVisitHistory.Img = updateRequest.Img;
                    periodicVisitHistory.BloadSituation = updateRequest.BloadSituation;
                    periodicVisitHistory.DoctorComment = updateRequest.DoctorComment;
                    //return _drugHistory.Update(periodicVisitHistory);
                    _responseModel.Message = "PeriodicVisitHistory updated successfully";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = _drugHistory.Update(periodicVisitHistory);
                    return _responseModel;
                }
            }
        }
    }
}
