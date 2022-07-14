using App.Domain.Models;
using App.Infra.Data.Context;
using App.Infra.Data.Dapper;
using App.Infra.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repository
{
    public class UrlRepository : IUrlRepository
    {
        private readonly UrlContext _context;
        public UrlRepository(UrlContext context)
        {
            _context = context;
        }


        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Insert(UrlBD urlBD)
        {
             _context.url.Add(urlBD);
        }
        public async Task<UrlBD> GetUrlOriginalBD(string id)
        {
            return await _context.url.FindAsync(id);
        }
    }
}
