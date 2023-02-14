using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Logitar.Cms.Core;

public static class DependencyInjectionExtensions
{
  /// <summary>
  /// Registers the required dependencies by the CMS engine to the specified service collection.
  /// </summary>
  /// <param name="services">The service collection</param>
  /// <returns>The service collection</returns>
  public static IServiceCollection AddLogitarCmsCore(this IServiceCollection services)
  {
    Assembly assembly = typeof(DependencyInjectionExtensions).Assembly;

    services.AddMediatR(assembly);

    return services;
  }
}
