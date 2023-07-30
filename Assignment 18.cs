using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int ShopId { get; set; }
}

public class Shop
{
    public int ShopId { get; set; }
    public string Name { get; set; }
}

class Program
{
    static void Main()
    {

        List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, Name = "Product A", Price = 10.0, ShopId = 1 },
            new Product { ProductId = 2, Name = "Product B", Price = 15.0, ShopId = 1 },
            new Product { ProductId = 3, Name = "Product C", Price = 20.0, ShopId = 2 },
            new Product { ProductId = 4, Name = "Product D", Price = 25.0, ShopId = 2 }
        };

        List<Shop> shops = new List<Shop>
        {
            new Shop { ShopId = 1, Name = "Shop 1" },
            new Shop { ShopId = 2, Name = "Shop 2" }
        };


        var allProducts = products.Union(products);

        var joinQuery = products.Join(shops,
                                      product => product.ShopId,
                                      shop => shop.ShopId,
                                      (product, shop) => new { product.Name, shop.Name });


        var groupJoinQuery = shops.GroupJoin(products,
                                            shop => shop.ShopId,
                                            product => product.ShopId,
                                            (shop, products) => new
                                            {
                                                ShopName = shop.Name,
                                                Products = products.Select(p => p.Name)
                                            });


        var groupByQuery = products.GroupBy(product => product.ShopId);

        var groupByMultipleQuery = products.GroupBy(product => new { product.ShopId, product.Price });


        var groupByAggregateQuery = products.GroupBy(product => product.ShopId)
                                            .Select(group => new
                                            {
                                                ShopId = group.Key,
                                                TotalPrice = group.Sum(product => product.Price),
                                                MaxPrice = group.Max(product => product.Price),
                                                MinPrice = group.Min(product => product.Price),
                                                AveragePrice = group.Average(product => product.Price),
                                                Count = group.Count()
                                            });

        Console.WriteLine("All Products:");
        foreach (var product in allProducts)
        {
            Console.WriteLine($"{product.Name}");
        }

        Console.WriteLine("\nJoin Query (Product Name, Shop Name):");
        foreach (var item in joinQuery)
        {
            Console.WriteLine($"{item.Name}, {item.ShopName}");
        }

        Console.WriteLine("\nGroup Join Query (Shop Name, Products):");
        foreach (var shop in groupJoinQuery)
        {
            Console.WriteLine($"Shop: {shop.ShopName}");
            foreach (var product in shop.Products)
            {
                Console.WriteLine($"- {product}");
            }
        }

        Console.WriteLine("\nGroup By Query:");
        foreach (var group in groupByQuery)
        {
            Console.WriteLine($"ShopId: {group.Key}");
            foreach (var product in group)
            {
                Console.WriteLine($"- {product.Name}");
            }
        }

        Console.WriteLine("\nGroup By Multiple Properties Query:");
        foreach (var group in groupByMultipleQuery)
        {
            Console.WriteLine($"ShopId: {group.Key.ShopId}, Price: {group.Key.Price}");
            foreach (var product in group)
            {
                Console.WriteLine($"- {product.Name}");
            }
        }

        Console.WriteLine("\nGroup By Aggregate Query:");
        foreach (var group in groupByAggregateQuery)
        {
            Console.WriteLine($"ShopId: {group.ShopId}");
            Console.WriteLine($"Total Price: {group.TotalPrice}");
            Console.WriteLine($"Max Price: {group.MaxPrice}");
            Console.WriteLine($"Min Price: {group.MinPrice}");
            Console.WriteLine($"Average Price: {group.AveragePrice}");
            Console.WriteLine($"Count: {group.Count}");
        }
    }
}
