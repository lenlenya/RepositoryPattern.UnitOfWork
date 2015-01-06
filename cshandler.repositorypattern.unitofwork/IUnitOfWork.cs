using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryPattern.UnitOfWork.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
