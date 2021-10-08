using Shop.Web.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private Random random;

        public SeedDb(DataContext context)
        {
            _context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Products.Any())
            {
                this.AddProduct("First Product");
                this.AddProduct("Second Product");
                this.AddProduct("Third Product");
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100)
            });
        }

    }
}
