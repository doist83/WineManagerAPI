using System.Collections.Generic;
using System.Linq;
using WineManager.DAL.Domains;
using WineManager.DAL.Interfaces;

namespace WineManager.Test.Mocks
{
   public class MockWineBottleDLL : MockRepository<WineBottle>,IWineBottleService
   {
   }
}
