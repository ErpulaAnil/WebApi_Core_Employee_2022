using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Categories_MvcCore_With_BusinessLayer_6._0.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Display order for category must be greater than 0")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
