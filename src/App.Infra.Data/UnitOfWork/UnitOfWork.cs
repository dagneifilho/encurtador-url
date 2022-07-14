using App.Infra.Data.Context;
using App.Infra.Data.Interfaces;
using App.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.UnitOfWork
{
     public class UnitOfWork : IUnitOfWork
     {
        private IUrlRepository _repository;
        private readonly UrlContext _context;
        public UnitOfWork(UrlContext context, IUrlRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public IUrlRepository UrlRepository
        {
            get
            {
                if(_repository == null)
                    _repository = new UrlRepository(_context);
                return _repository;
            }
           
        }
        public async Task Commit()
        {
           await _context.SaveChangesAsync();
        }

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
