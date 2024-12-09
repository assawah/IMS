using System.ComponentModel.DataAnnotations;

namespace PM.Models.ViewModels
{
    public class ScopePackageDepartmentViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int? projectId { get; set; }
    }
}
