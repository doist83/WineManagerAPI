using System.Collections.Generic;
using System.Linq;
using WineManager.DAL.Interfaces; 

namespace WineManager.Test.Mocks
{
   public class MockRepository<T> : IRepository<T> where T : class
   {
      List<T> dataStore = new List<T>();
      public void Delete(object id)
      {
         throw new System.NotImplementedException();
      }

      public IQueryable<T> GetAll()
      {
         return dataStore.AsQueryable();
      }

      public T GetById(object id)
      {
         return dataStore.Find(x => x == id);
      }

      public void Insert(T obj)
      {
         dataStore.Add(obj);
      }

      public void Save()
      {
         
      }

      public void Update(T obj)
      {
         
      }
   }
}
