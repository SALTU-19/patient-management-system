using BusinessLayer.Abstract;
using CoreLayer.Dto.Request;
using CoreLayer.Dto.Response;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {

        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public ResponseModel Add(UserCreateRequest createRequest)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (createRequest == null)
            {
                //throw new ArgumentNullException(nameof(createRequest));
                _responseModel.Message = "createRequest is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.Email))
            {
                //throw new ArgumentNullException(nameof(createRequest.Email));
                _responseModel.Message = "createRequest.Email is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.Name))
            {
                //throw new ArgumentNullException(nameof(createRequest.Name));
                _responseModel.Message = "createRequest.Name is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.Surname))
            {
                //throw new ArgumentNullException(nameof(createRequest.Surname));
                _responseModel.Message = "createRequest.Surname is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.Mobile))
            {
                //throw new ArgumentNullException(nameof(createRequest.Mobile));
                _responseModel.Message = "createRequest.Mobile is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(createRequest.RoleName))
            {
                //throw new ArgumentNullException(nameof(createRequest.RoleUId));
                _responseModel.Message = "createRequest.RoleName is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if(createRequest.Password == null)
            {
                //throw new ArgumentNullException(nameof(createRequest.Password));
                _responseModel.Message = "createRequest.Password is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {


                // hash password


                string hashedPassword = HashPassword(createRequest.Password);

                User user = new User(email: createRequest.Email, name: createRequest.Name, surname: createRequest.Surname, role: createRequest.RoleName, mobile: createRequest.Mobile, userStatusEnum: UserStatusEnum.CONFIRMED, password: hashedPassword,organizationId: null,userImage:null);

                
                

                
                //return user;
                _responseModel.Message = "User created successfully";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = _userDal.Insert(user);
                return _responseModel;
            }
        }

        public ResponseModel Delete(Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (uid == null)
            {
                //throw new ArgumentNullException(nameof(uid));
                _responseModel.Message = "uid is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;

            }
            else
            {
                User user = _userDal.GetByUId(uid);

                if(user == null)
                {
                    //return null;
                    _responseModel.Message = "User is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }

                user.UserStatusEnum = UserStatusEnum.DELETED;

                //return user;
                _responseModel.Message = "User deleted successfully";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = user;
                return _responseModel;
            }
        }

        public ResponseModel GetAll()
        {
            ResponseModel _responseModel = new ResponseModel();
            List<User> users = _userDal.GetAll(); 


  

            //return users;
            _responseModel.Message = "Users are found";            
            _responseModel.Code = HttpStatusCode.OK;
            _responseModel.Data = users;
            return _responseModel;
        }

        public ResponseModel GetByUId(Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (uid == null)
            {
                //throw new ArgumentNullException(nameof(uid));
                _responseModel.Message = "uid is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;

            }
            else
            {
                User user = _userDal.GetByUId(uid);

                if(user == null)
                {
                    //return null;
                    _responseModel.Message = "User is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;
                }

                //return user;
                _responseModel.Message = "User is found";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = user;
                return _responseModel;
            }
        }

        public ResponseModel Update(UserUpdateRequest updateRequest, Guid uid)
        {
            ResponseModel _responseModel = new ResponseModel();
            if (updateRequest == null)
            {
                //throw new ArgumentNullException(nameof(updateRequest));
                _responseModel.Message = "updateRequest is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;

            }
            else if (string.IsNullOrWhiteSpace(updateRequest.Email))
            {
                //throw new ArgumentNullException(nameof(updateRequest.Email));
                _responseModel.Message = "updateRequest.Email is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;

            }
            else if (string.IsNullOrWhiteSpace(updateRequest.Name))
            {
                //throw new ArgumentNullException(nameof(updateRequest.Name));
                _responseModel.Message = "updateRequest.Name is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.Surname))
            {
                //throw new ArgumentNullException(nameof(updateRequest.Surname));
                _responseModel.Message = "updateRequest.Surname is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (string.IsNullOrWhiteSpace(updateRequest.Mobile))
            {
                //throw new ArgumentNullException(nameof(updateRequest.Mobile));
                _responseModel.Message = "updateRequest.Mobile is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else if (uid == Guid.Empty)
            {
                //throw new ArgumentNullException(nameof(uid));
                _responseModel.Message = "uid is null";
                _responseModel.Code = HttpStatusCode.BadRequest;
                return _responseModel;
            }
            else
            {
                User user = _userDal.GetByUId(uid);

                if(user == null)
                {
                    //return null;
                    _responseModel.Message = "User is not found";
                    _responseModel.Code = HttpStatusCode.NotFound;
                    return _responseModel;

                }

                user.Email = updateRequest.Email;
                user.Name = updateRequest.Name;
                user.Surname = updateRequest.Surname;
                user.Mobile = updateRequest.Mobile;




                //return user;
                _responseModel.Message = "User updated successfully";
                _responseModel.Code = HttpStatusCode.OK;
                _responseModel.Data = user;
                return _responseModel;
            }
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
