using System.Data.Entity;
using WineCatalog.Models;

namespace WineCatalog.EF
{
    public class WineDbInitializer : DropCreateDatabaseAlways<WineContext>
    {
        protected override void Seed(WineContext db)
        {
            db.Wines.Add(new Wine {Name = "Pinot Noir", Color = "Red", InStock = true, Price = 215});
            db.Wines.Add(new Wine {Name = "Rhone", Color = "Blush", InStock = true, Price = 154});
            db.Wines.Add(new Wine {Name = "Malbec", Color = "White", InStock = false, Price = 248});
            db.Wines.Add(new Wine {Name = "Inkerman", Color = "Rose", InStock = true, Price = 175});
            db.Wines.Add(new Wine {Name = "Zinfandel", Color = "Pink", InStock = false, Price = 97});

            base.Seed(db);
        }
    }
}