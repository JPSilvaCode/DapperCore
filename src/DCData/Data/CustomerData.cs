using Dapper;
using DCData.Connection;
using DCDomain.Data;
using DCDomain.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DCData.Data
{
    public class CustomerData : Data, ICustomerData
    {
        private readonly Data _repositoryBase;
        private readonly IOptions<ReadConfig> _connectionString;

        public CustomerData(Data repositoryBase, IOptions<ReadConfig> connectionString) : base(connectionString)
        {
            _repositoryBase = repositoryBase;
            _connectionString = connectionString;
        }

        #region read
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _repositoryBase.Connection.QueryAsync<Customer>(@"SELECT ID,NAME,EMAIL FROM CUSTOMER;");
        }

        public async Task<Customer> GetByEmail(string email)
        {
            return await _repositoryBase.Connection.QuerySingleAsync<Customer>(@"SELECT ID,NAME,EMAIL FROM CUSTOMER WHERE EMAIL = @EMAIL;", new { email });
        }

        public async Task<Customer> GetById(Guid id)
        {
            return await _repositoryBase.Connection.QuerySingleAsync<Customer>(@"SELECT ID,NAME,EMAIL FROM CUSTOMER WHERE ID = @ID;", new { id });
        }
        #endregion

        #region write
        public async Task Add(Customer customer)
        {
            await _repositoryBase.Connection.ExecuteAsync(@"INSERT INTO CUSTOMER
                    (ID,NAME,EMAIL)                     
                    VALUES  
                    (@ID,@NAME,@EMAIL)", customer);
        }

        public async Task Remove(Guid id)
        {
            await _repositoryBase.Connection.ExecuteAsync(@"DELETE CUSTOMER WHERE ID = @ID", new { id });
        }

        public async Task Update(Customer customer)
        {
            await _repositoryBase.Connection.ExecuteAsync(@"UPDATE CUSTOMER SET
                    NAME = @NAME,EMAIL = @EMAIL                     
                    WHERE ID = @ID", customer);
        }
        #endregion
    }
}