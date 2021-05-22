using System;
using System.Collections.Generic;
using System.Text;
using WineManager.DAL.Domains;

namespace WineManager.DAL.Interfaces
{
   public interface IWineBottleService : IRepository<WineBottle> 
   {
   }
}
