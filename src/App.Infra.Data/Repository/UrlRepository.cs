using App.Domain.Models;
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
        private readonly IConnectionFactory _dbConnection;

        public UrlRepository(IConnectionFactory connection)
        {
            _dbConnection = connection;
        }
        public void Dispose()
        {
            _dbConnection.Connection().Dispose();
        }

        public async Task<dynamic> Inserir(Urls urls)
        {
            DynamicParameters parameters = new DynamicParameters();
            var query = @"INSERT INTO URL (ID, URL_ORIGINAL, DATA_CRIACAO) VALUES (@id, @urlOriginal, @dataCriacao)";
            parameters.Add("@id",urls.ID,DbType.String,ParameterDirection.Input);
            parameters.Add("@urlOriginal", urls.URL_ORIGINAL,DbType.String,ParameterDirection.Input);
            parameters.Add("@dataCriacao", urls.DATA_CRIACAO.ToString("yyyy/MM/dd"), DbType.Date, ParameterDirection.Input);
            
            using (var connection = _dbConnection.Connection())
            {
                return await connection.QueryAsync(query, parameters);
            }
          
        }
    }
}
