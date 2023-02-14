using System.Text;

namespace Logitar.Cms;

internal class DatabaseProviderNotSupportedException : NotSupportedException
{
  public DatabaseProviderNotSupportedException(DatabaseProvider provider) : base(GetMessage(provider))
  {
    Data["Provider"] = provider;
  }

  private static string GetMessage(DatabaseProvider provider)
  {
    StringBuilder message = new();

    message.AppendLine($"The database provider '{provider}' is not supported. Only the following providers are supported:");

    foreach (DatabaseProvider value in Enum.GetValues<DatabaseProvider>().OrderBy(x => x.ToString()))
    {
      message.AppendLine($" - {value}");
    }

    return message.ToString();
  }
}
