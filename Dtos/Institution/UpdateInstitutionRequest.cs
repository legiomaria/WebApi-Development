using System.ComponentModel.DataAnnotations;

namespace Demo.Dtos.Institution
{
    public class UpdateInstitutionRequest
    {
        [Required]
        public Guid Id { set; get; }

        [Required]
        public string? Name { set; get; }
        
        [Required]
        public string? City { set; get; }
    }
}