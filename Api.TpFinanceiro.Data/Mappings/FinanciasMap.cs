using Api.TpFinanceiro.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.TpFinanceiro.Data.Mappings
{
    public class FinanciasMap : IEntityTypeConfiguration<Financias>
    {
        public void Configure(EntityTypeBuilder<Financias> builder)
        {
            builder.ToTable("FINACIAS");

            builder.HasKey(p => p.IdFinancias);

            builder.Property(c => c.IdFinancias)
              .HasColumnName("IDFINANCIAS");


            builder.Property(c => c.Nome)
              .HasColumnName("NOME")
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(c => c.Valor)
             .HasColumnName("VALOR")
             .HasMaxLength(50)
             .IsRequired();

            builder.Property(c => c.Meta)
             .HasColumnName("META")
             .HasMaxLength(50)
             .IsRequired();


            builder.Property(p => p.Date)
              .HasColumnName("DATA")
              .IsRequired();

            builder.Property(c => c.Obs)
              .HasColumnName("OBS")
              .HasMaxLength(500)
              .IsRequired();

            builder.Property(p => p.IdTpFinancias)
            .HasColumnName("IDTPFINANCIAS")
            .IsRequired();


            builder.HasOne(p => p.Tpfinancias) //FINANCIAS TEM 1 TP
              .WithMany(c => c.Financias) //TP TEM MUITAS FINANCIAS
              .HasForeignKey(p => p.IdTpFinancias); //Chave estrangeira


        }

    }
}
