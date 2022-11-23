using FluentValidation.Results;
using Manage.Core.Interfaces.IRepository.UnitOfWork;
using Manage.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResultBag ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResultBag();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected async Task<ValidationResultBag> PersistData(IUnitOfWork uow)
        {
            if (!await uow.Commit())
                AddError("Houve um erro ao persistir os dados");

            return ValidationResult;
        }
    }
}
