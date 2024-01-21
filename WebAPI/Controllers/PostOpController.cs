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
    public class PostOpController : BaseController
    {
        private readonly IPostOpService _postOpService;

        public PostOpController(IPostOpService postOpService)
        {
            _postOpService = postOpService;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public IActionResult AddPostOp([FromBody] PostOpCreateRequest postOpCreateRequest)
        {
            //_postOpService.AddPostOp(postOpCreateRequest);
            try
            {
                //var createdPostOp = _postOpService.Add(postOpCreateRequest);
                //return CustomResult(message: "PostOp created successfully", data: createdPostOp, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _postOpService.Add(postOpCreateRequest);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/delete")]
        [AllowAnonymous]
        public IActionResult DeletePostOp([FromRoute] Guid uid)
        {
            try
            {
                //var deletedPostOp = _postOpService.Delete(uid);
                //if (deletedPostOp == null)
                //{
                //    return CustomResult(message: "PostOp is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "PostOp deleted successfully", data: deletedPostOp, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _postOpService.Delete(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("{uid}/update")]
        [AllowAnonymous]
        public IActionResult UpdatePostOp([FromRoute] Guid uid, [FromBody] PostOpUpdateRequest postOpUpdateRequest)
        {
            try
            {
                //var deletedPostOp = _postOpService.Update(postOpUpdateRequest, uid);
                //if (deletedPostOp == null)
                //{
                //    return CustomResult(message: "PostOp is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "PostOp updated successfully", data: deletedPostOp, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _postOpService.Update(postOpUpdateRequest, uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/get")]
        [AllowAnonymous]
        public IActionResult GetPostOp([FromRoute] Guid uid)
        {
            try
            {
                //var postOp = _postOpService.GetByUId(uid);
                //if (postOp == null)
                //{
                //    return CustomResult(message: "PostOp is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "PostOp is found", data: postOp, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _postOpService.GetByUId(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetPostOps()
        {
            try
            {
                //var postOps = _postOpService.GetAll();

                //return CustomResult(message: "PostOps are found", data: postOps, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _postOpService.GetAll();

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }
    }
}
