﻿using CoreLayer.Dto.Request;
using CoreLayer.Dto.Response;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISessionService 
    {
        ResponseModel GetAll();
    }
}