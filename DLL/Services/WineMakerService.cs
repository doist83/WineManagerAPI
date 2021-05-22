using System;
using System.Collections.Generic;
using System.Text;
using WineManager.DAL.Domains;
using WineManager.DAL.Interfaces;

namespace WineManager.DAL.Services
{
   public class WineMakerService : BaseRepository<WineMaker>,IWineMakerService
   {
      public WineMakerService(EntityContext ctx) : base(ctx) { }
   }
}
