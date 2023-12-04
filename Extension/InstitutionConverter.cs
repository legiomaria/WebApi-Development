using Demo.Dtos.Institution;
using Demo.Models;

namespace Demo.Extension
{
    public static class InstitutionConverter
    {
        public static InstitutionDto InstitutionToInstitutionDto(this Institution institution)
        {
            return new InstitutionDto ()
            {
                City = institution.City,
                Id = institution.Id,
                Name = institution.Name  
            };
        }
    }
}