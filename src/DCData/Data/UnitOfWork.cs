using DCDomain.Data;

namespace DCData.Data
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly Data _data;

        public UnitOfWork(Data data)
        {
            _data = data;
        }

        public void BeginTransaction()
        {
            _data.Transaction = _data.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _data.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _data.Transaction.Rollback();
            Dispose();
        }

        public void Dispose() => _data.Transaction?.Dispose();
    }
}