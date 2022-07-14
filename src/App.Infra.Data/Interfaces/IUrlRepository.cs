using App.Domain.Models;
using System;
using System.Threading.Tasks;

namespace App.Infra.Data.Interfaces
{
    public interface IUrlRepository : IDisposable
    {
        void Insert(UrlBD urlBD);
        Task<UrlBD> GetUrlOriginalBD(string id);
    }
}