using FluentValidation;

namespace BrSolution.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static async Task ThrowIfValidationFailAsync<T>(this IValidator<T> validator, T instance)
        {
            var validationResult = await validator.ValidateAsync(instance);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
