using BusinessLayer.Abstract;
using CoreLayer.Dto.Request;
using CoreLayer.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using DataAccessLayer.Abstract;
using System.Net;
using EntityLayer.Concrete;
using CoreLayer.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {

        private readonly IUserDal _userDal;
        private readonly JwtSecurityTokenHandler jwtHandler;
        private readonly string privateAccessKey = "your_private_access_key";
        private readonly string privateRefreshKey = "your_private_refresh_key";
        private readonly int accessExpiresIn = 3600; // 1 hour
        private readonly int refreshExpiresIn = 2592000; // 30 days
        private readonly IConfiguration configuration;

        public AuthManager(IUserDal userDal,  IConfiguration configuration)
        {
            _userDal = userDal;
            jwtHandler = new JwtSecurityTokenHandler();
            this.configuration = configuration;
        }



        public ResponseModel Me()
        {
            throw new NotImplementedException();
        }

        public ResponseModel Refresh()
        {
            throw new NotImplementedException();
        }

        public ResponseModel ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            throw new NotImplementedException();
        }

        public ResponseModel SignIn(SignInRequest signInRequest)
        {
            ResponseModel _responseModel = new ResponseModel();
            if(signInRequest == null)
            {
                _responseModel.Message = "Request is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(signInRequest.Email == null || signInRequest.Password == null)
            {
                _responseModel.Message = "Email or password is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                // get all user data

                List<User> users = _userDal.GetAll();

                // filter by email and found user

                User user = users.Where(x => x.Email == signInRequest.Email).FirstOrDefault();

                // if user is not found

                if(user == null)
                {
                    _responseModel.Message = "Wrong Credentails";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }

                if (user.UserStatusEnum == UserStatusEnum.CREATED)
                {
                    _responseModel.Message = "Email is not verified";
                    _responseModel.Code = HttpStatusCode.BadRequest;
                    return _responseModel;
                }
                else if(user.UserStatusEnum == UserStatusEnum.DELETED)
                {
                    _responseModel.Message = "You are deleted";
                    _responseModel.Code = HttpStatusCode.BadRequest;
                    return _responseModel;
                }



                // compare last password with request password

                bool isPasswordMatch = ComparePassword(password: signInRequest.Password, hash: user.Password);

                // if password is not match
                if(isPasswordMatch == false)
                {
                    _responseModel.Message = "Wrong Credentails";
                    _responseModel.Code = HttpStatusCode.BadRequest;
                    return _responseModel;
                }


                DecodedUserModel decodedUserModel = new DecodedUserModel(userUId: user.UId, email: user.Email, name: user.Name, surname: user.Surname,role: user.Role);

                var tokens = GetTokensAsync(decodedUserModel).Result;

                SignInResponseBody signInResponseBody = new SignInResponseBody(accessToken: tokens.accessToken, refreshToken: tokens.refreshToken,decodedUserModel: decodedUserModel);

                _responseModel.Message = "Logged in sueccessfully";
                _responseModel.Data = signInResponseBody;
                _responseModel.Code = HttpStatusCode.OK;

                return _responseModel;
            }
            
        }

        public ResponseModel SignOut()
        {
            
            throw new NotImplementedException();

        }

        public bool ComparePassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        public async Task<(string accessToken, string refreshToken)> GetTokensAsync(DecodedUserModel decodedUserModel)
        {


            var accessToken = GenerateToken(decodedUserModel, accessExpiresIn);
            var refreshToken = GenerateToken(decodedUserModel, refreshExpiresIn);

            return (accessToken, refreshToken);
        }

        private string GenerateToken(DecodedUserModel decodedUserModel,int expiresIn)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["AppSettings:Secret"]));

            var dateTimeNow = DateTime.UtcNow;

            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: configuration["AppSettings:ValidIssuer"],
                    audience: configuration["AppSettings:ValidAudience"],
                    claims: new List<Claim> {
                        new Claim("userUId", decodedUserModel.UserUId.ToString()),
                        new Claim("email", decodedUserModel.Email),
                        new Claim("name", decodedUserModel.Name),
                        new Claim("surname", decodedUserModel.Surname),
                        new Claim("role", decodedUserModel.Role)
                    },
                    notBefore: dateTimeNow,
                    expires: DateTime.UtcNow.AddSeconds(expiresIn),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
