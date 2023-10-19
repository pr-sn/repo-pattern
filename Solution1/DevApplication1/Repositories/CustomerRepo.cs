using DevApplication1.Models;
using DevApplication1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DevApplication1.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ProductDbContext _db;
        public CustomerRepo(ProductDbContext db)
        {
            this._db = db;
        }
        public async Task CompleteAsync()
        {
            await _db.SaveChangesAsync();   
        }

      

        public async Task DeleteAsync(Customer customer)
        {
           _db.Entry(customer).State=EntityState.Deleted;
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            //return await _db.Customers.FirstAsync(c => c.CustomerId == id);
            return await _db.Customers.FirstAsync(c=>c.CustomerId==id); 
        }

        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task InsertAsync(Customer customer)
        {
            await _db.Customers.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
           _db.Entry(customer).State= EntityState.Modified;
            await Task.CompletedTask;
        }
    }
}
