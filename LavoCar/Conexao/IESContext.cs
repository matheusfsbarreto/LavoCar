using LavoCar.Controllers;
using LavoCar.Models;
using LavoCar.Models.Infra;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Conexao
{
    public class IESContext : IdentityDbContext<UsuarioDaAplicacao>
    {
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<MarcaModelo> MarcaModelos { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Lavagem> Lavagens { get; set; }
        public DbSet<TipoLavagem> TipoLavagens { get; set; }
        
        public DbSet<Reparo> Reparos { get; set; }
        public DbSet<TipoReparo> TipoReparos { get; set; }

        public DbSet<Recibo> Recibos { get; set; }
    }
}
