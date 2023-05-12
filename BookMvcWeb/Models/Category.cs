﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookMvcWeb.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Display Order")]
    [Range(0, 999)]
    public int DisplayOrder { get; set; }
}
