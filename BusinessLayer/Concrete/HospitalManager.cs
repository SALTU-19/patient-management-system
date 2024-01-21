using BusinessLayer.Abstract;
using CoreLayer.Dto.Request;
using CoreLayer.Dto.Response;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using OpenQA.Selenium.Interactions.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer.Concrete
{
    public class HospitalManager : IHospitalService
    {
        private readonly IHospitalDal _hospital;
        private readonly IPatientDal _patient;

        public HospitalManager(IHospitalDal hospital, IPatientDal patient)
        {
            _hospital = hospital;
            _patient = patient;
        }
        public ResponseModel Add(HospitalCreateRequest createRequest)
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
            else if (string.IsNullOrWhiteSpace(createRequest.Address))
            {
                //throw new ArgumentNullException(nameof(createRequest.Address));
                _responseModel.Message = "createRequest.Address is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.Mobile))
            {
                //throw new ArgumentNullException(nameof(createRequest.Mobile));
                _responseModel.Message = "createRequest.Mobile is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.ZipCode))
            {
                //throw new ArgumentNullException(nameof(createRequest.ZipCode));
                _responseModel.Message = "createRequest.ZipCode is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.Coordinate))
            {
                //throw new ArgumentNullException(nameof(createRequest.Coordinate));
                _responseModel.Message = "createRequest.Coordinate is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.District))
            {
                //throw new ArgumentNullException(nameof(createRequest.District));
                _responseModel.Message = "createRequest.District is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.District))
            {
                //throw new ArgumentNullException(nameof(createRequest.District));
                _responseModel.Message = "createRequest.District is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.City))
            {
                //throw new ArgumentNullException(nameof(createRequest.City));
                _responseModel.Message = "createRequest.City is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (createRequest.OrganizationId == Guid.Empty)
            {
                //throw new ArgumentNullException(nameof(createRequest.OrganizationId));
                _responseModel.Message = "createRequest.OrganizationId is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }

            else
            {
                //return _hospital.Insert(new Hospital(name: createRequest.Name, coordinate: createRequest.Coordinate, organizationId: createRequest.OrganizationId, address: createRequest.Address, district: createRequest.District, city: createRequest.City, mobile: createRequest.Mobile, zipCode: createRequest.ZipCode, image: createRequest.Image));
                
                _responseModel.Message = "Hospital created successfully";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = _hospital.Insert(new Hospital(name: createRequest.Name, coordinate: createRequest.Coordinate, organizationId: createRequest.OrganizationId, address: createRequest.Address, district: createRequest.District, city: createRequest.City, mobile: createRequest.Mobile, zipCode: createRequest.ZipCode, image: createRequest.Image));
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
                Hospital hospital = _hospital.GetByUId(uid);

                if(hospital == null)
                {
                    //return null;
                    _responseModel.Message = "Hospital is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }

                //return _hospital.Delete(hospital);
                _responseModel.Message = "Hospital deleted successfully";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = _hospital.Delete(hospital);
                return _responseModel;
            }
        }

        public ResponseModel GetAll()
        {
            ResponseModel _responseModel = new ResponseModel();
            List<Hospital> hospitals = _hospital.GetAll();


            //return hospitals;
            _responseModel.Message = "Hospitals are found";
            _responseModel.Code = HttpStatusCode.OK;
            _responseModel.Data = hospitals;
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
                //return _hospital.GetByUId(uid);
                _responseModel.Message = "Hospital is found";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = _hospital.GetByUId(uid);
                return _responseModel;
            }
        }

        public ResponseModel Update(HospitalUpdateRequest updateRequest, Guid uid)
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
            else if (string.IsNullOrWhiteSpace(updateRequest.Address))
            {
                //throw new ArgumentNullException(nameof(updateRequest.Address));
                _responseModel.Message = "updateRequest.Address is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.Mobile))
            {
                //throw new ArgumentNullException(nameof(updateRequest.Mobile));
                _responseModel.Message = "updateRequest.Mobile is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.ZipCode))
            {
                //throw new ArgumentNullException(nameof(updateRequest.ZipCode));
                _responseModel.Message = "updateRequest.ZipCode is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.Coordinate))
            {
                //throw new ArgumentNullException(nameof(updateRequest.Coordinate));
                _responseModel.Message = "updateRequest.Coordinate is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.District))
            {
                //throw new ArgumentNullException(nameof(updateRequest.District));
                _responseModel.Message = "updateRequest.District is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.District))
            {
                //throw new ArgumentNullException(nameof(updateRequest.District));
                _responseModel.Message = "updateRequest.District is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.City))
            {
                //throw new ArgumentNullException(nameof(updateRequest.City));
                _responseModel.Message = "updateRequest.City is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                Hospital hospital = _hospital.GetByUId(uid);

                if(hospital == null)
                {
                    //return null;
                    _responseModel.Message = "Hospital is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }

                hospital.Name = updateRequest.Name;
                hospital.Coordinate = updateRequest.Coordinate;
                hospital.Address = updateRequest.Address;
                hospital.District = updateRequest.District;
                hospital.City = updateRequest.City;
                hospital.Mobile = updateRequest.Mobile;
                hospital.ZipCode = updateRequest.ZipCode;
                hospital.Image = updateRequest.Image;

                //return _hospital.Update(hospital);
                _responseModel.Message = "Hospital updated successfully";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = _hospital.Update(hospital);
                return _responseModel;
            }
        }
    }
}
