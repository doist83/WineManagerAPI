using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using WineManager.DAL.Interfaces;
using WineManager.BLL.Interfaces;
using WineManager.DAL.Domains;
using WineManager.BLL.BO;

namespace WineManager.BLL
{
   public class WineBottleBLL : IWineBottleBLL
   {
      private IWineBottleService _service;
      private IWineMakerService _wineMakerService;

      public WineBottleBLL(IWineBottleService service,IWineMakerService wineMakerService) 
      {
         _service = service;
         _wineMakerService = wineMakerService;
      }

      public void AddBottle(WineBottle bottle)
      {
         if (bottle == null) throw new ArgumentException("Invalid Bottle");

         _service.Insert(bottle);
         _service.Save();
      }

      public void DeleteBottle(int id)
      {         
         _service.Delete(id);
         _service.Save();
      }

      public WineBottle GetBottle(int id)
      {
         return _service.GetById(id);
      }

      public IEnumerable<WineBottle> GetBottles()
      {
         return _service.GetAll();
      }

      public IEnumerable<WineBottle> Search(SearchOptions options)
      {
         var query = _service.GetAll();

         if (!String.IsNullOrEmpty(options.Name))
            query = query.Where(x => x.Name == options.Name);
         if(options.Year.HasValue)
            query = query.Where(x => x.Year == options.Year);
         if(options.Count.HasValue)
            query = query.Where(x => x.Count == options.Count);
         if(options.Size.HasValue)
            query = query.Where(x => x.Size == options.Size);
         if(!String.IsNullOrEmpty(options.Style))
            query = query.Where(x => x.Style == options.Style);

         return query.ToList();
      }

      public void UpdateBottle(WineBottle bottle)
      {
         if (bottle == null) throw new ArgumentException("Invalid Bottle");

         _service.Update(bottle);
         _service.Save();

      }

      

   }
}
