using System.Globalization;

namespace Linq2_Product.Entities
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public Product()
        {

        }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        
        public Product(int id, string name, double price, Category category) 
            : this ()
        {
            Category = category;
        }

        public override string ToString()
        {
            return $"ID {Id}  {Name}  ${Price.ToString("F2", CultureInfo.InvariantCulture)} Category: {Category.Id} - {Category.Name}  Tier {Category.Tier}";
        }
    }
}
