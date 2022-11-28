using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Category
    {
        [Required]
        public string? Name { get; set; }
        [Key]
        public string? EmpId { get; set; }
        [Required]
        public string? Designation { get; set; }
        [Required]
        public string? BaseDU { get; set; }

    }
}
