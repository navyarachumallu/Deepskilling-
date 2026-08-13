// Lab 7: Writing Queries with LINQ
// See RetailInventory/Program.cs - LinqQueriesAsync method

using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

await using var context = new AppDbContext();

var filtered = await context.Products
    .Where(p => p.Price > 1000)
    .OrderByDescending(p => p.Price)
    .ToListAsync();

var productDtos = await context.Products
    .Select(p => new ProductDto
    {
        Name = p.Name,
        Price = p.Price,
        CategoryName = p.Category.Name
    })
    .ToListAsync();

foreach (var dto in productDtos)
    Console.WriteLine($"{dto.Name} ({dto.CategoryName}) - Rs.{dto.Price}");
