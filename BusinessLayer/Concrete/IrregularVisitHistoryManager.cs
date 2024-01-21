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

namespace BusinessLayer.Concrete
{

    public class IrregularVisitHistoryManager : IIrregularVisitHistoryService
    {
        private readonly IIrregularVisitHistoryDal _irrugelarVisitHistory;
        private readonly IPatientDal _patient;
        public IrregularVisitHistoryManager(IIrregularVisitHistoryDal irrugelarVisitHistory, IPatientDal patient)
        {
            _irrugelarVisitHistory = irrugelarVisitHistory;
            _patient = patient;
        }
        public ResponseModel Add(IrregularVisitHistoryCreateRequest createRequest)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (createRequest == null)
            {
                //throw new ArgumentNullException(nameof(createRequest));

                _responseModel.Message = "CreateRequest is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;

            }
            else if (string.IsNullOrWhiteSpace(createRequest.DoctorComment))
            {
                //throw new ArgumentNullException(nameof(createRequest.DoctorComment));
                _responseModel.Message = "createRequest.DoctorComment is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.BloadSituation))
            {
                //throw new ArgumentNullException(nameof(createRequest.BloadSituation));
                _responseModel.Message = "createRequest.BloadSituation is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (createRequest.Date == null)
            {
                //throw new ArgumentNullException(nameof(createRequest.Date));
                _responseModel.Message = "createRequest.Date is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (createRequest.EWL == 0)
            {
                //throw new ArgumentNullException(nameof(createRequest.EWL));
                _responseModel.Message = "createRequest.EWL is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (createRequest.Img == null)
            {
                //throw new ArgumentNullException(nameof(createRequest.Img));
                _responseModel.Message = "createRequest.Img is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (createRequest.PatientUId == Guid.Empty)
            {
                //throw new ArgumentNullException(nameof(createRequest.PatientUId));
                _responseModel.Message = "createRequest.PatientUId is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (createRequest.VKI == 0)
            {
                //throw new ArgumentNullException(nameof(createRequest.VKI));
                _responseModel.Message = "createRequest.VKI is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                Patient patient = _patient.GetByUId(createRequest.PatientUId);

                if (patient == null)
                {
                    //throw new ArgumentNullException(nameof(patient));
                    _responseModel.Message = "patient is null";
                    _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                    return _responseModel;
                }
                // Perform the creation logic
                IrregularVisitHistory irregularVisitHistory = new IrregularVisitHistory(date: createRequest.Date, vKI: createRequest.VKI, eWL: createRequest.EWL, img: createRequest.Img, bloadSituation: createRequest.BloadSituation, doctorComment: createRequest.DoctorComment, patientUId: createRequest.PatientUId, organizationId: null);

                //return _irrugelarVisitHistory.Insert(irregularVisitHistory);
                _responseModel.Message = "IrregularVisitHistory created successfully";
                _responseModel.Code = System.Net.HttpStatusCode.OK;
                _responseModel.Data = _irrugelarVisitHistory.Insert(irregularVisitHistory);
                return _responseModel;
            }
        }

        public ResponseModel Delete(Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (uid == null)
            {
                //throw new ArgumentNullException(nameof(uid));
                _responseModel.Message = "uid is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                IrregularVisitHistory irregularVisitHistory = _irrugelarVisitHistory.GetByUId(uid);

                if(irregularVisitHistory == null)
                {
                    //return null;
                    _responseModel.Message = "IrregularVisitHistory is not found";
                    _responseModel.Code = System.Net.HttpStatusCode.NotFound;
                    return _responseModel;
                }

                // Perform the deletion logic
                //return _irrugelarVisitHistory.Delete(irregularVisitHistory);
                _responseModel.Message = "IrregularVisitHistory deleted successfully";
                _responseModel.Code = System.Net.HttpStatusCode.OK;
                _responseModel.Data = _irrugelarVisitHistory.Delete(irregularVisitHistory);
                return _responseModel;
            }
        }

        public ResponseModel GetAll()
        {
            ResponseModel _responseModel = new ResponseModel();
            List<IrregularVisitHistory> irregularVisitHistories = _irrugelarVisitHistory.GetAll();


            //return irregularVisitHistories;
            _responseModel.Message = "IrregularVisitHistories are found";
            _responseModel.Code = System.Net.HttpStatusCode.OK;
            _responseModel.Data = irregularVisitHistories;
            return _responseModel;
        }

        public ResponseModel GetByUId(Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (uid == null)
            {
                //throw new ArgumentNullException(nameof(uid));
                _responseModel.Message = "uid is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;

            }
            else
            {
                IrregularVisitHistory irregularVisitHistory = _irrugelarVisitHistory.GetByUId(uid);

                if (irregularVisitHistory == null)
                {
                    //return null;
                    _responseModel.Message = "IrregularVisitHistory is not found";
                    _responseModel.Code = System.Net.HttpStatusCode.NotFound;
                    return _responseModel;

                }
                //return irregularVisitHistory;
                _responseModel.Message = "IrregularVisitHistory is found";
                _responseModel.Code = System.Net.HttpStatusCode.OK;
                _responseModel.Data = irregularVisitHistory;
                return _responseModel;
            }
        }

        public ResponseModel Update(IrregularVisitHistoryUpdateRequest updateRequest, Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (updateRequest == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest));
                _responseModel.Message = "updateRequest is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;

            }
            else if (string.IsNullOrWhiteSpace(updateRequest.DoctorComment))
            {
                //throw new ArgumentNullException(nameof(updateRequest.DoctorComment));
                _responseModel.Message = "updateRequest.DoctorComment is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;

            }
            else if (string.IsNullOrWhiteSpace(updateRequest.BloadSituation))
            {
                //throw new ArgumentNullException(nameof(updateRequest.BloadSituation));
                _responseModel.Message = "updateRequest.BloadSituation is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.Date == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest.Date));
                _responseModel.Message = "updateRequest.Date is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.EWL == 0)
            {
                //throw new ArgumentNullException(nameof(updateRequest.EWL));
                _responseModel.Message = "updateRequest.EWL is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.Img == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest.Img));
                _responseModel.Message = "updateRequest.Img is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.VKI == 0)
            {
                //throw new ArgumentNullException(nameof(updateRequest.VKI));
                _responseModel.Message = "updateRequest.VKI is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                IrregularVisitHistory irregularVisitHistory = _irrugelarVisitHistory.GetByUId(uid);

                if (irregularVisitHistory == null)
                {
                    //return null;
                    _responseModel.Message = "IrregularVisitHistory is not found";
                    _responseModel.Code = System.Net.HttpStatusCode.NotFound;
                    return _responseModel;
                }

                // Perform the update logic
                irregularVisitHistory.Date = updateRequest.Date;
                irregularVisitHistory.VKI = updateRequest.VKI;
                irregularVisitHistory.EWL = updateRequest.EWL;
                irregularVisitHistory.Img = updateRequest.Img;
                irregularVisitHistory.BloadSituation = updateRequest.BloadSituation;
                irregularVisitHistory.DoctorComment = updateRequest.DoctorComment;
      

                //return _irrugelarVisitHistory.Update(irregularVisitHistory);
                _responseModel.Message = "IrregularVisitHistory updated successfully";
                _responseModel.Code = System.Net.HttpStatusCode.OK;
                _responseModel.Data = _irrugelarVisitHistory.Update(irregularVisitHistory);
                return _responseModel;
            }
        }
    }
}
