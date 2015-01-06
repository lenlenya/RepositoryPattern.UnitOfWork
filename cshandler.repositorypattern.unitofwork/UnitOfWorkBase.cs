using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RepositoryPattern.UnitOfWork.Base
{
    /// <summary>
    /// Class to provide the base functionality of Unit of work by keeping the share context for various repositories.
    /// </summary>
    /// <remarks>
    /// Derived class has to keep all the repositories.
    /// </remarks>
    /// <example>
    ///     public class UnitOfWork : UnitOfWorkBase<YourContext/>, IDisposable
    ///      {
    ///          private RepositoryBase<ModelEntity/> sampleRepository;
    ///          public RepositoryBase<ModelEntity/> SampleRepository
    ///          {
    ///              get
    ///              {
    ///                  if (this.sampleRepository == null)
    ///                  {
    ///                      this.sampleRepository = new RepositoryBase<ModelEntity/>(context);
    ///                  }
    ///                  return departmentRepository;
    ///              }
    ///          }
    ///          ......
    ///          ......
    ///      }
    /// </example>
    /// <typeparam name="TContext"> Context that has to be shared across the repositories
    /// </typeparam>
    public abstract class UnitOfWorkBase<TContext> : IUnitOfWork where TContext : DbContext, new()
    {
        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// The context.
        /// </summary>
        protected TContext context = new TContext();

        /// <summary>
        /// Dispose the context for the instance of current class.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }

        /// <summary>
        /// Invoke the disposing of context for the instance of current class.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Saves the changes done in the unit of work on the context.
        /// </summary>
        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
