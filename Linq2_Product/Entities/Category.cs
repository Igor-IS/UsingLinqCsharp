using Linq2_Product.Enums;


namespace Linq2_Product.Entities
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Tier Tier { get; set; }

        public Category() { 
        }

        public Category(int id, string name, Tier tier)
        {
            Id = id;
            Name = name;
            Tier = tier;
        }
    }
}
