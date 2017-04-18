using System.Data.Entity;
using WineCatalog.Models;

namespace WineCatalog.EF
{
    public class WineContext : DbContext
    {
        public WineContext() : base("DefaultConnection")
        {
        }

        public DbSet<Wine> Wines { get; set; }
    }
}