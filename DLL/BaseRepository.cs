using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WineManager.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WineManager.DAL
{
   public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
   {
      private EntityContext _ctx = null;
      private DbSet<TEntity> table = null;

      public BaseRepository(EntityContext ctx)
      {
         this._ctx = ctx;
         table = _ctx.Set<TEntity>();
      }

      public void Delete(object id)
      {
         TEntity existing = table.Find(id);
         table.Remove(existing);
      }

      public IQueryable<TEntity> GetAll()
      {
         return table.AsQueryable();
      }

      public TEntity GetById(object id)
      {
         return table.Find(id);
      }

      public void Insert(TEntity obj)
      {
         table.Add(obj);
      }

      public void Save()
      {
         _ctx.SaveChanges();
      }

      public void Update(TEntity obj)
      {
         table.Attach(obj);
         _ctx.Entry(obj).State = EntityState.Modified;
      }
   }
}
