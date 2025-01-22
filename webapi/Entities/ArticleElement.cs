namespace webapi.Entities;

public class ArticleElement
{
  public int Id { get; set; }
  public int ArticleId { get; set; }
  public required string Type { get; set; }
  public required string Content { get; set; }
  public int Order { get; set; }
}
