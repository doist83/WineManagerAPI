using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WineManager.DAL.Domains
{
   public class WineMaker
   {
      [Key]
      public int Id { get; set; }
      public string Name { get; set; }
      public string Address { get; set; }
      public List<WineBottle> Wines { get; set; }
}
}
