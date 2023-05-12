using System.ComponentModel.DataAnnotations;

namespace BookRazorWeb.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Range(0, 999)]
        public int DisplayOrder { get; set; }
    }
}
