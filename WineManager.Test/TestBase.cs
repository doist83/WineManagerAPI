using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using WineManager.DAL.Interfaces;
using WineManager.Test.Mocks;


namespace WineManager.Test
{
   public abstract class TestBase
   {
      protected ServiceProvider ServiceProvider;

      public TestBase() 
      {
      
      }

      [TestInitialize]
      public void Setup() 
      {
         ServiceCollection services = new ServiceCollection();
         services.AddTransient<IWineBottleService, MockWineBottleDLL>();
         services.AddTransient<IWineMakerService, MockWineMakerDLL>();
         ServiceProvider =  services.BuildServiceProvider();
      }
   }
}
