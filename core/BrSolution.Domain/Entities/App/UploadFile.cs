namespace BrSolution.Domain.Entities.App;

public class UploadFile : IEditedRelatableUserEntity
{
    public int Id { get; set; }

    public string FileName { get; set; }

    public string ContentType { get; set; }

    public string RelativePath { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public User? CreatedUser { get; set; }

    public int? LastEditUserId { get; set; }

    public User? LastEditUser { get; set; }
    public DateTime? LastEditedDate { get; set; }
}
