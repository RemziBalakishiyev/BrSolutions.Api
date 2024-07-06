using AutoMapper;
using BrSolution.Application.Data_Transfer_Objects.Users;
using BrSolution.Application.Exceptions;
using BrSolution.Application.Extensions;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces.App;
using BrSolution.Infrastructure.Settings;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BrSolution.Application.Features.Command.App.Auth
{
    public class GenerateTokenCommandHandler : ServiceQueryWithResponseHandlerBase<GenerateTokenCommand, AuthenticatedUserDto, IAdminService>
    {
        private readonly AbstractValidator<GenerateTokenCommand> _generateTokenValidators;

        private const string UserIdClaimType = "ir";
        private const string UserStatusClaimType = "sw";
        private const string UserServicePermissionClaimType = "sp";

        public GenerateTokenCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticationService authenticationService, AbstractValidator<GenerateTokenCommand> generateTokenValidators) : base(unitOfWork, mapper, authenticationService)
        {
            _generateTokenValidators = generateTokenValidators;
        }

        public override async Task<AuthenticatedUserDto> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            await _generateTokenValidators.ThrowIfValidationFailAsync(request);
            var user = await _unitOfWork.UserRepository.TryToGetWithDetailsAsync(request.Email, request.Password);
            if (user is null)
            {
                throw new BrSolutionException("Email or password is incorrect!");
            }

            var authUser = _mapper.Map<AuthenticatedUserDto>(user);
            authUser.Services = user.UserRoles
                .Select(x => x.Role)
                .SelectMany(r => r.RoleSystemServices, (_, d) => d.SystemService.EncryptedName)
                .Distinct();

            var claims = new List<Claim>
                {
                    new(UserIdClaimType, user.Id.ToString()),
                    new(UserStatusClaimType, ((int)user.UserStatusId).ToString())
                };


            claims.AddRange(authUser.Services.Select(x => new Claim(UserServicePermissionClaimType, x)));


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                CoreSetting.Instance.JwtSettings.SecretKey));
            var credentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(CoreSetting.Instance.JwtSettings.ExpireHours),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            authUser.Token = tokenHandler.WriteToken(token);

            return authUser;
        }
    }
}
