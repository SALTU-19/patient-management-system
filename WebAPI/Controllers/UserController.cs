using BusinessLayer.Abstract;
using CoreApiResponse;
using CoreLayer.Dto.Request;
using CoreLayer.Dto.Response;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public IActionResult AddUser([FromBody] UserCreateRequest userCreateRequest)
        {
            //_userService.AddUser(userCreateRequest);
            try
            {
                //var createdUser = _userService.Add(userCreateRequest);
                //return CustomResult(message: "User created successfully", data: createdUser, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _userService.Add(userCreateRequest);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/delete")]
        [AllowAnonymous]
        public IActionResult DeleteUser([FromRoute] Guid uid)
        {
            try
            {
                //var deletedUser = _userService.Delete(uid);
                //if (deletedUser == null)
                //{
                //    return CustomResult(message: "User is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "User deleted successfully", data: deletedUser, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _userService.Delete(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("{uid}/update")]
        [AllowAnonymous]
        public IActionResult UpdateUser([FromRoute] Guid uid, [FromBody] UserUpdateRequest userUpdateRequest)
        {
            try
            {
                //var deletedUser = _userService.Update(userUpdateRequest, uid);
                //if (deletedUser == null)
                //{
                //    return CustomResult(message: "User is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "User updated successfully", data: deletedUser, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _userService.Update(userUpdateRequest, uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/get")]
        [AllowAnonymous]
        public IActionResult GetUser([FromRoute] Guid uid)
        {
            try
            {
                //var user = _userService.GetByUId(uid);
                //if (user == null)
                //{
                //    return CustomResult(message: "User is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "User is found", data: user, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _userService.GetByUId(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetUsers()
        {
            try
            {
                //var users = _userService.GetAll();

                //return CustomResult(message: "Users are found", data: users, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _userService.GetAll();

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }
    }
}
