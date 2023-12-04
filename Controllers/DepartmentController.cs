using System.Net;
using Demo.Interfaces;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(
            IDepartmentService departmentService,
            ILogger<DepartmentController> logger)
        {
            _departmentService = departmentService;
            _logger = logger;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<List<Department>> GetDepartments()
        {
            _logger.LogInformation("Executing GetDepartments");
            return _departmentService.GetDepartments();
        }

        [HttpGet]
        [Route("getbyid/{falcultyId}")]
        public ActionResult<Department> GetDepartment(string falcultyId)
        {
            _logger.LogInformation("Executing GetDepartment");
            if(_departmentService.IsExist(falcultyId))
            {
                return NotFound($"Falculty Id {falcultyId} not found");
            }
            else
            {
                return Ok(_departmentService.GetDepartment(falcultyId));
            }
            
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<Department> AddDepartment([FromBody]Department department)
        {
            _logger.LogInformation("Executing AddDepartment");
            var created = _departmentService.Add(department); 
            return Ok(HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<Department> UpdateDepartment([FromBody]Department department)
        {
            _logger.LogInformation("Executing UpdateDepartment");
            return _departmentService.Update(department);
        }

        [HttpDelete]
        [Route("delete/{departmentId}")]
        public ActionResult<bool> DeleteDepartment(string falcultyId)
        {
            _logger.LogInformation("Executing DeleteDepartment");
           if(_departmentService.IsExist(falcultyId))
           {
               return NotFound($"Falculty Id {falcultyId} not found ");
           }
           else
           {
               return Ok(_departmentService.Delete(falcultyId)); 
           }      
        }
    }
}