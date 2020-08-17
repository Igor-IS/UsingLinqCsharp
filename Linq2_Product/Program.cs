using Linq2_Product.Entities;
using Linq2_Product.Enums;
using Linq2_Product.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Linq2_Product
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayData display = new DisplayData();

            Tier normal = Tier.Normal;
            Tier top = Tier.Top;
            Tier special = Tier.Special;
            Tier mastery = Tier.Mastery;

            Category catToolsNormal = new Category() { Id = 1, Name = "Tools", Tier = normal };
            Category catToolsTop = new Category() { Id = 2, Name = "Tools", Tier = top };
            Category catToolsSpecial = new Category() { Id = 3, Name = "Tools", Tier = special };

            List<Product> productList = new List<Product>() 
            { 
                new Product(){ Id = 1, Name = "Hammer Stanley", Price = 1500, Category = catToolsSpecial },
                new Product(){ Id = 2, Name = "Screwdriver", Price = 150, Category = catToolsNormal },
                new Product(){ Id = 3, Name = "Eletric saw", Price = 1500, Category = catToolsTop },
                new Product(){ Id = 4, Name = "Drilling machine", Price = 800, Category = catToolsSpecial },
                new Product(){ Id = 5, Name = "Glass saw", Price = 800, Category = catToolsSpecial },
                new Product(){ Id = 6, Name = "Knif", Price = 200, Category = catToolsNormal },
                new Product(){ Id = 7, Name = "Handsaw Starrett", Price = 150, Category = catToolsTop },
                new Product(){ Id = 8, Name = "Saw Starrett", Price = 85.90, Category = catToolsTop },
                new Product(){ Id = 9, Name = "Small Inox", Price = 50.85, Category = catToolsNormal }
            };
            display.Display(productList);

            var filterPrice = productList.Where(prod => prod.Price <= 150 && prod.Category.Tier == top )
                .Select(prod => new { prod.Name, prod.Price, CategoryName = prod.Category.Name }).ToList();
                                                  //CategoryName é um apelido para resolver a ambiguidade de nomes
            display.Display(filterPrice);

            var filterOrder = productList.Where(prod => prod.Category.Tier == special)
                .OrderBy(prod => prod.Price).ThenBy(prod => prod.Name).ToList();
            display.Display(filterOrder);

            var skipTake = productList.Skip(2).Take(4).ToList();
            display.Display(skipTake);

            var filterId = productList.Where(prod => prod.Id == 5).ToList();
            display.Display(filterId);

            var firstOrDefault = productList.First();
            Console.WriteLine(firstOrDefault);

            var maxPrice = productList.Max(prod => prod.Price);
            Console.WriteLine($"Max value: ${maxPrice.ToString("F2", CultureInfo.InvariantCulture)}");

            var minPrice = productList.Min(prod => prod.Price);
            Console.WriteLine($"Min value: ${minPrice.ToString("F2", CultureInfo.InvariantCulture)}");

            var sumWhere = productList.Where(prod => prod.Category.Tier == top).Sum(prod => prod.Price);
            Console.WriteLine($"Total value of the category Top: ${sumWhere.ToString("F2", CultureInfo.InvariantCulture)}");

            var average = productList.Where(prod => prod.Category.Tier == special).Average(prod => prod.Price);
            Console.WriteLine($"Average value of the category Special: ${average.ToString("F2", CultureInfo.InvariantCulture)}");

            // ao usar DefaultIfEmpty() com Average() evita possiveis exceptions em casos de coleções vazias
            var averageNotEmpty = productList.Where(prod => prod.Category.Tier == mastery).Select(prod => prod.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine($"Value is not empty: {averageNotEmpty.ToString("F2", CultureInfo.InvariantCulture)}");

            // criando uma soma personalizada e usando sobrecarga no Aggregate(0.0, lambda)
            var customSum = productList.Where(prod => prod.Category.Tier == mastery).Select(prod => prod.Price).Aggregate(0.0, (prod1, prod2) => prod1 + prod2);
            Console.WriteLine($"Custom Sum: ${customSum.ToString("F2", CultureInfo.InvariantCulture)}");


            // agrupamento por uma logica definida..
            var groupBy = productList.GroupBy(prod => prod.Category);
            foreach (var category in groupBy)
            {
                Console.WriteLine($"Catgory: {category.Key.Tier}");
                foreach (var product in category)
                {
                    Console.WriteLine(product);
                }
                Console.WriteLine();
            }
        }
    }
}
