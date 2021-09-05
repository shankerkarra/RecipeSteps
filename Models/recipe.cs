using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeSteps.Models
{
  public class recipe
  {

    public int id { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(25)]
    public string title { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(25)]
    public string description { get; set; }
    [Required]
    public int cooktime { get; set; } = 1;
    [Required]
    public int prepTime { get; set; } = 1;
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    [Required]
    public string creatorId { get; set; }

  }
}


