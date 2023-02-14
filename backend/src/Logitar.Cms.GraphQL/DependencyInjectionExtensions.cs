using GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Logitar.Cms.GraphQL;

/// <summary>
/// The Dependency Injection extension methods used to configure GraphQL usage.
/// </summary>
public static class DependencyInjectionExtensions
{
  /// <summary>
  /// Registers the required dependencies by the GraphQL CMS schema to the specified service collection using the specified GraphQL settings.
  /// </summary>
  /// <param name="services">The service collection</param>
  /// <param name="settings">The GraphQL settings</param>
  /// <returns>The service collection</returns>
  public static IServiceCollection AddGraphQL(this IServiceCollection services, GraphQLSettings? settings = null)
  {
    settings ??= new();

    services.AddGraphQL(builder =>
    {
      builder.AddErrorInfoProvider(options =>
      {
        options.ExposeData = settings.ExposeErrorData;
        options.ExposeExceptionDetails = settings.ExposeExceptionDetails;
      });
      builder.AddGraphTypes(typeof(CmsSchema).Assembly);
      builder.AddSchema<CmsSchema>();
      builder.AddSystemTextJson();
      builder.ConfigureExecutionOptions(options =>
      {
        options.EnableMetrics = settings.EnableMetrics;
        options.UnhandledExceptionDelegate = context => Task.CompletedTask;
      });
    });

    return services;
  }

  /// <summary>
  /// Configures the specified application to use the CMS GraphQL schema.
  /// </summary>
  /// <param name="builder">The application builder</param>
  public static void UseCmsGraphQL(this IApplicationBuilder builder)
  {
    builder.UseGraphQL<CmsSchema>();
  }

  /// <summary>
  /// Configures the specified application to use the GraphQL UIs using the specified GraphQL settings.
  /// </summary>
  /// <param name="builder">The application builder</param>
  /// <param name="settings">The GraphQL settings</param>
  public static void UseGraphQLUi(this IApplicationBuilder builder, GraphQLSettings settings)
  {
    if (settings.EnableAltairUi)
    {
      builder.UseGraphQLAltair();
    }
    if (settings.EnableGraphiQLUi)
    {
      builder.UseGraphQLGraphiQL();
    }
    if (settings.EnablePlaygroundUi)
    {
      builder.UseGraphQLPlayground();
    }
    if (settings.EnableVoyagerUi)
    {
      builder.UseGraphQLVoyager();
    }
  }
}
