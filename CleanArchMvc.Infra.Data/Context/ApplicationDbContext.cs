using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories {get; set;}
        public DbSet<Product> Products {get; set;}

        //configura o modelo para utilizar a Fluent API
        //Este metodo aplica as confs das entidades que sao defionas no assembler
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            
            base.OnModelCreating(modelBuilder);
            //usando o typeof ele vasculha todos os tipos e aplica utilizando o reflexion
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        } 
        
    }
}