using BrSolution.Infrastructure.Helpers;
using System.IO;
using System.Reflection;

namespace BrSolution.Infrastructure.Settings;

public class CoreSetting
{
    public DatabaseSetting DatabaseSetting { get; init; }
    private static string SettingsFilePath { get; }
    public static CoreSetting Instance { get; private set; }
    public  JwtSettings JwtSettings { get; init; }
    static CoreSetting()
    {

        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var solutionRoot = Path.GetFullPath(Path.Combine(baseDirectory, "..\\..\\..\\..\\.."));
        var path = Path.Combine(solutionRoot, "infrastructure", "BrSolution.Infrastructure", "Settings", "settings.core.json");
        SettingsFilePath = path;
        Reload();
    }
    private static void Reload()
    {
        var json = TextFileHelper.ReadAsStringAsync(SettingsFilePath).Result;
        Instance = JsonSerializerHelper.Deserialize<CoreSetting>(json)!;
    }
}

public class JwtSettings
{
    public string SecretKey { get; init; }

    public double ExpireHours { get; init; }
}

public class DatabaseSetting
{
    public string BrSolutionDatabaseConnectionString { get; init; }
}



[Flags]
public enum AllowedFileTypes
{
    Documents = 1,
    Images = 2
}