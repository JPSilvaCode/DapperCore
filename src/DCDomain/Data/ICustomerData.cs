using DCDomain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DCDomain.Data
{
    public interface ICustomerData : IDisposable
    {
        Task<Customer> GetById(Guid id);
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetByEmail(string email);

        Task Add(Customer customer);
        Task Update(Customer customer);
        Task Remove(Guid id);
    }
}