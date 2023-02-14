using GraphQL.Types;

namespace Logitar.Cms.GraphQL;

internal class RootQuery : ObjectGraphType
{
  public RootQuery()
  {
    Name = nameof(RootQuery);
  }
}
