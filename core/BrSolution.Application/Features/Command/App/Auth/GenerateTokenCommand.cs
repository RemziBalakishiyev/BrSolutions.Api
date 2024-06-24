using BrSolution.Application.Data_Transfer_Objects.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSolution.Application.Features.Command.App.Auth
{
    public class GenerateTokenCommand : IRequest<AuthenticatedUserDto>
    {
        private string _email;

        public string Email
        {
            get => _email;
            set => _email = value.Trim().ToLower();
        }

        public string Password { get; set; }
    }
}
