using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;

namespace WineManager.Test.IntegrationTests
{
   public  class IntegrationTestBase
   {           
      protected HttpClient client;
      

      [TestInitialize]
      public void SetUp() 
      {
         var host = new WebHostBuilder().UseStartup<Startup>();
         var server = new TestServer(host);

         client = server.CreateClient();
      }
   }
}
