using Logitar.Cms.Core;
using Microsoft.OpenApi.Models;

namespace Logitar.Cms.Web;

/// <summary>
/// The Dependency Injection extension methods used to configure OpenApi usage.
/// </summary>
public static class OpenApiExtensions
{
  private const string Title = "LogitarCMS API";

  /// <summary>
  /// Registers the required dependencies by the CMS OpenApi specification to the specified service collection.
  /// </summary>
  /// <param name="services">The service collection</param>
  /// <returns>The service collection</returns>
  public static IServiceCollection AddOpenApi(this IServiceCollection services)
  {
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(config =>
    {
      config.SwaggerDoc(name: $"v{Constants.Version.Split('.').First()}", new OpenApiInfo
      {
        Contact = new OpenApiContact
        {
          Email = "francispion@hotmail.com",
          Name = "LogitarCMS Team",
          Url = new Uri("https://github.com/LogitarCMS", UriKind.Absolute)
        },
        Description = "Content management system.",
        License = new OpenApiLicense
        {
          Name = "Use under MIT",
          Url = new Uri("https://github.com/LogitarCMS/LogitarCMS/blob/main/LICENSE", UriKind.Absolute)
        },
        Title = Title,
        Version = $"v{Constants.Version}"
      });
    });

    return services;
  }

  /// <summary>
  /// Configures the specified application to use the Swagger UI.
  /// </summary>
  /// <param name="builder">The application builder</param>
  public static void UseOpenApi(this IApplicationBuilder builder)
  {
    builder.UseSwagger();
    builder.UseSwaggerUI(config => config.SwaggerEndpoint(
      url: $"/swagger/v{Constants.Version.Split('.').First()}/swagger.json",
      name: $"{Title} v{Constants.Version}"
    ));
  }
}
