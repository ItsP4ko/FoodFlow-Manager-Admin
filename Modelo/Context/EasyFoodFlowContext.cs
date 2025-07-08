using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Modelo.Models;

namespace Modelo.Context
{
    public partial class EasyFoodFlowContext : DbContext
    {
        public EasyFoodFlowContext() { }

        public EasyFoodFlowContext(DbContextOptions<EasyFoodFlowContext> options)
            : base(options) { }

        // DbSets principales
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cadete> Cadetes { get; set; }
        public virtual DbSet<AdminGeneral> AdminGenerales { get; set; }
        public virtual DbSet<AdminRestaurante> AdminRestaurantes { get; set; }
        public virtual DbSet<AdminCocina> AdminCocinas { get; set; }
        public virtual DbSet<CajeroRestaurante> CajeroRestaurantes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<Restaurante> Restaurantes { get; set; }
        public virtual DbSet<Plato> Platos { get; set; }
        public virtual DbSet<Aderezo> Aderezos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidoPlato> PedidoPlatos { get; set; }
        public virtual DbSet<AderezoPedidoPlato> AderezoPedidoPlatos { get; set; }
        public virtual DbSet<CadetePedido> CadetePedidos { get; set; }
        public virtual DbSet<Tiempo> Tiempos { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=EasyFoodFlow;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Persona base
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Dni);
                entity.ToTable("Persona");

                entity.Property(e => e.Nombre).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Apellido).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Telefono).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);     
            });

            // Herencia de Persona
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Cadete>().ToTable("Cadete");
            modelBuilder.Entity<AdminGeneral>().ToTable("AdminGeneral");
            modelBuilder.Entity<AdminRestaurante>().ToTable("AdminRestaurante");
            modelBuilder.Entity<AdminCocina>().ToTable("AdminCocina");
            modelBuilder.Entity<CajeroRestaurante>().ToTable("CajeroRestaurante");

            // Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Direccion).HasMaxLength(200);
            });

            // Cadete
            modelBuilder.Entity<Cadete>(entity =>
            {
                entity.Property(e => e.Estado).HasMaxLength(20).HasDefaultValue("Activo");
            });

            // AdminGeneral
            modelBuilder.Entity<AdminGeneral>(entity =>
            {
                entity.Property(e => e.NivelAcceso).HasMaxLength(20).HasDefaultValue("Total");
            });

            // AdminRestaurante
            modelBuilder.Entity<AdminRestaurante>(entity =>
            {
                entity.HasOne(d => d.IdRestauranteNavigation)
                      .WithMany(p => p.AdminRestaurantes)
                      .HasForeignKey(d => d.IdRestaurante);
            });

            // AdminCocina
            modelBuilder.Entity<AdminCocina>(entity =>
            {
                entity.HasOne(d => d.IdRestauranteNavigation)
                      .WithMany(p => p.AdminCocinas)
                      .HasForeignKey(d => d.IdRestaurante);
            });

            // CajeroRestaurante
            modelBuilder.Entity<CajeroRestaurante>(entity =>
            {
                entity.HasOne(d => d.Restaurante)
                      .WithMany(p => p.CajeroRestaurantes)
                      .HasForeignKey(d => d.IdRestaurante);
            });

            // Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);
                entity.ToTable("Usuario");

                entity.Property(e => e.NombreUsuario).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Password).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Estado).HasMaxLength(20).HasDefaultValue("Activo");

                entity.HasOne(e => e.DniNavigation)
                      .WithMany(p => p.Usuarios)
                      .HasForeignKey(e => e.Dni);
                entity.HasOne(e => e.IdRolNavigation)
                                      .WithMany(r => r.Usuarios)
                                      .HasForeignKey(e => e.IdRol);
            });

            // Role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol);
                entity.ToTable("Role");

                entity.Property(e => e.Nombre).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Descripcion).HasMaxLength(200);

                entity.HasMany(e => e.RolesHijos)
                      .WithMany(e => e.RolesPadres)
                      .UsingEntity(j => j.ToTable("RoleRole"));

                entity.HasMany(e => e.IdPermisos)
                      .WithMany(p => p.IdRoles)
                      .UsingEntity(j => j.ToTable("RolesPermisos"));
            });

            // Permiso
            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso);
                entity.ToTable("Permiso");

                entity.Property(e => e.Nombre).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Descripcion).HasMaxLength(200);
            });

            // Restaurante
            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.HasKey(e => e.IdRestaurante);
                entity.ToTable("Restaurante");

                entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Direccion).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Deuda).HasColumnType("decimal(18,2)").HasDefaultValue(0);
                entity.Property(e => e.Estado).HasMaxLength(20).HasDefaultValue("Activo");
            });

            // Categoria
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);
                entity.ToTable("Categoria");

                entity.Property(e => e.Nombre).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Descripcion).HasMaxLength(300);
                entity.Property(e => e.Estado).HasDefaultValue(true);
            });

            // Plato
            modelBuilder.Entity<Plato>(entity =>
            {
                entity.HasKey(e => e.IdPlato);
                entity.ToTable("Plato");

                entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.Precio).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.Estado).HasDefaultValue(true);

                entity.HasOne(e => e.IdRestauranteNavigation)
                      .WithMany(r => r.Platos)
                      .HasForeignKey(e => e.IdRestaurante);

                entity.HasOne(e => e.CategoriaNavigation)
                      .WithMany()
                      .HasForeignKey(e => e.Categoria);
            });

            // Aderezo
            modelBuilder.Entity<Aderezo>(entity =>
            {
                entity.HasKey(e => e.IdAderezo);
                entity.ToTable("Aderezo");

                entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Precio).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.Estado).HasDefaultValue(true);
                entity.Property(e => e.Descripcion).HasMaxLength(300);

                entity.HasOne(e => e.IdRestauranteNavigation)
                      .WithMany(r => r.Aderezos)
                      .HasForeignKey(e => e.IdRestaurante);
            });

            // Pedido
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido);
                entity.ToTable("Pedido");

                entity.Property(e => e.Total).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.Estado).HasMaxLength(50).HasDefaultValue("Nuevo");
                entity.Property(e => e.DireccionEntrega).HasMaxLength(300);
                entity.Property(e => e.FechaHoraCreacion).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.MetodoPago).HasMaxLength(50);
                entity.Property(e => e.Observaciones).HasMaxLength(500);

                entity.HasOne(e => e.DniClienteNavigation)
                      .WithMany(c => c.Pedidos)
                      .HasForeignKey(e => e.DniCliente);

                entity.HasOne(e => e.IdRestauranteNavigation)
                      .WithMany(r => r.Pedidos)
                      .HasForeignKey(e => e.IdRestaurante);
            });

            // PedidoPlato
            modelBuilder.Entity<PedidoPlato>(entity =>
            {
                entity.HasKey(e => e.IdPedidoPlato);
                entity.ToTable("PedidoPlato");

                entity.Property(e => e.Cantidad).IsRequired();
                entity.Property(e => e.PrecioMomento).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.Observaciones).HasMaxLength(300);

                entity.HasOne(e => e.IdPedidoNavigation)
                      .WithMany(p => p.PedidoPlatos)
                      .HasForeignKey(e => e.IdPedido);

                entity.HasOne(e => e.IdPlatoNavigation)
                      .WithMany(p => p.PedidoPlatos)
                      .HasForeignKey(e => e.IdPlato);
            });

            // AderezoPedidoPlato
            modelBuilder.Entity<AderezoPedidoPlato>(entity =>
            {
                entity.HasKey(e => e.IdAderezoPedidoPlato);
                entity.ToTable("AderezoPedidoPlato");

                entity.Property(e => e.Cantidad).IsRequired();
                entity.Property(e => e.PrecioMomento).HasColumnType("decimal(18,2)").IsRequired();

                entity.HasOne(e => e.IdAderezoNavigation)
                      .WithMany(a => a.AderezoPedidoPlatos)
                      .HasForeignKey(e => e.IdAderezo);

                entity.HasOne(e => e.IdPedidoPlatoNavigation)
                      .WithMany(p => p.AderezoPedidoPlatos)
                      .HasForeignKey(e => e.IdPedidoPlato);
            });

            // CadetePedido
            modelBuilder.Entity<CadetePedido>(entity =>
            {
                entity.HasKey(e => e.IdCadetePedido);
                entity.ToTable("CadetePedido");

                entity.Property(e => e.FechaAsignacion).HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.DniCadeteNavigation)
                      .WithMany(c => c.CadetePedidos)
                      .HasForeignKey(e => e.DniCadete);

                entity.HasOne(e => e.IdPedidoNavigation)
                      .WithMany(p => p.CadetePedidos)
                      .HasForeignKey(e => e.IdPedido);
            });

            // Tiempo
            modelBuilder.Entity<Tiempo>(entity =>
            {
                entity.HasKey(e => e.IdTiempo);
                entity.ToTable("Tiempo");

                entity.Property(e => e.Inicio).IsRequired();
                entity.Property(e => e.Fase).HasMaxLength(50).IsRequired();

                entity.HasOne(e => e.Pedido)
                      .WithMany(p => p.Tiempos)
                      .HasForeignKey(e => e.IdPedido);
            });

            // Menu
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu);
                entity.ToTable("Menu");

                entity.Property(e => e.Categoria).HasMaxLength(50).IsRequired();
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.Estado).HasDefaultValue(true);

                entity.HasOne(e => e.IdRestauranteNavigation)
                      .WithMany(r => r.Menus)
                      .HasForeignKey(e => e.IdRestaurante);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
