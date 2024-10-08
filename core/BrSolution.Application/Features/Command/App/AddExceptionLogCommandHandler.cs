﻿using AutoMapper;
using BrSolution.Application.Repositories;
using BrSolution.Application.ServiceInterfaces.App;
using BrSolution.Domain.Entities.App;

namespace BrSolution.Application.Features.Command.App
{
    public class AddExceptionLogCommandHandler : ServiceQueryHandlerBase<AddExceptionLogCommand, IAdminService>
    {
        public AddExceptionLogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticationService authenticationService) : base(unitOfWork, mapper , authenticationService)
        {
        }

        public override async Task Handle(AddExceptionLogCommand request, CancellationToken cancellationToken)
        {
            var exceptionLog = _mapper.Map<ExceptionLog>(request);
            await _unitOfWork.ExceptionLogRepository.Add(exceptionLog);
            await SaveChangesAsync(cancellationToken);
        }
    }
}
