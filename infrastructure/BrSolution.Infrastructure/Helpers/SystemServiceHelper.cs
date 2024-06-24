using BrSolution.Infrastructure.Settings;

namespace BrSolution.Infrastructure.Helpers;

public static class SystemServiceHelper  
{
    public static string EncryptSystemServiceName(Type systemServiceType)
    {
        var encrypted = SecurityHelper.ComputeSha256Hash(
            $"{CoreSetting.Instance.JwtSettings.SecretKey}-{systemServiceType.FullName!}");

        return encrypted;
    }
}
