using Demo.Models;

namespace Demo.Interfaces
{
    public interface IDepartmentService
    {
        Department Add(Department department);
        Department Update(Department department);
        bool Delete(string departmentId);
        Department GetDepartment(string department);
        List<Department> GetDepartments();
        bool IsExist(string department);
    }
}