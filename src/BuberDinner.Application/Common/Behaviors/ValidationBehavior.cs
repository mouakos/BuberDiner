using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BuberDinner.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? validator)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr

    {
        #region Public methods declaration

        /// <inheritdoc />
        public async Task<TResponse> Handle(TRequest request,
            RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validator is null)
            {
                return await next();
            }

            ValidationResult? validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                return await next();
            }

            List<Error> errors =
                validationResult.Errors.ConvertAll(x => Error.Validation(x.PropertyName, x.ErrorMessage));
            return (dynamic)errors;
        }

        #endregion
    }
}