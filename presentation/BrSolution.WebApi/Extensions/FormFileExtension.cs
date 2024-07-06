using BrSolution.Application.Wrappers;

namespace BrSolution.WebApi.Extensions;

public static class FormFileExtension
{
    public static FileContentWrapper? AsFileContentWrapper(this IFormFile? formFile)
    {
        return formFile is not null
            ? new FileContentWrapper
            {
                Stream = formFile.OpenReadStream(),
                ContentType = formFile.ContentType,
                FileName = formFile.FileName
            }
            : null;
    }
}
