using System.Net;
using Demo.Dtos;
using Demo.Dtos.Institution;
using Demo.Extension;
using Demo.Interfaces;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionService _institutionService;
        private readonly ILogger<InstitutionController> _logger;
        public InstitutionController(
            IInstitutionService institutionService,
            ILogger<InstitutionController> logger)
        {
            _institutionService = institutionService;
            _logger = logger;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<List<Institution>> GetInstitutions()
        {
            _logger.LogInformation("Executing GetInstitution");
            return _institutionService.GetInstitutions();
        }

        [HttpGet]
        [Route("getbyid/{institutionId}")]
        public ActionResult<GenericResponse<InstitutionDto>> GetInstitution(string institutionId)
        {
            _logger.LogInformation("Executing GetInstitution");
            if(_institutionService.IsExist(institutionId))
            {
                return NotFound($"Institution Id  { institutionId } not found");
            }
            else
            {
                var result = new GenericResponse<InstitutionDto>()
                {
                    Code = "200",
                    Message = "Success",
                    Result = _institutionService
                    .GetInstitution(institutionId).InstitutionToInstitutionDto()
                    
                };

                return Ok(result);
            }
           
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<Institution> AddInstitution(
            [FromBody]CreateInstitutionRequest institutionReq)
        {
            _logger.LogInformation("Executing AddInstitution");

            if(!ModelState.IsValid)
            {
               return BadRequest();
            }

            var newInstitution = new Institution
            {
                City = institutionReq.City,
                Name = institutionReq.Name,
                Id = institutionReq.Id  
            }; 
            var created = _institutionService.Add(newInstitution);
            return Ok(HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<Institution> UpdateInstitution(
            [FromBody]UpdateInstitutionRequest institutionReq)
        {
            _logger.LogInformation("Executing UpdateInstitution");

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }   

            var UpdateInstitution = new Institution
            {
                City = institutionReq.City,
                Name = institutionReq.Name,
                Id = institutionReq.Id
            }; 

            return _institutionService.Update(UpdateInstitution);
        }

        [HttpDelete]
        [Route("delete/{institutionId}")]
        public ActionResult<bool>  DeleteInstitution(string institutionId)
        {
            _logger.LogInformation("Executing DeleteInstitution");

            if(_institutionService.IsExist(institutionId))
            {
               return NotFound($"Institution Id { institutionId } not found");
            }
            else
            {
                return Ok(_institutionService.Delete(institutionId));
            }     
            
        }
    }
}