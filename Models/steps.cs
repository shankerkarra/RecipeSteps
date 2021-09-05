using System;
using System.ComponentModel.DataAnnotations;
namespace RecipeSteps.Models
{
  public class steps
  {
    public int id { get; set; }
    [Required]
    public string body { get; set; }
    [Required]
    public int recipeId { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public string creatorId { get; set; }

  }
}