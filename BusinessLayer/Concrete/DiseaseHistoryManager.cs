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
    public class DiseaseHistoryManager : IDiseaseHistoryService
    {
        private readonly IDiseaseHistoryDal _diseaseHistory;
        private readonly IPatientDal _patient;

        public DiseaseHistoryManager(IDiseaseHistoryDal diseaseHistory, IPatientDal patient)
        {
            _diseaseHistory = diseaseHistory;
            _patient = patient;
        }
        public ResponseModel Add(DiseaseHistoryCreateRequest createRequest)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (createRequest == null)
            {
                //throw new ArgumentNullException(nameof(createRequest));
                _responseModel.Message = "CreateRequest is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.Explonation))
            {
                //throw new ArgumentNullException(nameof(createRequest.Explonation));
                _responseModel.Message = "createRequest.Explonation is null";
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
                //return _diseaseHistory.Insert(new DiseaseHistory(createRequest.Name,  createRequest.Explonation, createRequest.PatientUId, null));
                _responseModel.Message = "DiseaseHistory created successfully";
                _responseModel.Code = System.Net.HttpStatusCode.OK;
                _responseModel.Data = _diseaseHistory.Insert(new DiseaseHistory(name: createRequest.Name, explonation: createRequest.Explonation, patientUId: createRequest.PatientUId,organizationId:null));
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
                DiseaseHistory diseaseHistory = _diseaseHistory.GetByUId(uid);

                if (diseaseHistory == null)
                {
                    //return null;
                    _responseModel.Message = "DiseaseHistory is not found";
                    _responseModel.Code = System.Net.HttpStatusCode.NotFound;
                    return _responseModel;
                }

                // Perform the deletion logic
                //return _diseaseHistory.Delete(diseaseHistory);
                _responseModel.Message = "DiseaseHistory deleted successfully";
                _responseModel.Code = System.Net.HttpStatusCode.OK;
                _responseModel.Data = _diseaseHistory.Delete(diseaseHistory);
                return _responseModel;
            }
        }

        public ResponseModel GetAll()
        {
            //List<DiseaseHistory> drugHistories = _diseaseHistory.GetAll();
            //return drugHistories;
            ResponseModel _responseModel = new ResponseModel();
            List<DiseaseHistory> diseaseHistories = _diseaseHistory.GetAll();

            _responseModel.Message = "DiseaseHistory is found";
            _responseModel.Code = System.Net.HttpStatusCode.OK;
            _responseModel.Data = diseaseHistories;
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
                DiseaseHistory diseaseHistory = _diseaseHistory.GetByUId(uid);

                if (diseaseHistory == null)
                {
                    //return null;
                    _responseModel.Message = "DiseaseHistory is not found";
                    _responseModel.Code = System.Net.HttpStatusCode.NotFound;
                    return _responseModel;
                }

                //return diseaseHistory;
                _responseModel.Message = "DiseaseHistory is found";
                _responseModel.Code = System.Net.HttpStatusCode.OK;
                _responseModel.Data = diseaseHistory;
                return _responseModel;
            }
        }

        public ResponseModel Update(DiseaseHistoryUpdateRequest updateRequest, Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (updateRequest == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest));
                _responseModel.Message = "updateRequest is null";
                _responseModel.Code = System.Net.HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.Explonation))
            {
                //throw new ArgumentNullException(nameof(updateRequest.Explonation));
                _responseModel.Message = "updateRequest.Explonation is null";
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
            else
            {
                DiseaseHistory diseaseHistory = _diseaseHistory.GetByUId(uid);

                if (diseaseHistory == null)
                {
                    //return null;
                    _responseModel.Message = "DiseaseHistory is not found";
                    _responseModel.Code = System.Net.HttpStatusCode.NotFound;
                    return _responseModel;
                }

                diseaseHistory.Name = updateRequest.Name;
                diseaseHistory.Explonation = updateRequest.Explonation;


                // Perform the update logic
                //return _diseaseHistory.Update(diseaseHistory);
                _responseModel.Message = "DiseaseHistory updated successfully";
                _responseModel.Code = System.Net.HttpStatusCode.OK;
                _responseModel.Data = _diseaseHistory.Update(diseaseHistory);
                return _responseModel;
            }
        }
    }
}
