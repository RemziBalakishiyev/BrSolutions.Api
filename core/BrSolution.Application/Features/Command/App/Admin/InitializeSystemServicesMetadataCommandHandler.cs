using AutoMapper;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces.App;
using BrSolution.Domain.Entities.App;
using BrSolution.Infrastructure.Helpers;
using System.Reflection;

namespace BrSolution.Application.Features.Command.App.Admin;

internal class InitializeSystemServicesMetadataCommandHandler : ServiceQueryHandlerBase<InitializeSystemServicesMetadataCommand, IAdminService>
{
    public InitializeSystemServicesMetadataCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticationService authenticationService) : base(unitOfWork, mapper, authenticationService)
    {
    }

    public async override Task Handle(InitializeSystemServicesMetadataCommand request, CancellationToken cancellationToken)
    {
        var alreadySavedNames = await _unitOfWork.SystemServiceRepository.GetSystemServiceEncryptedNamesAsync();
        var assembly = Assembly.GetExecutingAssembly();

        foreach (var type in assembly.GetExportedTypes())
        {
            if (!type.IsSubclassOf(typeof(ServiceQueryHandlerBase<,>)) || !type.IsSubclassOf(typeof(ServiceQueryWithResponseHandlerBase<,,>)))
            {
                continue;
            }

            var encryptedTypeName = SystemServiceHelper.EncryptSystemServiceName(type);

            if (alreadySavedNames.Contains(encryptedTypeName))
            {
                continue;
            }

            var typeName = type.FullName!;

            await _unitOfWork.SystemServiceRepository.Add(new SystemService
            {
                EncryptedName = encryptedTypeName,
                TypeName = typeName,
                Description = typeName
            });
        }
    }
}