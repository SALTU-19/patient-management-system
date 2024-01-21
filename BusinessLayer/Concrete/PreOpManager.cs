using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using CoreLayer.Dto.Request;
using CoreLayer.Dto.Response;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Net;

namespace BusinessLayer.Concrete
{
    public class PreOpManager : IPreOpService
    {
        private readonly IPreOpDal _preOp;
        private readonly IPatientDal _patient;
        public PreOpManager(IPreOpDal preOp, IPatientDal patient)
        {
            _preOp = preOp;
            _patient = patient;
        }
        public ResponseModel Add(PreOpCreateRequest createRequest)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (createRequest == null)
            {
                //throw new ArgumentNullException(nameof(createRequest));
                _responseModel.Message = "createRequest is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(createRequest.TargetWeight == 0)
            {
                //throw new ArgumentNullException(nameof(createRequest.TargetWeight));
                _responseModel.Message = "createRequest.TargetWeight is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(string.IsNullOrWhiteSpace(createRequest.DoctorId))
            {
                //throw new ArgumentNullException(nameof(createRequest.DoctorId));
                _responseModel.Message = "createRequest.DoctorId is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(string.IsNullOrWhiteSpace(createRequest.SurgeryType))
            {
                //throw new ArgumentNullException(nameof(createRequest.SurgeryType));
                _responseModel.Message = "createRequest.SurgeryType is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(createRequest.SurgeryDate == null)
            {
                //throw new ArgumentNullException(nameof(createRequest.SurgeryDate));
                _responseModel.Message = "createRequest.SurgeryDate is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(createRequest.ConsultedSurgeryTypes == null)
            {
                //throw new ArgumentNullException(nameof(createRequest.ConsultedSurgeryTypes));
                _responseModel.Message = "createRequest.ConsultedSurgeryTypes is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(createRequest.SupplimentedSurgeryTypes == null)
            {
                //throw new ArgumentNullException(nameof(createRequest.SupplimentedSurgeryTypes));
                _responseModel.Message = "createRequest.SupplimentedSurgeryTypes is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(createRequest.AssistantDoctors == null)
            {
                //throw new ArgumentNullException(nameof(createRequest.AssistantDoctors));
                _responseModel.Message = "createRequest.AssistantDoctors is null";
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
                    PreOp preOp = new PreOp(targetWeight: createRequest.TargetWeight, doctorId: createRequest.DoctorId, surgeryType: createRequest.SurgeryType, surgeryDate: createRequest.SurgeryDate, consultedSurgeryTypes: createRequest.ConsultedSurgeryTypes, supplimentedSurgeryTypes: createRequest.SupplimentedSurgeryTypes, assistantDoctors: createRequest.AssistantDoctors, patientUId: createRequest.PatientUId, organizationId: null);
                    //return _preOp.Insert(preOp);
                    _responseModel.Message = "PreOp created successfully";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = _preOp.Insert(preOp);
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
                PreOp preOp = _preOp.GetByUId(uid);
                if(preOp == null)
                {
                    //return null;
                    _responseModel.Message = "PreOp is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }
                else
                {
                    //return _preOp.Delete(preOp);
                    _responseModel.Message = "PreOp deleted successfully";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = _preOp.Delete(preOp);
                    return _responseModel;
                }
            }
        }

        public ResponseModel GetAll()
        {
            ResponseModel _responseModel = new ResponseModel();
            List<PreOp> preOps = _preOp.GetAll();



            //return preOps;
            _responseModel.Message = "PreOps are found";
            _responseModel.Code = HttpStatusCode.OK;
            _responseModel.Data = preOps;
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
                PreOp preOp = _preOp.GetByUId(uid);
                if(preOp == null)
                {
                    //return null;
                    _responseModel.Message = "PreOp is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }
                else
                {
                    //return preOp;
                    _responseModel.Message = "PreOp is found";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = preOp;
                    return _responseModel;
                }
            }
        }

        public ResponseModel Update(PreOpUpdateRequest updateRequest, Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (updateRequest == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest));
                _responseModel.Message = "updateRequest is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.TargetWeight == 0)
            {
                //throw new ArgumentNullException(nameof(updateRequest.TargetWeight));
                _responseModel.Message = "updateRequest.TargetWeight is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;

            }
            else if (string.IsNullOrWhiteSpace(updateRequest.DoctorId))
            {
                //throw new ArgumentNullException(nameof(updateRequest.DoctorId));
                _responseModel.Message = "updateRequest.DoctorId is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.SurgeryType))
            {
                //throw new ArgumentNullException(nameof(updateRequest.SurgeryType));
                _responseModel.Message = "updateRequest.SurgeryType is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.SurgeryDate == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest.SurgeryDate));
                _responseModel.Message = "updateRequest.SurgeryDate is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.ConsultedSurgeryTypes == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest.ConsultedSurgeryTypes));
                _responseModel.Message = "updateRequest.ConsultedSurgeryTypes is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.SupplimentedSurgeryTypes == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest.SupplimentedSurgeryTypes));
                _responseModel.Message = "updateRequest.SupplimentedSurgeryTypes is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (updateRequest.AssistantDoctors == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest.AssistantDoctors));
                _responseModel.Message = "updateRequest.AssistantDoctors is null";
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
                PreOp preOp = _preOp.GetByUId(uid);

                if (preOp == null)
                {
                    //return null;
                    _responseModel.Message = "PreOp is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }

                preOp.TargetWeight = updateRequest.TargetWeight;
                preOp.DoctorId = updateRequest.DoctorId;
                preOp.SurgeryType = updateRequest.SurgeryType;
                preOp.SurgeryDate = updateRequest.SurgeryDate;
                preOp.ConsultedSurgeryTypes = updateRequest.ConsultedSurgeryTypes;
                preOp.SupplimentedSurgeryTypes = updateRequest.SupplimentedSurgeryTypes;

                //return _preOp.Update(preOp);
                _responseModel.Message = "PreOp updated successfully";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = _preOp.Update(preOp);
                return _responseModel;

            }

        }
    }
}
