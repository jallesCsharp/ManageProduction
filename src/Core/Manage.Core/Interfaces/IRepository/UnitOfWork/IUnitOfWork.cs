using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Core.Interfaces.IRepository.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        bool DatabaseExists();
    }
}
