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
    public class DiseaseHistoryController : BaseController
    {
        private readonly IDiseaseHistoryService _diseaseHistoryService;

        public DiseaseHistoryController(IDiseaseHistoryService diseaseHistoryService)
        {
            _diseaseHistoryService = diseaseHistoryService;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public IActionResult AddDiseaseHistory([FromBody] DiseaseHistoryCreateRequest diseaseHistoryCreateRequest)
        {
            //_diseaseHistoryService.AddDiseaseHistory(diseaseHistoryCreateRequest);
            try
            {
                //var createdDiseaseHistory = _diseaseHistoryService.Add(diseaseHistoryCreateRequest);
                //return CustomResult(message: "DiseaseHistory created successfully", data: createdDiseaseHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _diseaseHistoryService.Add(diseaseHistoryCreateRequest);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/delete")]
        [AllowAnonymous]
        public IActionResult DeleteDiseaseHistory([FromRoute] Guid uid)
        {
            try
            {
                //var deletedDiseaseHistory = _diseaseHistoryService.Delete(uid);
                //if (deletedDiseaseHistory == null)
                //{
                //    return CustomResult(message: "DiseaseHistory is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "DiseaseHistory deleted successfully", data: deletedDiseaseHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _diseaseHistoryService.Delete(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("{uid}/update")]
        [AllowAnonymous]
        public IActionResult UpdateDiseaseHistory([FromRoute] Guid uid, [FromBody] DiseaseHistoryUpdateRequest diseaseHistoryUpdateRequest)
        {
            try
            {
                //var deletedDiseaseHistory = _diseaseHistoryService.Update(diseaseHistoryUpdateRequest, uid);
                //if (deletedDiseaseHistory == null)
                //{
                //    return CustomResult(message: "DiseaseHistory is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "DiseaseHistory updated successfully", data: deletedDiseaseHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _diseaseHistoryService.Update(diseaseHistoryUpdateRequest, uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/get")]
        [AllowAnonymous]
        public IActionResult GetDiseaseHistory([FromRoute] Guid uid)
        {
            try
            {
                //var diseaseHistory = _diseaseHistoryService.GetByUId(uid);
                //if (diseaseHistory == null)
                //{
                //    return CustomResult(message: "DiseaseHistory is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "DiseaseHistory is found", data: diseaseHistory, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _diseaseHistoryService.GetByUId(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetDiseaseHistorys()
        {
            try
            {
                //var diseaseHistorys = _diseaseHistoryService.GetAll();

                //return CustomResult(message: "DiseaseHistorys are found", data: diseaseHistorys, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _diseaseHistoryService.GetAll();

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }
    }
}
