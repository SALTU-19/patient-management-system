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
    public class IrregularVisitHistoryController : BaseController
    {
        private readonly IIrregularVisitHistoryService _irregularVisitHistoryService;

        public IrregularVisitHistoryController(IIrregularVisitHistoryService irregularVisitHistoryService)
        {
            _irregularVisitHistoryService = irregularVisitHistoryService;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public IActionResult AddIrregularVisitHistory([FromBody] IrregularVisitHistoryCreateRequest irregularVisitHistoryCreateRequest)
        {
            //_irregularVisitHistoryService.AddIrregularVisitHistory(irregularVisitHistoryCreateRequest);
            try
            {
                //var createdIrregularVisitHistory = _irregularVisitHistoryService.Add(irregularVisitHistoryCreateRequest);
                //return CustomResult(message: "IrregularVisitHistory created successfully", data: createdIrregularVisitHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _irregularVisitHistoryService.Add(irregularVisitHistoryCreateRequest);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/delete")]
        [AllowAnonymous]
        public IActionResult DeleteIrregularVisitHistory([FromRoute] Guid uid)
        {
            try
            {
                //var deletedIrregularVisitHistory = _irregularVisitHistoryService.Delete(uid);
                //if (deletedIrregularVisitHistory == null)
                //{
                //    return CustomResult(message: "IrregularVisitHistory is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "IrregularVisitHistory deleted successfully", data: deletedIrregularVisitHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _irregularVisitHistoryService.Delete(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("{uid}/update")]
        [AllowAnonymous]
        public IActionResult UpdateIrregularVisitHistory([FromRoute] Guid uid, [FromBody] IrregularVisitHistoryUpdateRequest irregularVisitHistoryUpdateRequest)
        {
            try
            {
                //var deletedIrregularVisitHistory = _irregularVisitHistoryService.Update(irregularVisitHistoryUpdateRequest, uid);
                //if (deletedIrregularVisitHistory == null)
                //{
                //    return CustomResult(message: "IrregularVisitHistory is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "IrregularVisitHistory updated successfully", data: deletedIrregularVisitHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _irregularVisitHistoryService.Update(irregularVisitHistoryUpdateRequest, uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/get")]
        [AllowAnonymous]
        public IActionResult GetIrregularVisitHistory([FromRoute] Guid uid)
        {
            try
            {
                //var irregularVisitHistory = _irregularVisitHistoryService.GetByUId(uid);
                //if (irregularVisitHistory == null)
                //{
                //    return CustomResult(message: "IrregularVisitHistory is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "IrregularVisitHistory is found", data: irregularVisitHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _irregularVisitHistoryService.GetByUId(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetIrregularVisitHistorys()
        {
            try
            {
                //var irregularVisitHistorys = _irregularVisitHistoryService.GetAll();

                //return CustomResult(message: "IrregularVisitHistorys are found", data: irregularVisitHistorys, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _irregularVisitHistoryService.GetAll();

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }
    }
}
