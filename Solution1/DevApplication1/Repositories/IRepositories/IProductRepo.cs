using DevApplication1.Models;

namespace DevApplication1.Repositories.IRepositories
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetProduct();
        Task<Product> GetByIdAsync(int id);
        Task InsertAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task CompleteAsync();

        

    }
}
