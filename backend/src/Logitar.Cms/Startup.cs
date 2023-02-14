using Logitar.Cms.Core;
using Logitar.Cms.EntityFrameworkCore.PostgreSQL;
using Logitar.Cms.GraphQL;
using Logitar.Cms.Web;

namespace Logitar.Cms;

internal class Startup : StartupBase
{
  private readonly IConfiguration _configuration;
  private readonly bool _enableOpenApi;
  private readonly GraphQLSettings _graphQLSettings;

  public Startup(IConfiguration configuration)
  {
    _configuration = configuration;
    _enableOpenApi = _configuration.GetValue<bool>("EnableOpenApi");
    _graphQLSettings = configuration.GetSection("GraphQL").Get<GraphQLSettings>() ?? new();
  }

  public override void ConfigureServices(IServiceCollection services)
  {
    base.ConfigureServices(services);

    services.AddLogitarCmsCore();
    services.AddLogitarCmsWeb();

    services.AddApplicationInsightsTelemetry();
    IHealthChecksBuilder healthChecks = services.AddHealthChecks();

    services.AddGraphQL(_graphQLSettings);

    if (_enableOpenApi)
    {
      services.AddOpenApi();
    }

    DatabaseProvider databaseProvider = _configuration.GetValue<DatabaseProvider>("DatabaseProvider");
    switch (databaseProvider)
    {
      case DatabaseProvider.EntityFrameworkCorePostgreSQL:
        services.AddLogitarCmsEntityFrameworkCorePostgreSQLStore(_configuration);
        healthChecks.AddDbContextCheck<CmsContext>();
        break;
      default:
        throw new DatabaseProviderNotSupportedException(databaseProvider);
    }
  }

  public override void Configure(IApplicationBuilder builder)
  {
    if (_graphQLSettings.AreAnyUiEnabled)
    {
      builder.UseGraphQLUi(_graphQLSettings);
    }

    if (_enableOpenApi)
    {
      builder.UseOpenApi();
    }

    builder.UseHttpsRedirection();
    builder.UseStaticFiles();
    builder.UseCmsGraphQL();

    if (builder is WebApplication application)
    {
      application.MapControllers();
    }
  }
}
