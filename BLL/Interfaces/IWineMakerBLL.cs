using System;
using System.Collections.Generic;
using System.Text;
using WineManager.DAL.Domains;

namespace WineManager.BLL.Interfaces
{
   public interface IWineMakerBLL
   {
      public IEnumerable<WineMaker> GetWineMakers();
      public WineMaker GetWineMaker(int id);
      public void AddWineMaker(WineMaker wineMaker);
      public void UpdateWineMaker(WineMaker winemaker);
      public void Delete(int id);
      public void AddWineBottles(WineMaker winemaker, List<int> wineBottleIds);
      public void RemoveWineBottle(WineMaker winemaker, int bottleID);
   }
}
