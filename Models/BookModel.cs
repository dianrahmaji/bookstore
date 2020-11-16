using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
  public class BookModel
  {
    public int Id { get; set; }
    [StringLength(100, MinimumLength = 5)]
    [Required]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    [StringLength(500)]
    public string Description { get; set; }
    public string Category { get; set; }
    [Required(ErrorMessage = "Please enter the total pages.")]
    [Display(Name = "Total Pages")]
    public int? TotalPages { get; set; }
    [Required]
    public string Language { get; set; }
  }
}
