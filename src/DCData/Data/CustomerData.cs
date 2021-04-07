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
        private readonly Data _data;

        public CustomerData(Data repositoryBase, IOptions<ReadConfig> readConfig) : base(readConfig)
        {
            _data = repositoryBase;
        }

        #region read
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _data.Connection.QueryAsync<Customer>(@"SELECT ID,NAME,EMAIL FROM CUSTOMER;",null, _data.Transaction);
        }

        public async Task<Customer> GetByEmail(string email)
        {
            return await _data.Connection.QuerySingleAsync<Customer>(@"SELECT ID,NAME,EMAIL FROM CUSTOMER WHERE EMAIL = @EMAIL;", new { email }, _data.Transaction);
        }

        public async Task<Customer> GetById(Guid id)
        {
            return await _data.Connection.QuerySingleAsync<Customer>(@"SELECT ID,NAME,EMAIL FROM CUSTOMER WHERE ID = @ID;", new { id }, _data.Transaction);
        }
        #endregion

        #region write
        public async Task Add(Customer customer)
        {
            await _data.Connection.ExecuteAsync(@"INSERT INTO CUSTOMER
                    (ID,NAME,EMAIL)                     
                    VALUES  
                    (@ID,@NAME,@EMAIL)", customer, _data.Transaction);
        }

        public async Task Remove(Guid id)
        {
            await _data.Connection.ExecuteAsync(@"DELETE CUSTOMER WHERE ID = @ID", new { id }, _data.Transaction);
        }

        public async Task Update(Customer customer)
        {
            await _data.Connection.ExecuteAsync(@"UPDATE CUSTOMER SET
                    NAME = @NAME,EMAIL = @EMAIL                     
                    WHERE ID = @ID", customer, _data.Transaction);
        }
        #endregion
    }
}