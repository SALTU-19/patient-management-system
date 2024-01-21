using BusinessLayer.Abstract;
using CoreLayer.Dto.Request;
using CoreLayer.Dto.Response;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OrganizationManager : IOrganizationService
    {
        private readonly IOrganizationDal _organizationDal;

        public OrganizationManager(IOrganizationDal organizationDal)
        {
            _organizationDal = organizationDal;
        }

        public ResponseModel Add(OrganizationCreateRequest organizationCreateRequest)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (organizationCreateRequest == null)
            {
                _responseModel.Message = "organizationCreateRequest is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(organizationCreateRequest.Name))
            {
                //throw new ArgumentNullException(nameof(organizationCreateRequest.Name));
                _responseModel.Message = "organizationCreateRequest.Name is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                // Perform the creation logic
                _responseModel.Message = "Organization created successfully";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = _organizationDal.Insert(new Organization(name: organizationCreateRequest.Name));
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
                Organization organization = _organizationDal.GetByUId(uid);

                if (organization == null)
                {
                    //return null;
                    _responseModel.Message = "Organization is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }

                // Perform the deletion logic
                //return _organizationDal.Delete(organization);
                _responseModel.Message = "Organization deleted successfully";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = _organizationDal.Delete(organization);
                return _responseModel;
            }
        }
        public ResponseModel GetByUId(Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            Organization organization = _organizationDal.GetByUId(uid);

            if (organization == null)
            {
                //return null;
                _responseModel.Message = "Organization is not found";
                _responseModel.Code = HttpStatusCode.NotFound;
                return _responseModel;
            }
            //return organization;
            _responseModel.Message = "Organization is found";
            _responseModel.Code = HttpStatusCode.OK;
            _responseModel.Data = organization;
            return _responseModel;
        }

        public ResponseModel GetAll()
        {
            ResponseModel _responseModel = new ResponseModel();
            List<Organization> organizations = _organizationDal.GetAll();

            _responseModel.Message = "Organizations are found";
            _responseModel.Code = HttpStatusCode.OK;
            _responseModel.Data = organizations;
            return _responseModel;
        }

        public ResponseModel Update(OrganizationUpdateRequest organizationUpdateRequest, Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (organizationUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(organizationUpdateRequest));
            }
            else if (string.IsNullOrWhiteSpace(organizationUpdateRequest.Name))
            {
                throw new ArgumentNullException(nameof(organizationUpdateRequest.Name));
            }
            else
            {
                Organization organization = _organizationDal.GetByUId(uid);

                if (organization == null)
                {
                    //return null;
                    _responseModel.Message = "Organization is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;

                }

                // Perform the update logic
                organization.Name = organizationUpdateRequest.Name;
                //return _organizationDal.Update(organization);
                _responseModel.Message = "Organization updated successfully";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = _organizationDal.Update(organization);
                return _responseModel;
            }
        }
    }
}
