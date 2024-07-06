namespace BrSolution.Application.Wrappers;

public class FileContentWrapper
{
    private string _fileName;
    private string _contentType;

    public Stream Stream { get; init; }

    public string ContentType
    {
        get => _contentType;
        init => _contentType = value.Trim();
    }

    public string FileName
    {
        get => _fileName;
        set => _fileName = value.Trim();
    }
}
