using System;
using System.Threading.Tasks;
using App.Application.Interfaces;
using App.Application.Models.Request;
using App.Domain.Models;
using App.Infra.Data.Interfaces;

namespace App.Application.Services
{
    public class UrlAppService : IUrlAppService
    {
        private readonly IUrlRepository _urlRepository;
        public UrlAppService(IUrlRepository urlRepository){
            _urlRepository = urlRepository;
        }
        #region [Encurtar]
        public async Task<string> Encurtar(FiltroUrl filtro)
        {
            var basePath = "http://localhost:5001/link/";
            var urls = new Urls
            {
                DataCriacao = DateTime.Now,
                UrlOriginal = filtro.Url,
                Key = Guid.NewGuid().ToString().Substring(0,8).ToLower()
            };
            await _urlRepository.Inserir(urls);

            return basePath + urls.Key;
        }
        #endregion

        #region [Dispose]
        public void Dispose()
        {

        }
        #endregion
    }
}