using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UnitofWork
{
    public class ContactsRepository : IRepository<Contact>
    {

        protected asoEntities entities;


        public ContactsRepository()
        {
            entities = new asoEntities();

        }



        public IEnumerable<Contact> GetAll(Func<Contact, bool> predicate = null)
        {
            if (predicate != null)
            {
                if (predicate != null)
                {
                    return entities.Contacts.Where(predicate);
                }
            }

            return entities.Contacts;
        }

        public Contact Get(Func<Contact, bool> predicate)
        {
            return entities.Contacts.FirstOrDefault(predicate);
        }

        public void Add(Contact entity)
        {
            entities.Contacts.Add(entity);
        }

        //public void Attach(Contact entity)
        //{
        //    entities.Contacts.Attach(entity);
        //    entities.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        //}



        public void Attach(Contact entity)
        {
            entities.Entry(entity).State = EntityState.Modified;

            entities.SaveChanges();

        }



        public void Delete(Contact entity)

        {

            Contact conts = entities.Contacts.Find(entity);

            entities.Contacts.Remove(conts);

        }


        //public void Delete(Contact entity)
        //{
        //    entities.Contacts.DeleteObject(entity);
        //}

        internal void SaveChanges()
        {
            entities.SaveChanges();
        }
    }
}