using System;
using System.Collections.Generic;
using System.Text;
using WineManager.BLL.BO;
using WineManager.DAL.Domains;

namespace WineManager.BLL.Interfaces
{
   public interface IWineBottleBLL
   {
      public void AddBottle(WineBottle bottle);
      public IEnumerable<WineBottle> GetBottles();
      public WineBottle GetBottle(int id);
      public void DeleteBottle(int bottleId);
      public void UpdateBottle(WineBottle bottle);
      public IEnumerable<WineBottle> Search(SearchOptions options);

   }
}
