using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        //sobreescreve o metodo Configure herdando da convercao, e altera as proriedades definidas no metodo sobreescrito
        public void Configure(EntityTypeBuilder<Category> builder){
            //usando uma expressao lambda para buscar as propriedades do modelo

            //minha prop eh minha chave primaria da tabela
            builder.HasKey(t => t.Id);

            //indica que o Name tem um limite maximo de 100 caracteres e nao pode ser nullable
            builder
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();


            //seeding de dados
            builder.HasData(
                new Category(1, "Material Escolar"),
                new Category(2, "Eletronicos"),
                new Category(3, "Acessorios")
            );
        }
    }
}