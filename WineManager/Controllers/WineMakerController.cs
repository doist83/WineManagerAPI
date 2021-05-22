using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WineManager.BLL.Interfaces;
using WineManager.DAL.Domains;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WineManager.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class WineMakerController : ControllerBase
   {
      IWineBottleBLL _wineBottleBLL;
      IWineMakerBLL _wineMakerBLL;

      public WineMakerController(IWineBottleBLL wineBottleBLL,IWineMakerBLL wineMakerBLL) 
      {
         _wineBottleBLL = wineBottleBLL;
         _wineMakerBLL = wineMakerBLL;


         //some Demo data:

         wineMakerBLL.AddWineMaker(new WineMaker() 
         {
            Name = "Istvan Dosa",
            Address = "Budapest",            
         });
      }

      // GET: api/<WineMaker>
      /// <summary>
      /// Get All WineMakers
      /// </summary>
      /// <returns></returns>
      [HttpGet]
      public IEnumerable<WineMaker> Get()
      {
         return _wineMakerBLL.GetWineMakers();
      }

      // GET api/<WineMaker>/5
      /// <summary>
      /// Get a single winemake by Id
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [HttpGet("{id}")]
      public WineMaker Get(int id)
      {
         return _wineMakerBLL.GetWineMaker(id);
      }

      // POST api/<WineMaker>
      /// <summary>
      /// Create a wine maker
      /// </summary>
      /// <param name="wineMaker"></param>
      [HttpPost]
      public void Post(WineMaker wineMaker)
      {
         _wineMakerBLL.AddWineMaker(wineMaker);
        
      }

      // PUT api/<WineMaker>/5
      /// <summary>
      /// Update wine maker
      /// </summary>
      /// <param name="wineMaker"></param>
      [HttpPut("{id}")]
      public void Put(WineMaker wineMaker)
      {
         _wineMakerBLL.UpdateWineMaker(wineMaker);
      }
      
      /// <summary>
      /// Add bottles to a winemaker
      /// </summary>
      /// <param name="id"></param>
      /// <param name="bottleIDs"></param>
      [HttpPost("{id}/bottles")]      
      public void AddBottles(int id,List<int> bottleIDs) 
      {
         WineMaker winemaker = _wineMakerBLL.GetWineMaker(id);
         _wineMakerBLL.AddWineBottles(winemaker,bottleIDs);
      }

      // DELETE api/<WineMaker>/5
      /// <summary>
      /// Delete Winemaker
      /// </summary>
      /// <param name="id"></param>
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
         _wineMakerBLL.Delete(id);
      }

      /// <summary>
      /// Remove bottles from a wine maker
      /// </summary>
      /// <param name="id"></param>
      /// <param name="bottleID"></param>
      [HttpDelete("{id}/bottles/{bottleID}")]
      public void RemoveBottle(int id, int bottleID)
      {
         WineMaker winemaker = _wineMakerBLL.GetWineMaker(id);
         _wineMakerBLL.RemoveWineBottle(winemaker, bottleID);
      }
   }
}
