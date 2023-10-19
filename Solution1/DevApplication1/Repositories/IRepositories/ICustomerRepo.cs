using DevApplication1.Models;

namespace DevApplication1.Repositories.IRepositories
{
    public interface ICustomerRepo
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<IEnumerable<Customer>> GetCustomer();
        Task<Customer> GetByIdAsync(int id);
        Task InsertAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Customer customer);
        Task CompleteAsync();

    }
}
