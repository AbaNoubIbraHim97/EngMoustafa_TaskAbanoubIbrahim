using Product.Infrastrucre.Context;

namespace Product.Infrastrucre
{
    public static class ProductDbContextSeed
    {
        public static void Seed(ProductDbContext context)
        {
            if (!context.Product.Any())
            {
                var products = new List<Product.Domain.Models.Product>
            {
                new Product.Domain.Models.Product { Name = "Product 1", Description = "Description 1", Price = 10.00m,Email="abanoub@gmail.com",PhoneNumber="+201208437308" },
                new Product.Domain.Models.Product { Name = "Product 2", Description = "Description 2", Price = 20.00m ,Email="abanoub@gmail.com",PhoneNumber="+201208437308"},
                new Product.Domain.Models.Product {Name = "Product 3", Description = "Description 3", Price = 30.00m, Email = "abanoub@gmail.com", PhoneNumber = "+201208437308"}
            };

                context.Product.AddRange(products);
                context.SaveChanges();
            }
        }
    }

}
