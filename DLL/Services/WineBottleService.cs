using System;
using System.Collections.Generic;
using System.Text;
using WineManager.DAL.Domains;
using WineManager.DAL.Interfaces;

namespace WineManager.DAL.Services
{
   public class WineBottleService : BaseRepository<WineBottle>,IWineBottleService
   {
      public WineBottleService(EntityContext ctx) : base(ctx) { }
   }
}
