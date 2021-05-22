using System;
using System.Collections.Generic;
using System.Text;
using WineManager.DAL.Interfaces;
using WineManager.BLL.Interfaces;
using WineManager.DAL.Domains;
using System.Linq;

namespace WineManager.BLL
{
   public class WineMakerBLL : IWineMakerBLL
   {
      private IWineMakerService _service;
      private IWineBottleService _bottleService;

      public WineMakerBLL(IWineMakerService service,IWineBottleService bottleService) 
      {
         _service = service;
         _bottleService = bottleService;
      }

      public void AddWineBottles(WineMaker wineMaker, List<int> wineBottleIds)
      {       
         foreach (var bottlleId in wineBottleIds) 
         {
            var bottle = _bottleService.GetById(bottlleId);

            if (bottle != null) wineMaker.Wines.Add(bottle);
         }
         
         _service.Save();
      }

      public void AddWineMaker(WineMaker wineMaker)
      {
         _service.Insert(wineMaker);
         _service.Save();
      }

      public void Delete(int id)
      {
         _service.Delete(id);
         _service.Save();
      }

      public WineMaker GetWineMaker(int id)
      {
         return _service.GetById(id);
      }

      public IEnumerable<WineMaker> GetWineMakers()
      {
         return _service.GetAll();
      }

      public void RemoveWineBottle(WineMaker winemaker, int bottleID)
      {
          var bottle = _bottleService.GetById(bottleID);

          if (bottle != null) winemaker.Wines.Remove(bottle);
         
         _service.Save();
      }

      public void UpdateWineMaker(WineMaker winemaker)
      {
         _service.Update(winemaker);
         _service.Save();
      }

      public IEnumerable<WineBottle> GetBottlesByWineMaker(WineMaker winemaker)
      {
         return _service.GetAll().Where(x => x.Id == winemaker.Id).SingleOrDefault()?.Wines;
      }
   }
}
