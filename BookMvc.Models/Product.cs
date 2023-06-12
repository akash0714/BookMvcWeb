using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMvc.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string Author { get; set; } = string.Empty;
        
        [Required]
        [DisplayName("Unit Price")]
        [Range(10, 575)]
        public double UnitPrice { get; set; }
        
        public double Price50 { get; set; }
        
        public double Price100 { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        [DisplayName("Category")]
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
