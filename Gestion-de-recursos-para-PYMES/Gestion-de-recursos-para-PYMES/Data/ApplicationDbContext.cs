using Gestion_de_recursos_para_PYMES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_recursos_para_PYMES.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios => Users;
        public DbSet<MovimientoInventario> MovimientosInventario { get; set; }
        public DbSet<DetalleMovimiento> DetallesMovimiento { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<MovimientoInventario>()
                .HasOne(m => m.Usuario)
                .WithMany(u => u.MovimientosInventario)
                .HasForeignKey(m => m.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<MovimientoInventario>()
                .HasOne(m => m.Proveedor)
                .WithMany(p => p.MovimientosInventario)
                .HasForeignKey(m => m.ProveedorId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<DetalleMovimiento>()
                .HasOne(d => d.MovimientoInventario)
                .WithMany(m => m.Detalles)
                .HasForeignKey(d => d.MovimientoId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<DetalleMovimiento>()
                .HasOne(d => d.Producto)
                .WithMany()
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Producto>()
                .HasIndex(p => p.CodigoSKU)
                .IsUnique();
        }
    }
}