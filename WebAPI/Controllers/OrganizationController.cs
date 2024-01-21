using BusinessLayer.Abstract;
using CoreApiResponse;
using CoreLayer.Dto.Request;
using CoreLayer.Dto.Response;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : BaseController
    {
        private readonly IOrganizationService _organizationService;


        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public IActionResult AddOrganization([FromBody] OrganizationCreateRequest organizationCreateRequest)
        {
            //ResponseModel _responseModel = new ResponseModel();
            try
            {
                //var createdOrganization = _organizationService.Add(organizationCreateRequest);
                ResponseModel _responseModel = _organizationService.Add(organizationCreateRequest);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);

                //return CustomResult(message: "Organization created successfully", data: createdOrganization, code: HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/delete")]
        [AllowAnonymous]
        public IActionResult DeleteOrganization([FromRoute] Guid uid)
        {
            try
            {
                //var deletedOrganization = _organizationService.Delete(uid);
                //if (deletedOrganization == null)
                //{
                //    return CustomResult(message: "Organization is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "Organization deleted successfully", data: deletedOrganization, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _organizationService.Delete(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("{uid}/update")]
        [AllowAnonymous]
        public IActionResult UpdateOrganization([FromRoute] Guid uid, [FromBody] OrganizationUpdateRequest organizationUpdateRequest)
        {
            try
            {
                //var deletedOrganization = _organizationService.Update(organizationUpdateRequest,uid);
                //if (deletedOrganization == null)
                //{
                //    return CustomResult(message: "Organization is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "Organization updated successfully", data: deletedOrganization, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _organizationService.Update(organizationUpdateRequest, uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/get")]
        [AllowAnonymous]
        public IActionResult GetOrganization([FromRoute] Guid uid)
        {
             try { 
                 //var organization = _organizationService.GetByUId(uid);
                 //if (organization == null)
                 //{
                 //    return CustomResult(message: "Organization is not found", code: HttpStatusCode.NotFound);
                 //}
                 //return CustomResult(message: "Organization is found", data: organization, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _organizationService.GetByUId(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
             catch (Exception ex)
            {
                 return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetOrganizations()
        {
             try
             {
                 //var organizations = _organizationService.GetAll();

                 //return CustomResult(message: "Organizations are found", data: organizations, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _organizationService.GetAll();

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
             }
             catch (Exception ex)
             {
                 return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
             }
        }
    }
}
