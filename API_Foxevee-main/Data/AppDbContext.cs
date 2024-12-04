using Microsoft.Win32;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using ApiJogo.Modal;

namespace ApiJogo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TotalTimeRegistro> TotalTimeRegistro { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Se necessário, configure nomes de colunas, chaves, etc.
            modelBuilder.Entity<TotalTimeRegistro>()
                .ToTable("TotalTime");
        }
    }
}


