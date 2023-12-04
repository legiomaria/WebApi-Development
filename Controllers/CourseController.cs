using System.Net;
using Demo.Interfaces;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ILogger<CourseController> _logger;
        public CourseController(
            ICourseService courseService,
            ILogger<CourseController> logger)
        {
            _courseService = courseService;
            _logger = logger;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<List<Course>> GetCourses()
        {
            _logger.LogInformation("Executing GetCourses");
            return _courseService.GetCourses();
        }

        [HttpGet]
        [Route("getbyid/{departmentId}")]
        public ActionResult<Course> GetCourse(string departmentId)
        {
            _logger.LogInformation("Executing GetCourse");
            if(_courseService.IsExist(departmentId))
            {
                return NotFound($"Department Id {departmentId} not found");
            }
            else
            {
                return Ok(_courseService.GetCourse(departmentId));
            }
            
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<Course> AddCourse([FromBody]Course course)
        {
            _logger.LogInformation("Executing AddCourse");
            var created = _courseService.Add(course);
            return Ok(HttpStatusCode.Created); 
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<Course> UpdateCourse([FromBody]Course course)
        {
            return _courseService.Update(course);
        }

        [HttpDelete]
        [Route("delete/{departmentId}")]
        public ActionResult<bool> DeleteCourse([FromBody]string departmentId)
        {
            _logger.LogInformation("Executing DeleteCourse");

            if(_courseService.IsExist(departmentId))
            {
               return NotFound($"Department Id {departmentId} not found");
            }
            else
            {
              return Ok(_courseService.Delete(departmentId));
            }      
        }
    }
}