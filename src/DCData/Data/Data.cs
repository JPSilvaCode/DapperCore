using DCData.Connection;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DCData.Data
{
    public class Data : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        protected Data(IOptions<ReadConfig> readConfig)
        {
            Connection = new SqlConnection(readConfig.Value.DefaultConnection);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}