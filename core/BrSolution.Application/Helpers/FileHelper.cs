using BrSolution.Application.Exceptions;
using BrSolution.Application.Wrappers;
using BrSolution.Infrastructure.Settings;

namespace BrSolution.Application.Helpers
{
    public static class FileHelper
    {
        private static readonly string BaseDirectory;
        private static readonly string AppBaseDirectory;

        static FileHelper()
        {
            BaseDirectory = CoreSetting.Instance.UploadSettings.BasePath;
            AppBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        }
        public static void SaveStream(
             FileContentWrapper fileContent,
             string mainFolder,
             AllowedFileTypes allowedFileTypes,
             out string relativeFilePath)
        {
            var extension = Path.GetExtension(fileContent.FileName).ToLower();

            ThrowIfIncorrectFileFormat(extension, fileContent.ContentType, allowedFileTypes);

            relativeFilePath = Path.Combine(
                BaseDirectory,
                mainFolder,
                $"{Guid.NewGuid()}{extension}");

            using (fileContent.Stream)
            {
                var absolutePath = Path.Combine(AppBaseDirectory, relativeFilePath);

                Directory.CreateDirectory(absolutePath[..absolutePath.LastIndexOf('\\')]);

                using var fs = new FileStream(absolutePath, FileMode.CreateNew);
                fileContent.Stream.CopyTo(fs);

                fs.Close();

                fileContent.Stream.Close();
            }
        }

        public static void DeleteFile(string relativeFilePath)
        {
            File.Delete(Path.Combine(AppBaseDirectory, relativeFilePath));
        }

        public static FileContentWrapper GetFileContent(string relativeFilePath)
        {
            var fs = new FileStream(
                Path.Combine(AppBaseDirectory, relativeFilePath),
                FileMode.Open,
                FileAccess.Read);
            var extension = Path.GetExtension(relativeFilePath);
            var fileName = Path.GetFileName(relativeFilePath);

            return new FileContentWrapper
            {
                Stream = fs,
                ContentType = CoreSetting.Instance.AllAllowedFileTypes[extension],
                FileName = fileName
            };
        }

        private static void ThrowIfIncorrectFileFormat(
            string extension,
            string contentType,
            AllowedFileTypes allowedFileTypes)
        {
            foreach (var fileTypeValue in Enum.GetValues<AllowedFileTypes>())
            {
                if ((fileTypeValue & allowedFileTypes) == 0)
                {
                    continue;
                }

                var allowedTypes = CoreSetting.Instance.AllowedFileTypes[fileTypeValue];

                if (allowedTypes.TryGetValue(extension, out var content)
                    && contentType.Equals(content, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
            }

            throw new BrSolutionException("Incorrect file format");
        }

    }
}
