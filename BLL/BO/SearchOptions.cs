using System;
using System.Collections.Generic;
using System.Text;

namespace WineManager.BLL.BO
{
   public class SearchOptions
   {
      public string Name { get; set; }
      public int? Year { get; set; }
      public int? Count { get; set; }
      public decimal? Size { get; set; }
      public string Style { get; set; }
      public string Taste { get; set; }
      public string Description { get; set; }
      public string FoodPairing { get; set; }
   }
}
