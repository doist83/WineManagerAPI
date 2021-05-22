using System;
using System.Collections.Generic;
using System.Linq;

namespace WineManager.DAL.Interfaces
{
   public interface IRepository<TEntity> where TEntity : class
   {
      IQueryable<TEntity> GetAll();
      TEntity GetById(object id);
      void Insert(TEntity obj);
      void Update(TEntity obj);
      void Delete(object id);
      void Save();
   }
}
