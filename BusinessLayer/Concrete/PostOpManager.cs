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
    public class PostOpManager : IPostOpService
    {
        private readonly IPostOpDal _postOp;
        private readonly IPatientDal _patient;
        public PostOpManager(IPostOpDal postOp, IPatientDal patient)
        {
            _postOp = postOp;
            _patient = patient;
        }
        public ResponseModel Add(PostOpCreateRequest createRequest)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (createRequest == null)
            {
                //throw new ArgumentNullException(nameof(createRequest));
                _responseModel.Message = "createRequest is null";
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
            else if (string.IsNullOrWhiteSpace(createRequest.DoctorComment))
            {
                //throw new ArgumentNullException(nameof(createRequest.DoctorId));
                _responseModel.Message = "createRequest.DoctorComment is null";
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
            else if(createRequest.ConsultedMedications == null)
            {
                //throw new ArgumentNullException(nameof(createRequest.ConsultedMedications));
                _responseModel.Message = "createRequest.ConsultedMedications is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(createRequest.SupplimentedMedications == null)
            {
                //throw new ArgumentNullException(nameof(createRequest.SupplimentedMedications));
                _responseModel.Message = "createRequest.SupplimentedMedications is null";
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
                    _responseModel.Message = "Patient is null";
                    _responseModel.Code = HttpStatusCode.BadRequest;
                    return _responseModel;
                }
                else
                {
                    PostOp postOp = new PostOp(doctorId: createRequest.DoctorId, doctorComment: createRequest.DoctorComment, surgeryType: createRequest.SurgeryType, drenaj: createRequest.Drenaj, surgeryDate: createRequest.SurgeryDate, consultedMedications: createRequest.ConsultedMedications, supplimentedMedications: createRequest.SupplimentedMedications, patientUId: createRequest.PatientUId, organizationId: null);
                    //return _postOp.Insert(postOp);
                    _responseModel.Message = "PostOp created successfully";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = _postOp.Insert(postOp);
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
                PostOp postOp = _postOp.GetByUId(uid);

                if(postOp == null)
                {
                    //return null;
                    _responseModel.Message = "PostOp is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }
                else
                {
                    //return _postOp.Delete(postOp);
                    _responseModel.Message = "PostOp deleted successfully";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = _postOp.Delete(postOp);
                    return _responseModel;
                }
            }
        }

        public ResponseModel GetAll()
        {
            ResponseModel _responseModel = new ResponseModel();
            List<PostOp> postOps = _postOp.GetAll();


            //return postOps;
            _responseModel.Message = "PostOps are found";
            _responseModel.Code = HttpStatusCode.OK;
            _responseModel.Data = postOps;
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
                PostOp postOp = _postOp.GetByUId(uid);

                if(postOp == null)
                {
                    //return null;
                    _responseModel.Message = "PostOp is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }
                else
                {
                    //return postOp;
                    _responseModel.Message = "PostOp is found";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = postOp;
                    return _responseModel;
                }
            }
        }

        public ResponseModel Update(PostOpUpdateRequest updateRequest, Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (updateRequest == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest));
                _responseModel.Message = "updateRequest is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;

            }
            else if(string.IsNullOrWhiteSpace(updateRequest.DoctorId))
            {
                //throw new ArgumentNullException(nameof(updateRequest.DoctorId));
                _responseModel.Message = "updateRequest.DoctorId is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;

            }
            else if (string.IsNullOrWhiteSpace(updateRequest.DoctorComment))
            {
                //throw new ArgumentNullException(nameof(updateRequest.DoctorId));
                _responseModel.Message = "updateRequest.DoctorComment is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;

            }
            else if(string.IsNullOrWhiteSpace(updateRequest.SurgeryType))
            {
                //throw new ArgumentNullException(nameof(updateRequest.SurgeryType));
                _responseModel.Message = "updateRequest.SurgeryType is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;

            }
            else if(updateRequest.SurgeryDate == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest.SurgeryDate));
                _responseModel.Message = "updateRequest.SurgeryDate is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(updateRequest.ConsultedMedications == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest.ConsultedMedications));
                _responseModel.Message = "updateRequest.ConsultedMedications is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(updateRequest.SupplimentedMedications == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest.SupplimentedMedications));
                _responseModel.Message = "updateRequest.SupplimentedMedications is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(uid == null)
            {
                //throw new ArgumentNullException(nameof(uid));
                _responseModel.Message = "uid is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                PostOp postOp = _postOp.GetByUId(uid);
                if(postOp == null)
                {
                    //return null;
                    _responseModel.Message = "PostOp is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }
                else
                {
                    postOp.DoctorId = updateRequest.DoctorId;
                    postOp.DoctorComment = updateRequest.DoctorComment;
                    postOp.SurgeryType = updateRequest.SurgeryType;
                    postOp.Drenaj = updateRequest.Drenaj;
                    postOp.SurgeryDate = updateRequest.SurgeryDate;
                    postOp.ConsultedMedications = updateRequest.ConsultedMedications;
                    postOp.SupplimentedMedications = updateRequest.SupplimentedMedications;
                    //return _postOp.Update(postOp);
                    _responseModel.Message = "PostOp updated successfully";
                    _responseModel.Code = HttpStatusCode.OK;
                    _responseModel.Data = _postOp.Update(postOp);
                    return _responseModel;
                }
            }
        }
    }
}
