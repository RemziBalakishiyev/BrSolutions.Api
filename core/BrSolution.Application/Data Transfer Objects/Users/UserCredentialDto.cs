namespace BrSolution.Application.Data_Transfer_Objects.Users;

public class UserCredentialDto
{
    private string _email;

    public string Email
    {
        get => _email;
        set => _email = value.Trim().ToLower();
    }

    public string Password { get; set; }
}
