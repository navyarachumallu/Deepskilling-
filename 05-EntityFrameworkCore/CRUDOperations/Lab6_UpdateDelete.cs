// Lab 6: Updating and Deleting Records
// See RetailInventory/Program.cs - UpdateAndDeleteAsync method

using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

await using var context = new AppDbContext();

var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
if (product != null)
{
    product.Price = 70000;
    await context.SaveChangesAsync();
}

var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
if (toDelete != null)
{
    context.Products.Remove(toDelete);
    await context.SaveChangesAsync();
}

Console.WriteLine("Update and delete operations completed.");
