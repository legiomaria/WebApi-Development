using Demo.Interfaces;
using Demo.Models;

namespace Demo.Services
{
    public class CourseService : ICourseService
    {
        private static List<Course> courses = 
        new ()
        {
            new Course()
            {
                Id = Guid.NewGuid(),
                Name = "Economics",
                Code = "EC001",
                DepartmentId = 1
            },
            new Course()
            {
                Id = Guid.NewGuid(),
                Name = "Sciology",
                Code = "SC002",
                DepartmentId = 2
            }
        }; 
        public Course Add(Course course)
        {
            courses.Add(course);
            return course;
        }

        public bool Delete(string departmentId)
        {
            var toBeDeleted = courses
            .Where(m => m.Id.ToString() == departmentId).SingleOrDefault();

            courses.Remove(toBeDeleted ?? new Course());

            return true;
        }

        public Course GetCourse(string departmentId)
        {
            var existing = courses
            .Where(m => m.Id.ToString() == departmentId)
            .SingleOrDefault();

            return existing ?? new Course();

        }

        public List<Course> GetCourses()
        {
            return courses;
        }

        public bool IsExist(string departmentId)
        {
            var existing = courses
            .Where(m => m.Id.ToString() == departmentId)
            .SingleOrDefault();

            return existing == null ? true : false;
        }

        public Course Update(Course course)
        {
            Course updatedCourse = new Course();

           foreach(Course cos in courses)
           {
                if(cos.Id == course.Id)
                {
                    cos.Name = course.Name;
                    cos.Code = course.Code;
                    cos.DepartmentId = course.DepartmentId;
                    updatedCourse = cos;
                    break;
                }
           }

           return updatedCourse;
        }
    }
}