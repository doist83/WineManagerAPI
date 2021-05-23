using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using WineManager.DAL.Interfaces;
using WineManager.BLL;
using WineManager.DAL.Domains;
using System.Collections.Generic;
using System.Linq;

namespace WineManager.Test
{
   [TestClass]
   public class UnitTest_WIneBottleBLL : UnitTestBase
   {
      [TestMethod]
      public void Test_WineBottleInsert()
      {
         var bottleService = ServiceProvider.GetService<IWineBottleService>();
         var winemakerService = ServiceProvider.GetService<IWineMakerService>();
         var wineBottleBLL = new WineBottleBLL(bottleService,winemakerService);

         wineBottleBLL.AddBottle(new WineBottle() 
         {            
            Name = "Chardonnay",
            Year = 1983,
            Size = 1.5M,
            Count = 1,
            Description = "Chardonnay is a medium to full-bodied white wine that is grown globally but holds its own as the most popular wine varietal in America.",
            FoodPairing = "fish",
            Style = "Dry",
            Taste = "Apple",
            URL = "https://data.uritalianwines.com/imgprodotto/chardonnay-doc_10851.jpg",            
         });

         wineBottleBLL.AddBottle(new WineBottle()
         {
            Name = "Chardonnay",
            Year = 1983,
            Size = 1.5M,
            Count = 1,
            Description = "Chardonnay is a medium to full-bodied white wine that is grown globally but holds its own as the most popular wine varietal in America.",
            FoodPairing = "fish",
            Style = "Dry",
            Taste = "Apple",
            URL = "https://data.uritalianwines.com/imgprodotto/chardonnay-doc_10851.jpg",
         });


         var bottle = wineBottleBLL.GetBottles();

         Assert.IsNotNull(bottle);
         Assert.AreEqual(bottle.Count(), 2);

      }
   }
}
