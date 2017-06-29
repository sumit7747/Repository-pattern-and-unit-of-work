using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace UnitofWork
{
    public class GenericRepository<S> : IRepository<S> where S : class
    
    {


        private asoEntities entities = null;
        //IObjectSet<S> _objectSet;
        IDbSet<S> _objectSet;

        public GenericRepository(asoEntities _entities)
        {

            entities = _entities;

            //_objectSet = entities.CreateObjectSet<S>();

            _objectSet = entities.Set<S>();




        }
    

        public IEnumerable<S> GetAll(Func<S, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _objectSet.Where(predicate);
            }

            return _objectSet.AsEnumerable();
        }


        public S Get(Func<S, bool> predicate)
        {
            return _objectSet.First(predicate);
        }



        public void Add(S entity)
        {
            _objectSet.Add(entity);
        }

     

        public void Attach(S entity)
        {



           entities.Entry(entity).State = EntityState.Modified;

            entities.SaveChanges();
            _objectSet.Attach(entity);

          


        }

    

        public void Delete(S entity)
        {


            //Contact conts = entities.S.Find(entity);

            //entities.Contacts.Remove(conts);

            var r = _objectSet.Find(entity);
            _objectSet.Remove(r);

          
        }


        //            I am trying to make sample code by following your article, but I am getting following error

        //'Entities' does not contain a definition for 'CreateObjectSet' and no extension method 'CreateObjectSet' accepting a first argument of type 'Entities' could be found(are you missing a using directive or an assembly reference ?)

        //Here is code where I am getting error

        //Hide   Copy Code
        //public GenericRepository(Entities _entities)
        //        {
        //            entities = _entities;
        //            _objectSet = entities.CreateObjectSet<S>();
        //        }

        //        Go to Parentusing System.Data.Entity

        //IDbSet<S> _objectSet;

        //        Hide Copy Code
        //public GenericRepository(Entities _entities)
        //        {
        //            entities = _entities;
        //            //_objectSet = entities.CreateObjectSet<S>();
        //            _objectSet = entities.Set<S>();
        //        }
















    }



}
