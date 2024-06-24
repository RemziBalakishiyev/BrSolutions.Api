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


        public static IRuleBuilderOptions<T, TProperty> CantBeNull<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> ruleBuilder)
        {
       
            return ruleBuilder.WithMessage($"{nameof(TProperty)} can't be null");
        }

        public static IRuleBuilderOptions<T, TProperty> CantBeNull<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> ruleBuilder,
        string systemMessage)
        {

            return ruleBuilder.WithMessage($"{systemMessage} can't be null");
        }
    }
}
