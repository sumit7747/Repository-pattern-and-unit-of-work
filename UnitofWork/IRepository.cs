using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitofWork
{
   public  interface IRepository<S> where S :class
    {

        IEnumerable<S> GetAll(Func<S, bool> predicate = null);
        S Get(Func<S, bool> predicate);
        void Add(S entity);
        void Attach(S entity);
        void Delete(S entity);



    }
}
