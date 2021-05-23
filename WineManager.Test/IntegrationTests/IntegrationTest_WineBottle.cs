using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WineManager.DAL.Domains;

namespace WineManager.Test.IntegrationTests
{
   [TestClass]
   public  class IntegrationTest_WineBottle : IntegrationTestBase
   {
      [TestMethod]
      public  void  Test_WineBottleInsert() 
      {
         var bottle = new WineBottle()
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
         };

         var jsonObject = JsonSerializer.Serialize(bottle);


         var postResult = client.PostAsync("/api/WineBottle", new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json")).Result;

         var getResult = client.GetStringAsync("/api/WineBottle/1").Result;
         
         WineBottle savedBottle = JsonSerializer.Deserialize<WineBottle>(getResult, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true });

         Assert.IsNotNull(savedBottle);
         Assert.AreEqual(savedBottle.Id, 1);
      }
   }
}
