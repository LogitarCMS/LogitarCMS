namespace Logitar.Cms.GraphQL;

/// <summary>
/// The settings used to configure GraphQL.
/// </summary>
public class GraphQLSettings
{
  /// <summary>
  /// If true, then GraphQL metrics will be enabled and returned with each response.
  /// </summary>
  public bool EnableMetrics { get; set; }
  /// <summary>
  /// If true, then the Data property of Exception classes will be returned with failed responses.
  /// </summary>
  public bool ExposeErrorData { get; set; }
  /// <summary>
  /// If true, then the Exception details such as the StackTrace will be returned with failed responses.
  /// </summary>
  public bool ExposeExceptionDetails { get; set; }

  /// <summary>
  /// If true, then the Altair GraphQL UI will be enabled to the /ui/altair endpoint.
  /// </summary>
  public bool EnableAltairUi { get; set; }
  /// <summary>
  /// If true, then the GraphiQL GraphQL UI will be enabled to the /ui/graphiql endpoint.
  /// </summary>
  public bool EnableGraphiQLUi { get; set; }
  /// <summary>
  /// If true, then the Playground GraphQL UI will be enabled to the /ui/playground endpoint.
  /// </summary>
  public bool EnablePlaygroundUi { get; set; }
  /// <summary>
  /// If true, then the Voyager GraphQL UI will be enabled to the /ui/voyager endpoint.
  /// </summary>
  public bool EnableVoyagerUi { get; set; }
  /// <summary>
  /// A value indicating whether or not any GraphQL UI are enabled.
  /// </summary>
  public bool AreAnyUiEnabled => EnableAltairUi || EnableGraphiQLUi || EnablePlaygroundUi || EnableVoyagerUi;
}
