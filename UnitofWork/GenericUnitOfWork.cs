using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitofWork
{
    public class GenericUnitOfWork:IDisposable
    {
        private asoEntities entities = null;


            public GenericUnitOfWork() {

            entities = new asoEntities();

        }


        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();



        public IRepository<S> Repository<S>() where S : class
        {
            if (repositories.Keys.Contains(typeof(S)) == true)
            {
                return repositories[typeof(S)] as IRepository<S>;
            }
            IRepository<S> repo = new GenericRepository<S>(entities);
            repositories.Add(typeof(S), repo);
            return repo;
        }


        public void SaveChanges()
        {
            entities.SaveChanges();
        }

        

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                    entities.Dispose();

                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~GenericUnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
             GC.SuppressFinalize(this);
        }
        #endregion
    }
}