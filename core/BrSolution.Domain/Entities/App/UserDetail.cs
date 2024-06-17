using BrSolution.Domain.Entities.Libraries;
using BrSolution.Infrastructure.PredefinedValues;

namespace BrSolution.Domain.Entities.App;

public class UserDetail : IEditedEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public User User { get; set; }

    public string FirstName { get; set; }

    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public GenderValue GenderId { get; set; }
    public Gender Gender { get; set; }
    public int UploadFileId { get; set; }
    public UploadFile UploadedFile { get; set; }
    public DateTime? LastEditedDate { get; set; }
    public DateTime CreateDate { get; set; }
}
