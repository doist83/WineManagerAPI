using Microsoft.EntityFrameworkCore;
using WineManager.DAL.Domains;

namespace WineManager.DAL
{
   public class EntityContext : DbContext
   {
      public EntityContext(DbContextOptions opt) : base(opt) { }

      public DbSet<WineBottle> WineBottle { get; set; }
      public DbSet<WineMaker> WineMaker { get; set; }
   }
}
