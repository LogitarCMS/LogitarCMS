using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Logitar.Cms.EntityFrameworkCore.PostgreSQL;

/// <summary>
/// The Dependency Injection extension methods used to configure the EntityFrameworkCore.PostgreSQL data store.
/// </summary>
public static class DependencyInjectionExtensions
{
  private const string ConnectionStringKey = "POSTGRESQLCONNSTR_CmsContext";

  /// <summary>
  /// Registers the required dependencies to use an EntityFrameworkCore.PostgreSQL data store to the specified service collection, using the specified configuration.
  /// </summary>
  /// <param name="services">The service collection</param>
  /// <param name="configuration">The configuration where the connection string is read</param>
  /// <returns>The service collection</returns>
  /// <exception cref="InvalidOperationException">The configuration 'POSTGRESQLCONNSTR_CmsContext' is not found</exception>
  public static IServiceCollection AddLogitarCmsEntityFrameworkCorePostgreSQLStore(this IServiceCollection services, IConfiguration configuration)
  {
    string connectionString = configuration.GetValue<string>(ConnectionStringKey)
      ?? throw new InvalidOperationException($"The configuration key '{ConnectionStringKey}' could not be found.");

    return services.AddLogitarCmsEntityFrameworkCorePostgreSQLStore(connectionString);
  }
  /// <summary>
  /// Registers the required dependencies to use an EntityFrameworkCore.PostgreSQL data store to the specified service collection, using the specified PostgreSQL connection string.
  /// </summary>
  /// <param name="services">The service collection</param>
  /// <param name="connectionString">The PostgreSQL connection string</param>
  /// <returns>The service collection</returns>
  public static IServiceCollection AddLogitarCmsEntityFrameworkCorePostgreSQLStore(this IServiceCollection services, string connectionString)
  {
    services.AddDbContext<CmsContext>(options => options.UseNpgsql(connectionString));

    return services;
  }
}
