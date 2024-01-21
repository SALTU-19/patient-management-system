using CoreLayer.Dto.Request;
using CoreLayer.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        ResponseModel SignIn(SignInRequest signInRequest);
        ResponseModel SignOut();
        ResponseModel ResetPassword(ResetPasswordRequest resetPasswordRequest);
        ResponseModel Me();
        ResponseModel Refresh();
    }
}
