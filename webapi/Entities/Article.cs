namespace webapi.Entities;

public class Article
{
  public int Id { get; set; }
  public required ArticleElement[] Elements { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}
