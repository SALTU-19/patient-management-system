using CoreLayer.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICrudService<TCreateRequest, TUpdateRequest>
    {
        ResponseModel Add(TCreateRequest createRequest);
        ResponseModel Update(TUpdateRequest updateRequest, Guid uid);
        ResponseModel Delete(Guid uid);
        ResponseModel GetAll();
        ResponseModel GetByUId(Guid uid);
    }
}
