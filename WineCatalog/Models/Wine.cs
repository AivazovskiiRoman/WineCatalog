namespace WineCatalog.Models
{
    public class Wine
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public int Price { get; set; }

        public bool InStock { get; set; }
    }
}