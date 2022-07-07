using System.Data;

namespace App.Infra.Data.Dapper
{
    public interface IConnectionFactory
    {
        IDbConnection Connection();
    }
}
