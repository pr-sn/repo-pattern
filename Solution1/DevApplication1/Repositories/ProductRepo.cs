using DevApplication1.Models;
using DevApplication1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DevApplication1.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductDbContext _db;
        public ProductRepo(ProductDbContext db)
        {
            this._db = db;  
        }
    

        public Task CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Product product)
        {
            _db.Entry(product).State= EntityState.Deleted;
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
          return await _db.Products.ToListAsync();  
        }

        public async Task<Product> GetByIdAsync(int id)
        {
      
            return await _db.Products.FirstAsync(x=>x.ProductId == id);
        }

        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task InsertAsync(Product product)
        {
             await _db.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
           _db.Entry(product).State= EntityState.Modified;
            await Task.CompletedTask;
        }
    }
}
