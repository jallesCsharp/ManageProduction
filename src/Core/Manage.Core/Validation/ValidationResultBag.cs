using FluentValidation.Results;

namespace Manage.Core.Validation
{
    public class ValidationResultBag : ValidationResult
    {
        public object? Data { get; set; }
    }
}
