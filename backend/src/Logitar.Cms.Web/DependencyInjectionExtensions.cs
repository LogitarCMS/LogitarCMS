using System.Text.Json.Serialization;

namespace Logitar.Cms.Web;

/// <summary>
/// The Dependency Injection extension methods used to configure the CMS Web UI.
/// </summary>
public static class DependencyInjectionExtensions
{
  /// <summary>
  /// Registers the required dependencies by the CMS Web UI to the specified service collection.
  /// </summary>
  /// <param name="services">The service collection</param>
  /// <returns>The service collection</returns>
  public static IServiceCollection AddLogitarCmsWeb(this IServiceCollection services)
  {
    services.AddControllersWithViews()
      .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

    return services;
  }
}
