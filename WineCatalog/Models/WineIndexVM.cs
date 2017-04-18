using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WineCatalog.Models
{
    public class WineIndexVM
    {
        public IEnumerable<Wine> Wines { get; set; }

        public WineIndexVM()
        {
            Wines = new List<Wine>();
        }
    }
}