using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSolution.Application.Features.Query.App
{
    public class GetTransactionIdQuery : IRequest<Guid>
    {
    }
}
