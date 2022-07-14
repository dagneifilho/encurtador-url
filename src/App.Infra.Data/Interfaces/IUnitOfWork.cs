using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUrlRepository UrlRepository { get; }
        Task Commit();
    }
}
