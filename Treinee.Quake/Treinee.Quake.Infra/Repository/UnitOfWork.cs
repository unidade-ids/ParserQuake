using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using Treinee.Quake.Domain.Repository;
using Treinee.Quake.Infra.Context;

namespace Treinee.Quake.Infra.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly QuakeContext _context;
        private IDbContextTransaction _trans;
        private bool _disposed;

        public UnitOfWork(QuakeContext context)
        {
            _context  = context;
            _disposed = false;
        }

        public async Task Commit() => await _trans.CommitAsync();

        public async Task CreateTransaction() => _trans = await _context.Database.BeginTransactionAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                this._disposed = true;
            }
        }

        public async Task RollBack()
        {
            await _trans.RollbackAsync();
            await _trans.DisposeAsync();
        }

        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch 
            {
                throw;
            }
        }
    }
}
