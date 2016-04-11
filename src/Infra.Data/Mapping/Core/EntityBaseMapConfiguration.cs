using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Core;

namespace Infra.Data.Mapping.Core
{
    public class EntityBaseMapConfiguration<T>: EntityTypeConfiguration<T> where T: EntityBase
    {

        public EntityBaseMapConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("datetime2")
                .IsRequired();
            Property(p => p.DataAlteracao)
                .HasColumnName("DataAlteracao")
                .HasColumnType("datetime2")
                .IsOptional();
            Property(p => p.Ativo)
                .HasColumnName("Ativo")
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}
