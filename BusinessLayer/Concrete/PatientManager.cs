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
    public class PatientManager : IPatientService
    {
        private readonly IPatientDal _patient;
        private readonly IDiseaseHistoryDal _diseaseHistory;
        private readonly IDrugHistoryDal _drugHistoryDal;
        private readonly ISurgeryHistoryDal _surgeryHistoryDal;
        private readonly IPreOpDal _preOpDal;
        private readonly IPostOpDal _postOpDal;
        private readonly IPeriodicVisitHistoryDal _periodicVisitHistoryDal;
        private readonly IIrregularVisitHistoryDal _irregularVisitHistoryDal;

        public PatientManager(IPatientDal patient, IDiseaseHistoryDal diseaseHistory, IDrugHistoryDal drugHistoryDal, ISurgeryHistoryDal surgeryHistoryDal, IPreOpDal preOpDal, IPostOpDal postOpDal, IPeriodicVisitHistoryDal periodicVisitHistoryDal, IIrregularVisitHistoryDal irregularVisitHistoryDal)
        {
            _patient = patient;
            _diseaseHistory = diseaseHistory;
            _drugHistoryDal = drugHistoryDal;
            _surgeryHistoryDal = surgeryHistoryDal;
            _preOpDal = preOpDal;
            _postOpDal = postOpDal;
            _periodicVisitHistoryDal = periodicVisitHistoryDal;
            _irregularVisitHistoryDal = irregularVisitHistoryDal;

        }

        public ResponseModel Add(PatientCreateRequest createRequest)
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
            else if (string.IsNullOrWhiteSpace(createRequest.Surname))
            {
                //throw new ArgumentNullException(nameof(createRequest.Surname));
                _responseModel.Message = "createRequest.Surname is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.Phone))
            {
                //throw new ArgumentNullException(nameof(createRequest.Phone));
                _responseModel.Message = "createRequest.Phone is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.Mail))
            {
                //throw new ArgumentNullException(nameof(createRequest.Mail));
                _responseModel.Message = "createRequest.Mail is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.Address))
            {
                //throw new ArgumentNullException(nameof(createRequest.Address));
                _responseModel.Message = "createRequest.Address is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (createRequest.Age == 0)
            {
                //throw new ArgumentNullException(nameof(createRequest.Age));
                _responseModel.Message = "createRequest.Age is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (createRequest.Size == 0)
            {
                //throw new ArgumentNullException(nameof(createRequest.Size));
                _responseModel.Message = "createRequest.Size is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (createRequest.Weight == 0)
            {
                //throw new ArgumentNullException(nameof(createRequest.Weight));
                _responseModel.Message = "createRequest.Weight is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (createRequest.BodyMassIndex == 0)
            {
                //throw new ArgumentNullException(nameof(createRequest.BodyMassIndex));
                _responseModel.Message = "createRequest.BodyMassIndex is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (createRequest.BMI == 0)
            {
                //throw new ArgumentNullException(nameof(createRequest.BMI));
                _responseModel.Message = "createRequest.BMI is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                //return _patient.Insert(new Patient(name: createRequest.Name, surname: createRequest.Surname, phone: createRequest.Phone, mail: createRequest.Mail, address: createRequest.Address, age: createRequest.Age, size: createRequest.Size, weight: createRequest.Weight, bodyMassIndex: createRequest.BodyMassIndex, bmi: createRequest.BMI, image: createRequest.Image,organizationId:null));
                
                _responseModel.Message = "Patient created successfully";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = _patient.Insert(new Patient(name: createRequest.Name, surname: createRequest.Surname, phone: createRequest.Phone, mail: createRequest.Mail, address: createRequest.Address, age: createRequest.Age, size: createRequest.Size, weight: createRequest.Weight, bodyMassIndex: createRequest.BodyMassIndex, bmi: createRequest.BMI, image: createRequest.Image, organizationId: null));
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
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                Patient patient = _patient.GetByUId(uid);

                if(patient == null)
                {
                    //return null;
                    _responseModel.Message = "Patient is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }

                //return _patient.Delete(patient);
                _responseModel.Message = "Patient deleted successfully";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = _patient.Delete(patient);
                return _responseModel;
            }
        }

        public ResponseModel GetAll()
        {
            ResponseModel _responseModel = new ResponseModel();
            List<Patient> patients = _patient.GetAll();

            //return patients;
            _responseModel.Message = "Patients are found";
            _responseModel.Code = HttpStatusCode.OK;
            _responseModel.Data = patients;
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
                Patient patient = _patient.GetByUId(uid);

                if(patient == null)
                {
                    //return null;
                    _responseModel.Message = "Patient is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }

                //return patient;
                _responseModel.Message = "Patient is found";
                _responseModel.Code = HttpStatusCode.OK;

                // Get all disease history 
                
                List<DiseaseHistory> diseaseHistories = _diseaseHistory.GetAll();

                // filter disease history by patient uid

                List<DiseaseHistory> filteredDiseaseHistories = diseaseHistories.Where(x => x.PatientUId == patient.UId).ToList();

                // Get all drug history

                List<DrugHistory> drugHistories = _drugHistoryDal.GetAll();

                // filter drug history by patient uid

                List<DrugHistory> filteredDrugHistories = drugHistories.Where(x => x.PatientUId == patient.UId).ToList();

                // Get all surgery history

                List<SurgeryHistory> surgeryHistories = _surgeryHistoryDal.GetAll();

                // filter surgery history by patient uid

                List<SurgeryHistory> filteredSurgeryHistories = surgeryHistories.Where(x => x.PatientUId == patient.UId).ToList();

                // Get all pre op

                List<PreOp> preOps = _preOpDal.GetAll();

                // filter pre op by patient uid

                List<PreOp> filteredPreOps = preOps.Where(x => x.PatientUId == patient.UId).ToList();

                // Get all post op

                List<PostOp> postOps = _postOpDal.GetAll();

                // filter post op by patient uid

                List<PostOp> filteredPostOps = postOps.Where(x => x.PatientUId == patient.UId).ToList();

                // Get all periodic visit history

                List<PeriodicVisitHistory> periodicVisitHistories = _periodicVisitHistoryDal.GetAll();

                // filter periodic visit history by patient uid

                List<PeriodicVisitHistory> filteredPeriodicVisitHistories = periodicVisitHistories.Where(x => x.PatientUId == patient.UId).ToList();

                // Get all irregular visit history

                List<IrregularVisitHistory> irregularVisitHistories = _irregularVisitHistoryDal.GetAll();

                // filter irregular visit history by patient uid

                List<IrregularVisitHistory> filteredIrregularVisitHistories = irregularVisitHistories.Where(x => x.PatientUId == patient.UId).ToList();

                // Add all filtered history to patient

                patient.DiseaseHistory = filteredDiseaseHistories;
                patient.DrugHistory = filteredDrugHistories;
                patient.SurgeryHistory = filteredSurgeryHistories;
                patient.PreOps = filteredPreOps;
                patient.PostOps = filteredPostOps;
                patient.PeriodicVisitHistory = filteredPeriodicVisitHistories;
                patient.IrregularVisitHistory = filteredIrregularVisitHistories;



                _responseModel.Data = patient;
                return _responseModel;
            }
        }

        public ResponseModel Update(PatientUpdateRequest updateRequest, Guid uid)
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
            else if (string.IsNullOrWhiteSpace(updateRequest.Surname))
            {
                //throw new ArgumentNullException(nameof(updateRequest.Surname));
                _responseModel.Message = "updateRequest.Surname is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.Phone))
            {
                //throw new ArgumentNullException(nameof(updateRequest.Phone));
                _responseModel.Message = "updateRequest.Phone is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.Mail))
            {
                //throw new ArgumentNullException(nameof(updateRequest.Mail));
                _responseModel.Message = "updateRequest.Mail is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.Address))
            {
                //throw new ArgumentNullException(nameof(updateRequest.Address));
                _responseModel.Message = "updateRequest.Address is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.Age == 0)
            {
                //throw new ArgumentNullException(nameof(updateRequest.Age));
                _responseModel.Message = "updateRequest.Age is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.Size == 0)
            {
                //throw new ArgumentNullException(nameof(updateRequest.Size));
                _responseModel.Message = "updateRequest.Size is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.Weight == 0)
            {
                //throw new ArgumentNullException(nameof(updateRequest.Weight));
                _responseModel.Message = "updateRequest.Weight is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.BodyMassIndex == 0)
            {
                //throw new ArgumentNullException(nameof(updateRequest.BodyMassIndex));
                _responseModel.Message = "updateRequest.BodyMassIndex is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.BMI == 0)
            {
                //throw new ArgumentNullException(nameof(updateRequest.BMI));
                _responseModel.Message = "updateRequest.BMI is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                Patient patient = _patient.GetByUId(uid);

                if(patient == null)
                {
                    //return null;
                    _responseModel.Message = "Patient is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }

                patient.Name = updateRequest.Name;
                patient.Surname = updateRequest.Surname;
                patient.Phone = updateRequest.Phone;
                patient.Mail = updateRequest.Mail;
                patient.Address = updateRequest.Address;
                patient.Age = updateRequest.Age;
                patient.Size = updateRequest.Size;
                patient.Weight = updateRequest.Weight;
                patient.BodyMassIndex = updateRequest.BodyMassIndex;
                patient.BMI = updateRequest.BMI;
                patient.Image = updateRequest.Image;
   

                //return _patient.Update(patient);
                _responseModel.Message = "Patient updated successfully";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = _patient.Update(patient);
                return _responseModel;
            }   
        }
    }
}
