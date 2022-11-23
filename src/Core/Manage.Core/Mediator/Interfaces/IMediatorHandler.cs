using Manage.Core.Messages;
using Manage.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Core.Mediator.Interfaces
{
    public interface IMediatorHandler
    {
        public Task PublishEvent<T>(T evnt) where T : Event;
        public Task<ValidationResultBag> SendCommand<T>(T command) where T : Command;
    }
}
