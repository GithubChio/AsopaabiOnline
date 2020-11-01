using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public DbSet<AspNetRoles> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public DbSet<AspNetUsers> AspNetUsers { get; set; }
        public DbSet<Canton> Canton { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ClienteTelefono> ClienteTelefono { get; set; }
        public DbSet<DetallePedido> DetallePedido { get; set; }
        public DbSet<DireccionPedido> DireccionPedido { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<HistorialPedido> HistorialPedido { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
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

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

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

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

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
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Canton)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CANTON_PROVINCIA");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.TipoDni).HasColumnName("TipoDni");
                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDeNacimiento).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDeCliente).HasColumnName("TipoDeCliente");
                entity.Property(e => e.TipoActividad).HasColumnName("TipoActividad");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_AspNetUsers");
            });

            modelBuilder.Entity<ClienteTelefono>(entity =>
            {
                entity.ToTable("CLIENTE_TELEFONO");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCliente).HasColumnName("id_Cliente");

                entity.Property(e => e.Telefono1).HasColumnName("telefono_1");

                entity.Property(e => e.Telefono2).HasColumnName("telefono_2");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ClienteTelefono)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENTE_TELEFONO_Cliente");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.ToTable("DETALLE_PEDIDO");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Detalles)
                    .IsRequired()
                    .HasColumnName("detalles")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdCanton).HasColumnName("id_Canton");

                entity.Property(e => e.IdDistrito).HasColumnName("id_Distrito");

                entity.Property(e => e.IdProvincia).HasColumnName("id_Provincia");

                entity.HasOne(d => d.IdCantonNavigation)
                    .WithMany(p => p.DireccionPedido)
                    .HasForeignKey(d => d.IdCanton)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DIRECCION_PEDIDO_CANTON");

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
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCantonNavigation)
                    .WithMany(p => p.Distrito)
                    .HasForeignKey(d => d.IdCanton)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISTRITO_CANTON");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("EMPLEADO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdPedido).HasColumnName("Id_Pedido");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnName("Id_Usuario")
                    .HasMaxLength(450);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("primerApellido")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasColumnName("primerNombre")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasColumnName("segundoApellido")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasColumnName("segundoNombre")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDeEmpleado).HasColumnName("tipoDeEmpleado");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLEADO_PEDIDO");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLEADO_AspNetUsers");
            });

            modelBuilder.Entity<HistorialPedido>(entity =>
            {
                entity.ToTable("HISTORIAL_PEDIDO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.IdPedido).HasColumnName("Id_Pedido");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.HistorialPedido)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HISTORIAL_PEDIDO_Cliente");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.HistorialPedido)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HISTORIAL_PEDIDO_PEDIDO");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("PAGO");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnName("fecha_Entrega")
                    .HasColumnType("date");

                entity.Property(e => e.FechaPedido)
                    .HasColumnName("fecha_Pedido")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("id_Cliente");

                entity.Property(e => e.IdDireccion).HasColumnName("id_Direccion");

                entity.Property(e => e.Notas)
                    .IsRequired()
                    .HasColumnName("notas")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDePago).HasColumnName("tipoDePago");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PEDIDO_Cliente");

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdDireccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PEDIDO_DIRECCION");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Categoria).HasColumnName("categoria");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasColumnName("imagen")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioCosto).HasColumnName("precioCosto");

                entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");

                entity.Property(e => e.UnidadDeMedida)
                    .IsRequired()
                    .HasColumnName("unidadDeMedida")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Utilidad).HasColumnName("utilidad");
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
