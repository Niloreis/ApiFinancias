using Api.TpFinanceiro.Data.Entities;
using Api.TpFinanceiro.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.TpFinanceiro.Data.Contextes
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_ApiFinanceiro;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FinanciasMap());
            modelBuilder.ApplyConfiguration(new TpFinanciasMap());

        }

        public DbSet<Financias> Financias { get; set; }
        public DbSet<TpFinancias> TpFinancias { get; set; }

        }
    }
