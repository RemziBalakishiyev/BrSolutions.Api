using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSolution.Application.Exceptions
{
    public class BrSolutionException : ApplicationException
    {
        public ExceptionType Message { get; set; }
        public BrSolutionException(ExceptionType exceptionType)
        {
            Message = exceptionType;
        }

        public BrSolutionException(string message)
          : base(message)
        {
            Message = ExceptionType.InternalServerError;
        }
    }
}
