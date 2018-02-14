using DataAccess.Context;
using System;

namespace DataAccess
{
    public class UnityOfWork : System.IDisposable
    {
        protected readonly MedicalContext context;
        public UnityOfWork(MedicalContext context)
        {
            this.context = context;
        }

        public bool SaveChange()
        {
            return context.SaveChanges() > 1;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
