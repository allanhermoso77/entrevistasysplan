using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SysplanSolution.Model;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SysplanSolution.Data
{
    public class SysplanSolutionContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public SysplanSolutionContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
              .ToTable("Cliente");

            modelBuilder.Entity<Cliente>()
                .Property(u => u.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(u => u.Idade)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
