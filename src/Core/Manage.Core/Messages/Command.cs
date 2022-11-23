using FluentValidation.Results;
using Manage.Core.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Core.Messages
{
    public abstract class Command : IRequest<ValidationResultBag>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command() => Timestamp = DateTime.Now;

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
