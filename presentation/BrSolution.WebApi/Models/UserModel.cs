using BrSolution.Application.Features.Command.App.Users;
using BrSolution.Application.Wrappers;
using BrSolution.Infrastructure.PredefinedValues;

namespace BrSolution.WebApi.Models
{
    public class UserModel
    {
        public IFormFile? UserImage { get; set; }
        private string _email;
        private string _firstName;
        private string? _lastName;

        public string Email
        {
            get => _email;
            set => _email = value.Trim().ToLower();
        }

        public string Password { get; set; }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value.Trim();
        }

        public string? LastName
        {
            get => _lastName;
            set => _lastName = value?.Trim();
        }

        public GenderValue GenderId { get; set; }


        public DateTime DateOfBirth { get; set; }
    }
}
