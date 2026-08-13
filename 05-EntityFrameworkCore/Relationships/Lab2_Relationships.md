Lab 2: Category-Product Relationship (One-to-Many)
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
Configured in AppDbContext.OnModelCreating:

One Category has many Products
Foreign key: Product.CategoryId -> Category.Id
See RetailInventory/Models/ and RetailInventory/Data/AppDbContext.cs
