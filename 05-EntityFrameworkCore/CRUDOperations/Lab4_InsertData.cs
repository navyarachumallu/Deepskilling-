// Lab 4: Inserting Initial Data into the Database
// See RetailInventory/Program.cs - SeedDataAsync method

using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

await using var context = new AppDbContext();

var electronics = new Category { Name = "Electronics" };
var groceries = new Category { Name = "Groceries" };

await context.Categories.AddRangeAsync(electronics, groceries);

var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

await context.Products.AddRangeAsync(product1, product2);
await context.SaveChangesAsync();

Console.WriteLine("Initial data inserted successfully.");
