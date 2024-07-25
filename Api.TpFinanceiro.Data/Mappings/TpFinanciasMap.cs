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
    public class TpFinanciasMap: IEntityTypeConfiguration<TpFinancias>
    {
        public void Configure(EntityTypeBuilder<TpFinancias> builder)
        {
            builder.ToTable("TPFINANCEIRO");

            builder.HasKey(c => c.IdTPFinancias);

            builder.Property(c => c.IdTPFinancias)
              .HasColumnName("IDFINANCIAS");


            builder.Property(c => c.Nome)
              .HasColumnName("NOME")
              .HasMaxLength(50)
              .IsRequired();


        }

    }
}
