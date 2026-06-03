using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}
