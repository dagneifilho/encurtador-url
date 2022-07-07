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
        public async Task<string> Encurtar(PostUrl url)
        {
            var basePath = "http://localhost:5001/link/";
            var urlBD = new InsertUrlBD
            {
                DATA_CRIACAO = DateTime.Now,
                URL_ORIGINAL = url.Url,
                ID = Guid.NewGuid().ToString().Substring(0,8).ToLower()
            };
            await _urlRepository.Insert(urlBD);

            return basePath + urlBD.ID;
        }
        #endregion

        #region [Dispose]
        public void Dispose()
        {
            
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}