using System;
using System.Threading.Tasks;
using App.Application.Interfaces;
using App.Application.Models.Request;
using App.Application.Models.Response;
using App.Domain.Models;
using App.Infra.Data.Interfaces;

namespace App.Application.Services
{
    public class UrlAppService : IUrlAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UrlAppService(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }
        #region [Encurtar]
        public async Task<(string,bool)> Encurtar(PostUrl url)
        {
            // TODO USAR AUTO MAPPER
             var urlBD = new UrlBD
            {
                DATA_CRIACAO = DateTime.Now,
                URL_ORIGINAL = url.Url,
                ID = Guid.NewGuid().ToString().Substring(0,8).ToLower()
            };
            //TODO MELHORAR
            try
            {
                _unitOfWork.UrlRepository.Insert(urlBD);
                await _unitOfWork.Commit();
                return (urlBD.ID,true);
            } 
            catch(Exception e)
            {
                return (e.Message, false);
            }
            
        }
        #endregion

        #region GetUrlOriginal

        public async Task<UrlResponse> GetUrlOriginal(string idUrl)
        {
            var result = await _unitOfWork.UrlRepository.GetUrlOriginalBD(idUrl);
            //TODO USAR AUTO MAPPER
            var response = new UrlResponse
            {
                UrlOriginal = result.URL_ORIGINAL,
                DataCriacao = result.DATA_CRIACAO.ToString("dd/MM/yyyy")
            };
            return response;
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