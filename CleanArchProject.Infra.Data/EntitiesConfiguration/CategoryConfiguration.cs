﻿using CleanArchProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchProject.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            // Population
            builder.HasData(
                new Category(1, "Eletrônicos"),
                new Category(2, "Eletrodomesticos"),
                new Category(3, "Acessórios")
            );
        }
    }
}
