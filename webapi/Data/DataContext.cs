using Microsoft.EntityFrameworkCore;
using webapi.Entities;

namespace webapi.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<AppUser> Users { get; set; }
  public DbSet<Article> Articles { get; set; }
  public DbSet<ArticleElement> ArticleElements { get; set; }
}
