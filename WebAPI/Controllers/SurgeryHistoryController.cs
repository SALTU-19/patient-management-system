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
    public class SurgeryHistoryController : BaseController
    {
        private readonly ISurgeryHistoryService _surgeryHistoryService;

        public SurgeryHistoryController(ISurgeryHistoryService surgeryHistoryService)
        {
            _surgeryHistoryService = surgeryHistoryService;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public IActionResult AddSurgeryHistory([FromBody] SurgeryHistoryCreateRequest surgeryHistoryCreateRequest)
        {
            //_surgeryHistoryService.AddSurgeryHistory(surgeryHistoryCreateRequest);
            try
            {
                //var createdSurgeryHistory = _surgeryHistoryService.Add(surgeryHistoryCreateRequest);
                //return CustomResult(message: "SurgeryHistory created successfully", data: createdSurgeryHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _surgeryHistoryService.Add(surgeryHistoryCreateRequest);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/delete")]
        [AllowAnonymous]
        public IActionResult DeleteSurgeryHistory([FromRoute] Guid uid)
        {
            try
            {
                //var deletedSurgeryHistory = _surgeryHistoryService.Delete(uid);
                //if (deletedSurgeryHistory == null)
                //{
                //    return CustomResult(message: "SurgeryHistory is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "SurgeryHistory deleted successfully", data: deletedSurgeryHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _surgeryHistoryService.Delete(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("{uid}/update")]
        [AllowAnonymous]
        public IActionResult UpdateSurgeryHistory([FromRoute] Guid uid, [FromBody] SurgeryHistoryUpdateRequest surgeryHistoryUpdateRequest)
        {
            try
            {
                //var deletedSurgeryHistory = _surgeryHistoryService.Update(surgeryHistoryUpdateRequest, uid);
                //if (deletedSurgeryHistory == null)
                //{
                //    return CustomResult(message: "SurgeryHistory is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "SurgeryHistory updated successfully", data: deletedSurgeryHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _surgeryHistoryService.Update(surgeryHistoryUpdateRequest, uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/get")]
        [AllowAnonymous]
        public IActionResult GetSurgeryHistory([FromRoute] Guid uid)
        {
            try
            {
                //var surgeryHistory = _surgeryHistoryService.GetByUId(uid);
                //if (surgeryHistory == null)
                //{
                //    return CustomResult(message: "SurgeryHistory is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "SurgeryHistory is found", data: surgeryHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _surgeryHistoryService.GetByUId(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetSurgeryHistorys()
        {
            try
            {
                //var surgeryHistorys = _surgeryHistoryService.GetAll();

                //return CustomResult(message: "SurgeryHistorys are found", data: surgeryHistorys, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _surgeryHistoryService.GetAll();

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }
    }
}
