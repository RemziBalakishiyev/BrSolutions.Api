using System.Text.Json;

namespace BrSolution.Infrastructure.Settings;

public static class ResponseMessageManager
{
    private const string JsonFilePath = "..\\..\\infrastructure\\BrSolution.Infrastructure\\Settings\\response.messages.json";

    private static Dictionary<string, string> messages;
    public static string GetResponseMessageByMessageCode(string messageCode)
    {
        if (!string.IsNullOrEmpty(messageCode))
        {
            LoadMessages();
        }

        if (!messageCode.Contains(messageCode))
        {
            throw new KeyNotFoundException($"There is no message by message code={messageCode}");
        }

        return messages[messageCode];
    }


    public static void LoadMessages()
    {

        messages = new Dictionary<string, string>();

        JsonDocumentOptions options = new JsonDocumentOptions
        {
            AllowTrailingCommas = true,
            CommentHandling = JsonCommentHandling.Skip
        };
        using var json = File.OpenRead(JsonFilePath);
        using JsonDocument jsonDocument = JsonDocument.Parse(json, options);

        JsonElement root = jsonDocument.RootElement;
        var properties = root.GetProperty("Messages").EnumerateObject();
        while (properties.MoveNext())
        {
            var prop = properties.Current;
            messages.Add(prop.Name, prop.Value.ToString());
        }
    }
}
