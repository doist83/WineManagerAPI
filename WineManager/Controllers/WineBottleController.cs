using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WineManager.BLL.Interfaces;
using WineManager.BLL.BO;
using WineManager.DAL.Domains;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WineManager.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class WineBottleController : ControllerBase
   {
      IWineBottleBLL _bottleBLL;
      public WineBottleController(IWineBottleBLL bottleBLL) 
      {
         _bottleBLL = bottleBLL;


         //some demo data:
         byte[] bytes = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

         bottleBLL.AddBottle(new WineBottle()
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
            Image = bytes
         });

      }

      // GET: api/<WineBottleController>
      /// <summary>
      /// Get All bottles
      /// </summary>
      /// <returns></returns>
      [HttpGet]
      public IEnumerable<WineBottle> Get()
      {
         return _bottleBLL.GetBottles();
      }

      // GET api/<WineBottleController>/5
      /// <summary>
      /// Get bottle by ID
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [HttpGet("{id}")]
      public WineBottle Get(int id)
      {
         return _bottleBLL.GetBottle(id);
      }

      // POST api/<WineBottleController>
      /// <summary>
      /// Create a new bottle
      /// </summary>
      /// <param name="bottle"></param>
      [HttpPost]
      public void Post(WineBottle bottle)
      {
         _bottleBLL.AddBottle(bottle);
      }

      // PUT api/<WineBottleController>/5
      /// <summary>
      /// Update bottle
      /// </summary>
      /// <param name="bottle"></param>
      [HttpPut("{id}")]
      public void Put(WineBottle bottle)
      {
         _bottleBLL.UpdateBottle(bottle);
      }

      // DELETE api/<WineBottleController>/5
      /// <summary>
      /// Delete bottle 
      /// </summary>
      /// <param name="id"></param>
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
         _bottleBLL.DeleteBottle(id);
      }
     
      /// <summary>
      /// Search bottles 
      /// </summary>
      /// <param name="option"></param>
      /// <returns></returns>
      [HttpPost("/search")]
      public IEnumerable<WineBottle> SearchWines(SearchOptions option) 
      {
         return _bottleBLL.Search(option);
      }


   }
}
