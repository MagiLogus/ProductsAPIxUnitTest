using Microsoft.EntityFrameworkCore;
using ProductsAPI.Domains;
using static ProductsAPI.Domains.Products;

namespace ProductsAPI.Context
{
    public class ContextAPP : DbContext
    {
        // Define as entidades do banco de dados dbset
        public DbSet<Products> Products { get; set; }

        // Construtor que aceita DbContextOptions
        public ContextAPP(DbContextOptions<ContextAPP> options) : base(options)
        {
        }

        // O OnConfiguring não é mais necessário se você estiver usando AddDbContext para configuração
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=NOTE02-SALA21\\SQLEXPRESS; Database=ProductsAPI; user Id=sa; pwd=Senai@134; TrustServerCertificate=true;");
        //     base.OnConfiguring(optionsBuilder); // objeto com as configuracoes definidas 
        // }
    }
}

