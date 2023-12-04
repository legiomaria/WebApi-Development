

using Demo.Interfaces;
using Demo.Models;

namespace Demo.Services
{
    public class InstitutionService : IInstitutionService
    {
        private static List<Institution> institutions = 
        new ()
        {
            new Institution()
            {
                Id = Guid.NewGuid(),
                Name = "Uniben",
                City = "Benin"
            },
            new Institution()
            {
                Id = Guid.NewGuid(),
                Name = "UniPort",
                City = "PortHarCourt"
            }
        };
        public Institution Add(Institution institution)
        {
            institutions.Add(institution);
            return institution;
        }

        public bool Delete(string institutionId)
        {
            var toBeDeleted = institutions
            .Where(m => m.Id.ToString() == institutionId).SingleOrDefault();

            institutions.Remove(toBeDeleted ?? new Institution());

            return true;
        }

        public Institution GetInstitution(string institutionId)
        {
            var existing = institutions
            .Where(m => m.Id.ToString() == institutionId)
            .SingleOrDefault();

            return existing ?? new Institution();
        }

        public List<Institution> GetInstitutions()
        {
            return institutions;
        }

        public bool IsExist(string institutionId)
        {
            var existing = institutions
            .Where(m => m.Id.ToString() == institutionId)
            .SingleOrDefault();

            return existing == null ? true : false;
        }

        public Institution Update(Institution institution)
        {
            Institution updatedInstitution = new Institution();

            foreach(Institution institute in institutions)
            {
                if(institute.Id == institute.Id)
                {
                    institute.City = institution.City;
                    institute.Name = institution.Name;
                    updatedInstitution = institute;
                    break;
                }
            }

            return updatedInstitution;
        }
    }
}