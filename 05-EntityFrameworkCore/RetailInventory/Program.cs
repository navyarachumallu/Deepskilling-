using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

// EF Core 8.0 Hands-On Labs 4-7: CRUD and LINQ operations
await using var context = new AppDbContext();

Console.WriteLine("=== Lab 4: Inserting Initial Data ===");
await SeedDataAsync(context);

Console.WriteLine("\n=== Lab 5: Retrieving Data ===");
await RetrieveDataAsync(context);

Console.WriteLine("\n=== Lab 6: Updating and Deleting Records ===");
await UpdateAndDeleteAsync(context);

Console.WriteLine("\n=== Lab 7: Writing Queries with LINQ ===");
await LinqQueriesAsync(context);

static async Task SeedDataAsync(AppDbContext context)
{
    if (await context.Categories.AnyAsync())
    {
        Console.WriteLine("Data already exists. Skipping seed.");
        return;
    }

    var electronics = new Category { Name = "Electronics" };
    var groceries = new Category { Name = "Groceries" };

    await context.Categories.AddRangeAsync(electronics, groceries);

    var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
    var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

    await context.Products.AddRangeAsync(product1, product2);
    await context.SaveChangesAsync();
    Console.WriteLine("Categories and products inserted.");
}

static async Task RetrieveDataAsync(AppDbContext context)
{
    var products = await context.Products.ToListAsync();
    foreach (var p in products)
        Console.WriteLine($"{p.Name} - Rs.{p.Price}");

    var product = await context.Products.FindAsync(1);
    Console.WriteLine($"Found: {product?.Name}");

    var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
    Console.WriteLine($"Expensive: {expensive?.Name}");
}

static async Task UpdateAndDeleteAsync(AppDbContext context)
{
    var laptop = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
    if (laptop != null)
    {
        laptop.Price = 70000;
        await context.SaveChangesAsync();
        Console.WriteLine("Laptop price updated to 70000.");
    }

    var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
    if (toDelete != null)
    {
        context.Products.Remove(toDelete);
        await context.SaveChangesAsync();
        Console.WriteLine("Rice Bag deleted.");
    }
}

static async Task LinqQueriesAsync(AppDbContext context)
{
    var filtered = await context.Products
        .Where(p => p.Price > 1000)
        .OrderByDescending(p => p.Price)
        .ToListAsync();

    Console.WriteLine("Products with price > 1000:");
    foreach (var p in filtered)
        Console.WriteLine($"  {p.Name} - Rs.{p.Price}");

    var productDtos = await context.Products
        .Select(p => new ProductDto
        {
            Name = p.Name,
            Price = p.Price,
            CategoryName = p.Category.Name
        })
        .ToListAsync();

    Console.WriteLine("\nProduct DTOs:");
    foreach (var dto in productDtos)
        Console.WriteLine($"  {dto.Name} ({dto.CategoryName}) - Rs.{dto.Price}");
}
