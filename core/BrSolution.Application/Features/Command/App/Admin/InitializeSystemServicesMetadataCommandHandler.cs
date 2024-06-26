using AutoMapper;
using AutoMapper.Internal;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces;
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
        var exported = assembly.GetExportedTypes().ToList();
        foreach (var type in exported)
        {
            if (type.GetInterfaces().Contains(typeof(IServiceBase)))
            {
                var encryptedTypeName = SystemServiceHelper.EncryptSystemServiceName(type);

                if (!alreadySavedNames.Contains(encryptedTypeName))
                {
                    var typeName = type.FullName!;
                
                    
                    await _unitOfWork.SystemServiceRepository.Add(new SystemService
                    {
                        EncryptedName = encryptedTypeName,
                        TypeName = typeName,
                        Description = typeName,
                        CreateDate = DateTime.Now,
                    });
                }
            }
        }
        await SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitChangesAsync(cancellationToken);

    }

}