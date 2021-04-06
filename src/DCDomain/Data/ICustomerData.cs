using DCDomain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DCDomain.Data
{
    public interface ICustomerData : IDisposable
    {
        Task GetById(Guid id);
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetByEmail(string email);

        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}