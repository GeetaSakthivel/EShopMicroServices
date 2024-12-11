namespace Catalog.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public String Name { get; set; } = default!;
        public List<string> Category { get; set; } = new();
        public string Description { get; set; }= default!;

        public string Imagefile { get; set; } = default!;

        public  decimal Price { get; set; }



    }
}
