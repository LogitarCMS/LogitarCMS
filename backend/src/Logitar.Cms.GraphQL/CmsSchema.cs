using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Logitar.Cms.GraphQL;

internal class CmsSchema : Schema
{
  public CmsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
  {
    Mutation = serviceProvider.GetRequiredService<RootMutation>();
    Query = serviceProvider.GetRequiredService<RootQuery>();
  }
}
