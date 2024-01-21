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
    public class PeriodicVisitHistoryController : BaseController
    {
        private readonly IPeriodicVisitHistoryService _periodicVisitHistoryService;

        public PeriodicVisitHistoryController(IPeriodicVisitHistoryService periodicVisitHistoryService)
        {
            _periodicVisitHistoryService = periodicVisitHistoryService;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public IActionResult AddPeriodicVisitHistory([FromBody] PeriodicVisitHistoryCreateRequest periodicVisitHistoryCreateRequest)
        {
            //_periodicVisitHistoryService.AddPeriodicVisitHistory(periodicVisitHistoryCreateRequest);
            try
            {
                //var createdPeriodicVisitHistory = _periodicVisitHistoryService.Add(periodicVisitHistoryCreateRequest);
                //return CustomResult(message: "PeriodicVisitHistory created successfully", data: createdPeriodicVisitHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _periodicVisitHistoryService.Add(periodicVisitHistoryCreateRequest);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/delete")]
        [AllowAnonymous]
        public IActionResult DeletePeriodicVisitHistory([FromRoute] Guid uid)
        {
            try
            {
                //var deletedPeriodicVisitHistory = _periodicVisitHistoryService.Delete(uid);
                //if (deletedPeriodicVisitHistory == null)
                //{
                //    return CustomResult(message: "PeriodicVisitHistory is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "PeriodicVisitHistory deleted successfully", data: deletedPeriodicVisitHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _periodicVisitHistoryService.Delete(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("{uid}/update")]
        [AllowAnonymous]
        public IActionResult UpdatePeriodicVisitHistory([FromRoute] Guid uid, [FromBody] PeriodicVisitHistoryUpdateRequest periodicVisitHistoryUpdateRequest)
        {
            try
            {
                //var deletedPeriodicVisitHistory = _periodicVisitHistoryService.Update(periodicVisitHistoryUpdateRequest, uid);
                //if (deletedPeriodicVisitHistory == null)
                //{
                //    return CustomResult(message: "PeriodicVisitHistory is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "PeriodicVisitHistory updated successfully", data: deletedPeriodicVisitHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _periodicVisitHistoryService.Update(periodicVisitHistoryUpdateRequest, uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/get")]
        [AllowAnonymous]
        public IActionResult GetPeriodicVisitHistory([FromRoute] Guid uid)
        {
            try
            {
                //var periodicVisitHistory = _periodicVisitHistoryService.GetByUId(uid);
                //if (periodicVisitHistory == null)
                //{
                //    return CustomResult(message: "PeriodicVisitHistory is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "PeriodicVisitHistory is found", data: periodicVisitHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _periodicVisitHistoryService.GetByUId(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetPeriodicVisitHistorys()
        {
            try
            {
                //var periodicVisitHistorys = _periodicVisitHistoryService.GetAll();

                //return CustomResult(message: "PeriodicVisitHistorys are found", data: periodicVisitHistorys, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _periodicVisitHistoryService.GetAll();

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }
    }
}
