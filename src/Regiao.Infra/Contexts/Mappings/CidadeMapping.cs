﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Regiao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Regiao.Infra.Contexts.Mappings;

public class CidadeMapping : IEntityTypeConfiguration<Cidade>
{
    public void Configure(EntityTypeBuilder<Cidade> builder)
    {
        builder.ToTable("Cidades");

        builder
            .Property(c => c.Id)
            .IsRequired();

        builder
            .HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.HasOne(c => c.Regiao)
            .WithMany(c => c.Cidades).HasPrincipalKey(u => u.Id);
    }
}
