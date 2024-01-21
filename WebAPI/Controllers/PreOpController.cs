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
    public class PreOpController : BaseController
    {
        private readonly IPreOpService _preOpService;

        public PreOpController(IPreOpService preOpService)
        {
            _preOpService = preOpService;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public IActionResult AddPreOp([FromBody] PreOpCreateRequest preOpCreateRequest)
        {
            //_preOpService.AddPreOp(preOpCreateRequest);
            try
            {
                //var createdPreOp = _preOpService.Add(preOpCreateRequest);
                //return CustomResult(message: "PreOp created successfully", data: createdPreOp, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _preOpService.Add(preOpCreateRequest);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/delete")]
        [AllowAnonymous]
        public IActionResult DeletePreOp([FromRoute] Guid uid)
        {
            try
            {
                //var deletedPreOp = _preOpService.Delete(uid);
                //if (deletedPreOp == null)
                //{
                //    return CustomResult(message: "PreOp is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "PreOp deleted successfully", data: deletedPreOp, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _preOpService.Delete(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("{uid}/update")]
        [AllowAnonymous]
        public IActionResult UpdatePreOp([FromRoute] Guid uid, [FromBody] PreOpUpdateRequest preOpUpdateRequest)
        {
            try
            {
                //var deletedPreOp = _preOpService.Update(preOpUpdateRequest, uid);
                //if (deletedPreOp == null)
                //{
                //    return CustomResult(message: "PreOp is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "PreOp updated successfully", data: deletedPreOp, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _preOpService.Update(preOpUpdateRequest, uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/get")]
        [AllowAnonymous]
        public IActionResult GetPreOp([FromRoute] Guid uid)
        {
            try
            {
                //var preOp = _preOpService.GetByUId(uid);
                //if (preOp == null)
                //{
                //    return CustomResult(message: "PreOp is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "PreOp is found", data: preOp, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _preOpService.GetByUId(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetPreOps()
        {
            try
            {
                //var preOps = _preOpService.GetAll();

                //return CustomResult(message: "PreOps are found", data: preOps, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _preOpService.GetAll();

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }
    }
}
