using System;
using System.Threading.Tasks;
using App.Application.Models.Request;
using App.Application.Models.Response;

namespace App.Application.Interfaces
{
    public interface IUrlAppService : IDisposable
    {
        Task<(string,bool)> Encurtar(PostUrl url);
        Task<UrlResponse> GetUrlOriginal(string idUrl);
    }
}