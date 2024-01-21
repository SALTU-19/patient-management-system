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
    public class DrugHistoryManager : IDrugHistoryService
    {

        private readonly IDrugHistoryDal _drugHistory;
        private readonly IPatientDal _patient;

        public DrugHistoryManager(IDrugHistoryDal drugHistory, IPatientDal patient)
        {
            _drugHistory = drugHistory;
            _patient = patient;
        }
        public ResponseModel Add(DrugHistoryCreateRequest createRequest)
        {
            ResponseModel _responseModel = new ResponseModel();
            if(createRequest == null)
            {
                //throw new ArgumentNullException(nameof(createRequest));
                _responseModel.Message = "createRequest is null";
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
            else if (string.IsNullOrWhiteSpace(createRequest.Name))
            {
                //throw new ArgumentNullException(nameof(createRequest.Name));
                _responseModel.Message = "createRequest.Name is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            // createRequest.PatientUId
            else if (createRequest.PatientUId == Guid.Empty)
            {
                //throw new ArgumentNullException(nameof(createRequest.PatientUId));
                _responseModel.Message = "createRequest.PatientUId is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            // createRequest.StartDate
            else if (createRequest.StartingDate == null)
            {
                //throw new ArgumentNullException(nameof(createRequest.StartingDate));
                _responseModel.Message = "createRequest.StartingDate is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (createRequest.EndingDate == null)
            {
                //throw new ArgumentNullException(nameof(createRequest.StartingDate));
                _responseModel.Message = "createRequest.EndingDate is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                Patient patient = _patient.GetByUId(createRequest.PatientUId);

                if (patient == null)
                {
                    //throw new ArgumentNullException(nameof(patient));
                    _responseModel.Message = "patient is not found";
                    _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                    return _responseModel;
                }
                // Perform the creation logic
                //return _drugHistory.Insert(new DrugHistory(createRequest.Name, createRequest.StartingDate, createRequest.EndingDate, createRequest.DoctorComment, createRequest.PatientUId, null));
                
                _responseModel.Message = "DrugHistory created successfully";
                _responseModel.Code = System.Net.HttpStatusCode.OK;
                _responseModel.Data = _drugHistory.Insert(new DrugHistory(createRequest.Name, createRequest.StartingDate, createRequest.EndingDate, createRequest.DoctorComment, createRequest.PatientUId, null));
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
                DrugHistory drugHistory = _drugHistory.GetByUId(uid);

                if (drugHistory == null)
                {
                    //return null;
                    _responseModel.Message = "DrugHistory is not found";
                    _responseModel.Code = System.Net.HttpStatusCode.NotFound;
                    return _responseModel;
                }

                // Perform the deletion logic
                //return _drugHistory.Delete(drugHistory);
                _responseModel.Message = "DrugHistory deleted successfully";
                _responseModel.Code = System.Net.HttpStatusCode.OK;
                _responseModel.Data = _drugHistory.Delete(drugHistory);

                return _responseModel;
            }
        }

        public ResponseModel GetAll()
        {
            List<DrugHistory> drugHistories = _drugHistory.GetAll();



            //return drugHistories;
            ResponseModel _responseModel = new ResponseModel();
            _responseModel.Message = "DrugHistories are found";
            _responseModel.Code = System.Net.HttpStatusCode.OK;
            _responseModel.Data = drugHistories;
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
                DrugHistory drugHistory = _drugHistory.GetByUId(uid);

                if (drugHistory == null)
                {
                    //return null;
                    _responseModel.Message = "DrugHistory is not found";
                    _responseModel.Code = System.Net.HttpStatusCode.NotFound;
                    return _responseModel;
                }

                //return drugHistory;
                _responseModel.Message = "DrugHistory is found";
                _responseModel.Code = System.Net.HttpStatusCode.OK;
                _responseModel.Data = drugHistory;
                return _responseModel;
            }
        }

        public ResponseModel Update(DrugHistoryUpdateRequest updateRequest, Guid uid)
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
            else if (string.IsNullOrWhiteSpace(updateRequest.Name))
            {
                //throw new ArgumentNullException(nameof(updateRequest.Name));
                _responseModel.Message = "updateRequest.Name is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            // updateRequest.StartDate
            else if (updateRequest.StartingDate == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest.StartingDate));
                _responseModel.Message = "updateRequest.StartingDate is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.EndingDate == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest.StartingDate));
                _responseModel.Message = "updateRequest.EndingDate is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                DrugHistory drugHistory = _drugHistory.GetByUId(uid);

                if (drugHistory == null)
                {
                    //return null;
                    _responseModel.Message = "DrugHistory is not found";
                    _responseModel.Code = System.Net.HttpStatusCode.NotFound;
                    return _responseModel;
                }

                drugHistory.Name = updateRequest.Name;
                drugHistory.StartingDate = updateRequest.StartingDate;
                drugHistory.EndingDate = updateRequest.EndingDate;
                drugHistory.DoctorComment = updateRequest.DoctorComment;


                // Perform the update logic
                //return _drugHistory.Update(drugHistory);
                _responseModel.Message = "DrugHistory updated successfully";
                _responseModel.Code = System.Net.HttpStatusCode.OK;
                _responseModel.Data = _drugHistory.Update(drugHistory);
                return _responseModel;
            }
        }
    }
}
