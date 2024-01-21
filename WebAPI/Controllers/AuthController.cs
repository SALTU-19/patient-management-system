using BusinessLayer.Abstract;
using CoreApiResponse;
using CoreLayer.Dto.Request;
using CoreLayer.Dto.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signin")]
        [AllowAnonymous]
        public IActionResult SignIn([FromBody] SignInRequest signInRequest)
        {
            try
            {
                ResponseModel _responseModel = _authService.SignIn(signInRequest);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("signout")]
        [AllowAnonymous]
        public IActionResult SignOut()
        {
            try
            {
                ResponseModel _responseModel = _authService.SignOut();

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequest resetPasswordRequest)
        {
            try
            {
                ResponseModel _responseModel = _authService.ResetPassword(resetPasswordRequest);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("me")]
        [Authorize]
        public IActionResult Me()
        {
            try
            {

                var userClaims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();

                ResponseModel _responseModel = new ResponseModel
                {
                    Data = userClaims,
                    Message = "User Information",
                    Code = HttpStatusCode.OK
                };

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("refresh")]
        [Authorize]
        public IActionResult Refresh()
        {
            try
            {
                ResponseModel _responseModel = _authService.Refresh();

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }
    }
}
