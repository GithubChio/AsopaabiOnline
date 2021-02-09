using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace AsopaabiOnline.Modelo
{
    public partial class Contexto : DbContext
    {
        public Contexto()
        {
         
        }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Canton> Canton { get; set; }
        public virtual DbSet<DetallePedido> DetallePedido { get; set; }
        public virtual DbSet<DireccionPedido> DireccionPedido { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }
        public virtual DbSet<HistorialPedido> HistorialPedido { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies(useLazyLoadingProxies: true).UseSqlServer("Server=DESKTOP-GID5PN2;Database=ASOPAABI_ONLINE;User ID=sa;Password=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstLastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.SecondLastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Canton>(entity =>
            {
                entity.ToTable("CANTON");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdProvincia).HasColumnName("id_Provincia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Canton)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CANTON_PROVINCIA");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.ToTable("DETALLE_PEDIDO");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdPedido).HasColumnName("id_Pedido");

                entity.Property(e => e.IdProducto).HasColumnName("id_Producto");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.DetallePedido)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DETALLE_PEDIDO_PEDIDO");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetallePedido)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LISTA_DE_DETALLE_PRODUCTO");
            });

            modelBuilder.Entity<DireccionPedido>(entity =>
            {
                entity.ToTable("DIRECCION_PEDIDO");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Detalles)
                    .IsRequired()
                    .HasColumnName("detalles")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdCanton).HasColumnName("id_Canton");

                entity.Property(e => e.IdCliente)
                    .IsRequired()
                    .HasColumnName("id_Cliente")
                    .HasMaxLength(450);

                entity.Property(e => e.IdDistrito).HasColumnName("id_Distrito");

                entity.Property(e => e.IdProvincia).HasColumnName("id_Provincia");

                entity.HasOne(d => d.IdCantonNavigation)
                    .WithMany(p => p.DireccionPedido)
                    .HasForeignKey(d => d.IdCanton)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DIRECCION_PEDIDO_CANTON");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.DireccionPedido)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DIRECCION_PEDIDO_AspNetUsers");

                entity.HasOne(d => d.IdDistritoNavigation)
                    .WithMany(p => p.DireccionPedido)
                    .HasForeignKey(d => d.IdDistrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DIRECCION_PEDIDO_DISTRITO");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.DireccionPedido)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DIRECCION_PEDIDO_PROVINCIA");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.ToTable("DISTRITO");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCanton).HasColumnName("id_Canton");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCantonNavigation)
                    .WithMany(p => p.Distrito)
                    .HasForeignKey(d => d.IdCanton)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISTRITO_CANTON");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PK___EFMigrationsHistory");

                entity.ToTable("___EFMigrationsHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<HistorialPedido>(entity =>
            {
                entity.ToTable("HISTORIAL_PEDIDO");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCliente)
                    .IsRequired()
                    .HasColumnName("Id_Cliente")
                    .HasMaxLength(450);

                entity.Property(e => e.IdPedido).HasColumnName("Id_Pedido");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.HistorialPedido)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HISTORIAL_PEDIDO_AspNetUsers");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.HistorialPedido)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HISTORIAL_PEDIDO_PEDIDO");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("PAGO");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPedido).HasColumnName("id_Pedido");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.OpcionesDePago).HasColumnName("opcionesDePago");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.Pago)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAGO_PEDIDO");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("PEDIDO");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnName("fecha_Entrega")
                    .HasColumnType("date");

                entity.Property(e => e.FechaPedido)
                    .HasColumnName("fecha_Pedido")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente)
                    .IsRequired()
                    .HasColumnName("id_Cliente")
                    .HasMaxLength(450);

                entity.Property(e => e.IdDireccion).HasColumnName("id_Direccion");

                entity.Property(e => e.Notas)
                    .IsRequired()
                    .HasColumnName("notas")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PEDIDO_AspNetUsers");

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdDireccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PEDIDO_DIRECCION");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoria).HasColumnName("categoria");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasColumnName("imagen")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.UnidadDeMedida).HasColumnName("unidadDeMedida");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.ToTable("PROVINCIA");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

