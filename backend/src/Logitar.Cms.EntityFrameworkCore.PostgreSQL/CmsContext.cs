using Microsoft.EntityFrameworkCore;

namespace Logitar.Cms.EntityFrameworkCore.PostgreSQL;

/// <summary>
/// The EntityFrameworkCore database context used in the PostgreSQL store.
/// </summary>
public class CmsContext : DbContext
{
  /// <summary>
  /// Initializes a new instance of a CmsContext.
  /// </summary>
  /// <param name="options">The database context options</param>
  public CmsContext(DbContextOptions<CmsContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyConfigurationsFromAssembly(typeof(CmsContext).Assembly);
  }
}
