using System.ComponentModel.DataAnnotations;

namespace webapi.DTOs;

public class ArticleDto
{
  [Required]
  [MinLength(1, ErrorMessage = "The article must contain at least one element")]
  public required IEnumerable<ArticleElementDto> Elements { get; set; }
}

public class ArticleElementDto
{
  [Required]
  public required string Type { get; set; }
  [Required]
  public required string Content { get; set; }
  [Required]
  public int Order { get; set; }
}
