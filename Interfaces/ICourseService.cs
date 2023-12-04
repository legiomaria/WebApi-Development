using Demo.Models;

namespace Demo.Interfaces
{
    public interface ICourseService
    {
        Course Add(Course course);
        Course Update(Course course);
        bool Delete(string departmentId);
        Course GetCourse(string course);
        List<Course> GetCourses();
        bool IsExist(string course);
        
    }
}