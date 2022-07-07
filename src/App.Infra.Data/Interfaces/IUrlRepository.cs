using App.Domain.Models;
using System;
using System.Threading.Tasks;

namespace App.Infra.Data.Interfaces
{
    public interface IUrlRepository : IDisposable
    {
        Task<bool> Insert(InsertUrlBD urlBD);
    }
}