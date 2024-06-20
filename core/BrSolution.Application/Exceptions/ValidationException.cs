using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSolution.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<ValidationFailure> Errors { get; }

        public ValidationException(List<ValidationFailure> errors)
            : base("Validation failed")
        {
            Errors = errors;
        }
    }
}
