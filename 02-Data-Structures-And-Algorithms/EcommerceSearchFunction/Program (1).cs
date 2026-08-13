using System;

class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }
}

class Program
{
    static Product LinearSearch(Product[] products, string target)
    {
        foreach (var product in products)
        {
            if (product.ProductName.Equals(target, StringComparison.OrdinalIgnoreCase))
                return product;
        }
        return null;
    }

    static Product BinarySearch(Product[] products, string target)
    {
        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            int comparison = string.Compare(
                products[mid].ProductName,
                target,
                StringComparison.OrdinalIgnoreCase);

            if (comparison == 0)
                return products[mid];

            if (comparison < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return null;
    }

    static void Main()
    {
        Product[] products =
        {
            new Product(101,"Laptop","Electronics"),
            new Product(102,"Mouse","Electronics"),
            new Product(103,"Phone","Electronics"),
            new Product(104,"Tablet","Electronics")
        };

        Console.WriteLine("Linear Search:");
        Product result1 = LinearSearch(products, "Phone");

        if (result1 != null)
            Console.WriteLine($"Found: {result1.ProductName}");

        Array.Sort(products,
            (a,b) => a.ProductName.CompareTo(b.ProductName));

        Console.WriteLine("\nBinary Search:");
        Product result2 = BinarySearch(products, "Phone");

        if (result2 != null)
            Console.WriteLine($"Found: {result2.ProductName}");
    }
}
