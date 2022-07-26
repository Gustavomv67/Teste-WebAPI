using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste_WebAPI.Models;

namespace Teste_WebAPI.Data
{
    public class Teste_WebAPIContext : DbContext
    {
        public Teste_WebAPIContext (DbContextOptions<Teste_WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Teste_WebAPI.Models.Funcionario> Funcionario { get; set; } = default!;
    }
}
