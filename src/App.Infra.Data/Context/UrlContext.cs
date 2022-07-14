using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Context
{
    public class UrlContext : DbContext
    {
        public UrlContext(DbContextOptions options) : base(options) { }
        public DbSet<UrlBD> url { get; set; }
    }
}
