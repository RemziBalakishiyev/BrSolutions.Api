using BrSolution.Application.AutoMappers;
using BrSolution.Domain.Entities.App;
using MediatR;

namespace BrSolution.Application.Features.Command.App
{
    public class AddExceptionLogCommand : IMapTo<ExceptionLog> , IRequest 
    {
        public string? RequestIp { get; set; }

        public string RequestUrl { get; set; }

        public string? RequestBody { get; set; }

        public string HttpMethod { get; set; }

        public Guid TransactionId { get; set; }

        public string? EndpointName { get; set; }

        public string ExceptionTypeName { get; set; }

        public string ExceptionMessage { get; set; }

        public string? StackTrace { get; set; }
    }
}
