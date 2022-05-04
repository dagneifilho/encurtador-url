using System;
using System.Threading.Tasks;
using App.Application.Models.Request;

namespace App.Application.Interfaces
{
    public interface IUrlAppService : IDisposable
    {
        Task<string> Encurtar(FiltroUrl url);
    }
}