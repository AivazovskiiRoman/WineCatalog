using System.Collections.Generic;

namespace WineCatalog.Models
{
    public class WineVM
    {
        public IEnumerable<Wine> Wines { get; set; }

        public WineVM()
        {
            Wines = new List<Wine>();
        }
    }
}