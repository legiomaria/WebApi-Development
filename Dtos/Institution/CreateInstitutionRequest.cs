using System.ComponentModel.DataAnnotations;

namespace Demo.Dtos.Institution
{
    public class CreateInstitutionRequest
    {
        
        public Guid Id { set; get; } = Guid.NewGuid();

        [Required]
        public string? Name { set; get; }
        
        [Required]
        public string? City { set; get; }
    }
}