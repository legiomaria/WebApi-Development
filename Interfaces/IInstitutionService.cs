using Demo.Models;

namespace Demo.Interfaces
{
    public interface IInstitutionService
    {
        Institution Add(Institution institution);
        Institution Update(Institution institution);
        bool Delete(string institutionId);
        Institution GetInstitution(string institution);
        List<Institution> GetInstitutions();
        bool IsExist(string institution);     
    }
}