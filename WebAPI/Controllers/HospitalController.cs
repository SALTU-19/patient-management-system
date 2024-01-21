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
    public class HospitalController : BaseController
    {
        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public IActionResult AddHospital([FromBody] HospitalCreateRequest hospitalCreateRequest)
        {
            //_hospitalService.AddHospital(hospitalCreateRequest);
            try
            {
                //var createdHospital = _hospitalService.Add(hospitalCreateRequest);
                //return CustomResult(message: "Hospital created successfully", data: createdHospital, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _hospitalService.Add(hospitalCreateRequest);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/delete")]
        [AllowAnonymous]
        public IActionResult DeleteHospital([FromRoute] Guid uid)
        {
            try
            {
                //var deletedHospital = _hospitalService.Delete(uid);
                //if (deletedHospital == null)
                //{
                //    return CustomResult(message: "Hospital is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "Hospital deleted successfully", data: deletedHospital, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _hospitalService.Delete(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("{uid}/update")]
        [AllowAnonymous]
        public IActionResult UpdateHospital([FromRoute] Guid uid, [FromBody] HospitalUpdateRequest hospitalUpdateRequest)
        {
            try
            {
                //var deletedHospital = _hospitalService.Update(hospitalUpdateRequest, uid);
                //if (deletedHospital == null)
                //{
                //    return CustomResult(message: "Hospital is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "Hospital updated successfully", data: deletedHospital, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _hospitalService.Update(hospitalUpdateRequest, uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/get")]
        [AllowAnonymous]
        public IActionResult GetHospital([FromRoute] Guid uid)
        {
            try
            {
                //var hospital = _hospitalService.GetByUId(uid);
                //if (hospital == null)
                //{
                //    return CustomResult(message: "Hospital is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "Hospital is found", data: hospital, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _hospitalService.GetByUId(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetHospitals()
        {
            try
            {
                //var hospitals = _hospitalService.GetAll();

                //return CustomResult(message: "Hospitals are found", data: hospitals, code: HttpStatusCode.OK);


                ResponseModel _responseModel = _hospitalService.GetAll();

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }
    }
}
