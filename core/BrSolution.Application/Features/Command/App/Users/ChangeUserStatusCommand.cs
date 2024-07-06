using BrSolution.Infrastructure.PredefinedValues;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSolution.Application.Features.Command.App.Users
{
    public record ChangeUserStatusCommand(int UserId, UserStatusValue UserStatusValue) : IRequest;
    
}
