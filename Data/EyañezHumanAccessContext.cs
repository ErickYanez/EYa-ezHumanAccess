using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data;

public partial class EyañezHumanAccessContext : DbContext
{
    public EyañezHumanAccessContext()
    {
    }

    public EyañezHumanAccessContext(DbContextOptions<EyañezHumanAccessContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<ArticuloTiendum> ArticuloTienda { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClienteArticulo> ClienteArticulos { get; set; }

    public virtual DbSet<Colonium> Colonia { get; set; }

    public virtual DbSet<DireccionCliente> DireccionClientes { get; set; }

    public virtual DbSet<DireccionTiendum> DireccionTienda { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Tiendum> Tienda { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-6PGUJ6P1\\SQLEXPRESS; Database=EYañezHumanAccess; Trusted_Connection=True; User ID=sa; Password=pass@word1;TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.IdArticulo).HasName("PK__Articulo__F8FF5D5239812C07");

            entity.ToTable("Articulo");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Imagen).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<ArticuloTiendum>(entity =>
        {
            entity.HasKey(e => e.IdArticuloTienda).HasName("PK__Articulo__C1C0F1E599FDE0C4");

            entity.Property(e => e.Fecha).HasColumnType("date");

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.ArticuloTienda)
                .HasForeignKey(d => d.IdArticulo)
                .HasConstraintName("FK__ArticuloT__IdArt__4E88ABD4");

            entity.HasOne(d => d.IdTiendaNavigation).WithMany(p => p.ArticuloTienda)
                .HasForeignKey(d => d.IdTienda)
                .HasConstraintName("FK__ArticuloT__IdTie__4F7CD00D");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D5946642B442088F");

            entity.ToTable("Cliente");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClienteArticulo>(entity =>
        {
            entity.HasKey(e => e.IdClienteArticulo).HasName("PK__ClienteA__97A01AB33C9C67D1");

            entity.ToTable("ClienteArticulo");

            entity.Property(e => e.Fecha).HasColumnType("date");

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.ClienteArticulos)
                .HasForeignKey(d => d.IdArticulo)
                .HasConstraintName("FK__ClienteAr__IdArt__534D60F1");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ClienteArticulos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__ClienteAr__IdCli__52593CB8");
        });

        modelBuilder.Entity<Colonium>(entity =>
        {
            entity.HasKey(e => e.IdColonia).HasName("PK__Colonia__A1580F6605267B4E");

            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Colonia)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK__Colonia__IdMunic__4222D4EF");
        });

        modelBuilder.Entity<DireccionCliente>(entity =>
        {
            entity.HasKey(e => e.IdDireccionCliente).HasName("PK__Direccio__1F8E0C768C0F8955");

            entity.ToTable("DireccionCliente");

            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroExterior)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroInterior)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.DireccionClientes)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Direccion__IdCli__45F365D3");

            entity.HasOne(d => d.IdColoniaNavigation).WithMany(p => p.DireccionClientes)
                .HasForeignKey(d => d.IdColonia)
                .HasConstraintName("FK__Direccion__IdCol__44FF419A");
        });

        modelBuilder.Entity<DireccionTiendum>(entity =>
        {
            entity.HasKey(e => e.IdDireccionTienda).HasName("PK__Direccio__1F8E0C76FD285A7B");

            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroExterior)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroInterior)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdColoniaNavigation).WithMany(p => p.DireccionTienda)
                .HasForeignKey(d => d.IdColonia)
                .HasConstraintName("FK__Direccion__IdCol__48CFD27E");

            entity.HasOne(d => d.IdTiendaNavigation).WithMany(p => p.DireccionTienda)
                .HasForeignKey(d => d.IdTienda)
                .HasConstraintName("FK__Direccion__IdTie__49C3F6B7");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__FBB0EDC132E085D3");

            entity.ToTable("Estado");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Estados)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("FK__Estado__IdPais__3C69FB99");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__Municipi__61005978A53F43CC");

            entity.ToTable("Municipio");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Municipio__IdEst__3F466844");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PK__Pais__FC850A7B35CE161D");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584CFBF7C6AC");

            entity.ToTable("Rol");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tiendum>(entity =>
        {
            entity.HasKey(e => e.IdTienda).HasName("PK__Tienda__5A1EB96B2C8DCE86");

            entity.Property(e => e.Sucursal)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97544F9495");

            entity.ToTable("Usuario");

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Imagen).IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Usuario__IdClien__5AEE82B9");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__IdRol__59FA5E80");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
