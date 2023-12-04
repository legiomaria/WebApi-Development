using Demo.Interfaces;
using Demo.Models;

namespace Demo.Services
{
    public class DepartmentService : IDepartmentService
    {
        private static List<Department> departments = 
        new ()
        {
            new Department()
            {
                Id = Guid.NewGuid(),
                Name = "Chemical Engineering",
                Code = "CHEE",
                FalcultyId = 4
            },
            new Department()
            {
                Id = Guid.NewGuid(),
                Name = "BioChemistry",
                Code = "BIOCHEM",
                FalcultyId = 9
            }
        };
        public Department Add(Department department)
        {
            departments.Add(department);
            return department;
        }

        public bool Delete(string falcultyId)
        {
            var toBeDeleted = departments
            .Where(m => m.Id.ToString() == falcultyId).SingleOrDefault();

            departments.Remove(toBeDeleted ?? new Department());

            return true;
        }

        public Department GetDepartment(string falcultyId)
        {
            var existing = departments
            .Where(m => m.Id.ToString() == falcultyId)

            .SingleOrDefault();

            return existing ?? new Department();
        }

        public List<Department> GetDepartments()
        {
            return departments;
        }

        public bool IsExist(string falcultyId)
        {
            var existing = departments
            .Where(m => m.Id.ToString() == falcultyId)
            .SingleOrDefault();

            return existing == null ? true : false;
        }

        public Department Update(Department department)
        {
            Department updatedDepartment = new Department();

           foreach(Department dept in departments)
           {
                if(dept.Id == department.Id)
                {
                    dept.Code = department.Code;
                    dept.Name = department.Name;
                    dept.FalcultyId = department.FalcultyId;
                    updatedDepartment = dept;
                    break;
                }
           }

           return updatedDepartment;
        }
    }
}