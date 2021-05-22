using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WineManager.DAL.Domains
{
   public class WineBottle
   {
      [Key]
      public int Id { get; set; }
      public string Name { get; set; }
      public int Year { get; set; }
      public int Count { get; set; }
      public decimal Size { get; set; }
      public string Style { get; set; }
      public string Taste { get; set; }
      public string Description { get; set; }
      public string FoodPairing { get; set; }
      public string URL { get; set; }
      public byte[] Image { get; set; }

   }
}
