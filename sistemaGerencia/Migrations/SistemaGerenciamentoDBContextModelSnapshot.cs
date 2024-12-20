﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sistemaGerencia.Data;

#nullable disable

namespace sistemaGerencia.Migrations
{
    [DbContext(typeof(SistemaGerenciamentoDBContext))]
    partial class SistemaGerenciamentoDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GrupoModelPermissaoModel", b =>
                {
                    b.Property<int>("gruposIdGrupo")
                        .HasColumnType("int");

                    b.Property<int>("permissoesIdPermissao")
                        .HasColumnType("int");

                    b.HasKey("gruposIdGrupo", "permissoesIdPermissao");

                    b.HasIndex("permissoesIdPermissao");

                    b.ToTable("GrupoModelPermissaoModel");
                });

            modelBuilder.Entity("GrupoModelSistemaModel", b =>
                {
                    b.Property<int>("gruposIdGrupo")
                        .HasColumnType("int");

                    b.Property<int>("sistemasIdSistema")
                        .HasColumnType("int");

                    b.HasKey("gruposIdGrupo", "sistemasIdSistema");

                    b.HasIndex("sistemasIdSistema");

                    b.ToTable("GrupoModelSistemaModel");
                });

            modelBuilder.Entity("GrupoModelUsuarioModel", b =>
                {
                    b.Property<int>("gruposIdGrupo")
                        .HasColumnType("int");

                    b.Property<int>("usuariosIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("gruposIdGrupo", "usuariosIdUsuario");

                    b.HasIndex("usuariosIdUsuario");

                    b.ToTable("GrupoModelUsuarioModel");
                });

            modelBuilder.Entity("sistemaGerencia.Models.GrupoModel", b =>
                {
                    b.Property<int>("IdGrupo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGrupo"), 1L, 1);

                    b.Property<string>("DescricaoGrupo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("NomeGrupo")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.HasKey("IdGrupo");

                    b.ToTable("grupo");
                });

            modelBuilder.Entity("sistemaGerencia.Models.PermissaoModel", b =>
                {
                    b.Property<int>("IdPermissao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPermissao"), 1L, 1);

                    b.Property<string>("DescricaoPermissao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("NomePermissão")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IdPermissao");

                    b.ToTable("permissao");
                });

            modelBuilder.Entity("sistemaGerencia.Models.SistemaModel", b =>
                {
                    b.Property<int>("IdSistema")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSistema"), 1L, 1);

                    b.Property<string>("DescricaoSistema")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("NomeSistema")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IdSistema");

                    b.ToTable("sistema");
                });

            modelBuilder.Entity("sistemaGerencia.Models.UsuarioModel", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IdUsuario");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("GrupoModelPermissaoModel", b =>
                {
                    b.HasOne("sistemaGerencia.Models.GrupoModel", null)
                        .WithMany()
                        .HasForeignKey("gruposIdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaGerencia.Models.PermissaoModel", null)
                        .WithMany()
                        .HasForeignKey("permissoesIdPermissao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrupoModelSistemaModel", b =>
                {
                    b.HasOne("sistemaGerencia.Models.GrupoModel", null)
                        .WithMany()
                        .HasForeignKey("gruposIdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaGerencia.Models.SistemaModel", null)
                        .WithMany()
                        .HasForeignKey("sistemasIdSistema")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrupoModelUsuarioModel", b =>
                {
                    b.HasOne("sistemaGerencia.Models.GrupoModel", null)
                        .WithMany()
                        .HasForeignKey("gruposIdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaGerencia.Models.UsuarioModel", null)
                        .WithMany()
                        .HasForeignKey("usuariosIdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
