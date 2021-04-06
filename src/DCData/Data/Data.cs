using System;
using System.Data;
using System.Data.SqlClient;
using DCData.Connection;
using Microsoft.Extensions.Options;

namespace DCData.Data
{
    public class Data : IDisposable
    {
        public IDbConnection Connection { get; }

        public Data(IOptions<ReadConfig> connectionString)
        {
            Connection = new SqlConnection(connectionString.Value.DefaultConnection);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}