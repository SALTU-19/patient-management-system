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
    public class DrugHistoryController : BaseController
    {
        private readonly IDrugHistoryService _drugHistoryService;

        public DrugHistoryController(IDrugHistoryService drugHistoryService)
        {
            _drugHistoryService = drugHistoryService;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public IActionResult AddDrugHistory([FromBody] DrugHistoryCreateRequest drugHistoryCreateRequest)
        {
            //_drugHistoryService.AddDrugHistory(drugHistoryCreateRequest);
            try
            {
                //var createdDrugHistory = _drugHistoryService.Add(drugHistoryCreateRequest);
                //return CustomResult(message: "DrugHistory created successfully", data: createdDrugHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _drugHistoryService.Add(drugHistoryCreateRequest);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/delete")]
        [AllowAnonymous]
        public IActionResult DeleteDrugHistory([FromRoute] Guid uid)
        {
            try
            {
                //var deletedDrugHistory = _drugHistoryService.Delete(uid);
                //if (deletedDrugHistory == null)
                //{
                //    return CustomResult(message: "DrugHistory is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "DrugHistory deleted successfully", data: deletedDrugHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _drugHistoryService.Delete(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("{uid}/update")]
        [AllowAnonymous]
        public IActionResult UpdateDrugHistory([FromRoute] Guid uid, [FromBody] DrugHistoryUpdateRequest drugHistoryUpdateRequest)
        {
            try
            {
                //var deletedDrugHistory = _drugHistoryService.Update(drugHistoryUpdateRequest, uid);
                //if (deletedDrugHistory == null)
                //{
                //    return CustomResult(message: "DrugHistory is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "DrugHistory updated successfully", data: deletedDrugHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _drugHistoryService.Update(drugHistoryUpdateRequest, uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/get")]
        [AllowAnonymous]
        public IActionResult GetDrugHistory([FromRoute] Guid uid)
        {
            try
            {
                //var drugHistory = _drugHistoryService.GetByUId(uid);
                //return CustomResult(message: "DrugHistory is found", data: drugHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _drugHistoryService.GetByUId(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetDrugHistorys()
        {
            try
            {
                //var drugHistorys = _drugHistoryService.GetAll();
                //if (drugHistorys == null)
                //{
                //    return CustomResult(message: "DrugHistorys are not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "DrugHistorys are found", data: drugHistorys, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _drugHistoryService.GetAll();

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }
    }
}
