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
    public class PatientController : BaseController
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public IActionResult AddPatient([FromBody] PatientCreateRequest patientCreateRequest)
        {
            //_patientService.AddPatient(patientCreateRequest);
            try
            {
                //var createdPatient = _patientService.Add(patientCreateRequest);
                //return CustomResult(message: "Patient created successfully", data: createdPatient, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _patientService.Add(patientCreateRequest);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/delete")]
        [AllowAnonymous]
        public IActionResult DeletePatient([FromRoute] Guid uid)
        {
            try
            {
                //var deletedPatient = _patientService.Delete(uid);
                //if (deletedPatient == null)
                //{
                //    return CustomResult(message: "Patient is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "Patient deleted successfully", data: deletedPatient, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _patientService.Delete(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("{uid}/update")]
        [AllowAnonymous]
        public IActionResult UpdatePatient([FromRoute] Guid uid, [FromBody] PatientUpdateRequest patientUpdateRequest)
        {
            try
            {
                //var deletedPatient = _patientService.Update(patientUpdateRequest, uid);
                //if (deletedPatient == null)
                //{
                //    return CustomResult(message: "Patient is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "Patient updated successfully", data: deletedPatient, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _patientService.Update(patientUpdateRequest, uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{uid}/get")]
        [AllowAnonymous]
        public IActionResult GetPatient([FromRoute] Guid uid)
        {
            try
            {
                //var patient = _patientService.GetByUId(uid);
                //if (patient == null)
                //{
                //    return CustomResult(message: "Patient is not found", code: HttpStatusCode.NotFound);
                //}
                //return CustomResult(message: "Patient is found", data: patient, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _patientService.GetByUId(uid);

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetPatients()
        {
            try
            {
                //var patients = _patientService.GetAll();

                //return CustomResult(message: "Patients are found", data: patients, code: HttpStatusCode.OK);

                ResponseModel _responseModel = _patientService.GetAll();

                return CustomResult(message: _responseModel.Message, data: _responseModel.Data, code: _responseModel.Code);
            }
            catch (Exception ex)
            {
                return CustomResult(message: ex.Message, code: HttpStatusCode.BadRequest);
            }
        }
    }
}
