using GraphQL.Types;

namespace Logitar.Cms.GraphQL;

internal class RootMutation : ObjectGraphType
{
  public RootMutation()
  {
    Name = nameof(RootMutation);
  }
}
