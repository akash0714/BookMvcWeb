using System.ComponentModel.DataAnnotations;

namespace BookMvcWeb.Models;

public class Category
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
}
