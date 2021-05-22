using System;
using System.Collections.Generic;
using System.Text;
using WineManager.DAL.Domains;
using WineManager.DAL.Interfaces;

namespace WineManager.Test.Mocks
{
   public class MockWineMakerDLL : MockRepository<WineMaker>, IWineMakerService
   {
   }
}
