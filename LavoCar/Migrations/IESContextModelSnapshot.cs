﻿// <auto-generated />
using System;
using LavoCar.Conexao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LavoCar.Migrations
{
    [DbContext(typeof(IESContext))]
    partial class IESContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LavoCar.Controllers.Carro", b =>
                {
                    b.Property<long?>("CarroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<long?>("ClienteID")
                        .HasColumnType("bigint");

                    b.Property<long?>("MarcaModeloID")
                        .HasColumnType("bigint");

                    b.Property<string>("Placa")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("CarroID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("MarcaModeloID");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("LavoCar.Controllers.Lavagem", b =>
                {
                    b.Property<long?>("LavID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CarroID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataLav")
                        .HasColumnType("datetime2");

                    b.Property<long?>("FuncionarioID")
                        .HasColumnType("bigint");

                    b.Property<long?>("TipoLavagemID")
                        .HasColumnType("bigint");

                    b.HasKey("LavID");

                    b.HasIndex("CarroID");

                    b.HasIndex("FuncionarioID");

                    b.HasIndex("TipoLavagemID");

                    b.ToTable("Lavagens");
                });

            modelBuilder.Entity("LavoCar.Controllers.Reparo", b =>
                {
                    b.Property<long?>("ReparoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CarroID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataReparo")
                        .HasColumnType("datetime2");

                    b.Property<long?>("TipoReparoID")
                        .HasColumnType("bigint");

                    b.HasKey("ReparoID");

                    b.HasIndex("CarroID");

                    b.HasIndex("TipoReparoID");

                    b.ToTable("Reparos");
                });

            modelBuilder.Entity("LavoCar.Controllers.TipoLavagem", b =>
                {
                    b.Property<long?>("TipoLavID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("DescTipoLav")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecoTipoLav")
                        .HasColumnType("float");

                    b.HasKey("TipoLavID");

                    b.ToTable("TipoLavagens");
                });

            modelBuilder.Entity("LavoCar.Controllers.TipoReparo", b =>
                {
                    b.Property<long?>("TipoReparoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("DescTipoReparo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecoTipoReparo")
                        .HasColumnType("float");

                    b.HasKey("TipoReparoID");

                    b.ToTable("TipoReparos");
                });

            modelBuilder.Entity("LavoCar.Models.Cliente", b =>
                {
                    b.Property<long?>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("EndCliente")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FoneCliente")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("LavoCar.Models.Funcionario", b =>
                {
                    b.Property<long?>("FuncionarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("EndFuncionario")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FoneFuncionario")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("NomeFuncionario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FuncionarioID");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("LavoCar.Models.Infra.UsuarioDaAplicacao", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("LavoCar.Models.MarcaModelo", b =>
                {
                    b.Property<long?>("MarcaModeloID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("DescMarcaModelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MarcaModeloID");

                    b.ToTable("MarcaModelos");
                });

            modelBuilder.Entity("LavoCar.Models.Recibo", b =>
                {
                    b.Property<long?>("ReciboID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CarroID")
                        .HasColumnType("bigint");

                    b.Property<long?>("ClienteID")
                        .HasColumnType("bigint");

                    b.Property<long?>("LavagemID")
                        .HasColumnType("bigint");

                    b.Property<long?>("TipoLavagemID")
                        .HasColumnType("bigint");

                    b.HasKey("ReciboID");

                    b.HasIndex("CarroID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("LavagemID");

                    b.HasIndex("TipoLavagemID");

                    b.ToTable("Recibos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LavoCar.Controllers.Carro", b =>
                {
                    b.HasOne("LavoCar.Models.Cliente", "Cliente")
                        .WithMany("Carros")
                        .HasForeignKey("ClienteID");

                    b.HasOne("LavoCar.Models.MarcaModelo", "MarcaModelo")
                        .WithMany("Carros")
                        .HasForeignKey("MarcaModeloID");

                    b.Navigation("Cliente");

                    b.Navigation("MarcaModelo");
                });

            modelBuilder.Entity("LavoCar.Controllers.Lavagem", b =>
                {
                    b.HasOne("LavoCar.Controllers.Carro", "Carro")
                        .WithMany("Lavagens")
                        .HasForeignKey("CarroID");

                    b.HasOne("LavoCar.Models.Funcionario", "Funcionario")
                        .WithMany("Lavagens")
                        .HasForeignKey("FuncionarioID");

                    b.HasOne("LavoCar.Controllers.TipoLavagem", "TipoLavagem")
                        .WithMany("Lavagens")
                        .HasForeignKey("TipoLavagemID");

                    b.Navigation("Carro");

                    b.Navigation("Funcionario");

                    b.Navigation("TipoLavagem");
                });

            modelBuilder.Entity("LavoCar.Controllers.Reparo", b =>
                {
                    b.HasOne("LavoCar.Controllers.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroID");

                    b.HasOne("LavoCar.Controllers.TipoReparo", "TipoReparo")
                        .WithMany("Reparos")
                        .HasForeignKey("TipoReparoID");

                    b.Navigation("Carro");

                    b.Navigation("TipoReparo");
                });

            modelBuilder.Entity("LavoCar.Models.Recibo", b =>
                {
                    b.HasOne("LavoCar.Controllers.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroID");

                    b.HasOne("LavoCar.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID");

                    b.HasOne("LavoCar.Controllers.Lavagem", "Lavagem")
                        .WithMany()
                        .HasForeignKey("LavagemID");

                    b.HasOne("LavoCar.Controllers.TipoLavagem", "TipoLavagem")
                        .WithMany()
                        .HasForeignKey("TipoLavagemID");

                    b.Navigation("Carro");

                    b.Navigation("Cliente");

                    b.Navigation("Lavagem");

                    b.Navigation("TipoLavagem");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LavoCar.Models.Infra.UsuarioDaAplicacao", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LavoCar.Models.Infra.UsuarioDaAplicacao", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LavoCar.Models.Infra.UsuarioDaAplicacao", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LavoCar.Models.Infra.UsuarioDaAplicacao", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LavoCar.Controllers.Carro", b =>
                {
                    b.Navigation("Lavagens");
                });

            modelBuilder.Entity("LavoCar.Controllers.TipoLavagem", b =>
                {
                    b.Navigation("Lavagens");
                });

            modelBuilder.Entity("LavoCar.Controllers.TipoReparo", b =>
                {
                    b.Navigation("Reparos");
                });

            modelBuilder.Entity("LavoCar.Models.Cliente", b =>
                {
                    b.Navigation("Carros");
                });

            modelBuilder.Entity("LavoCar.Models.Funcionario", b =>
                {
                    b.Navigation("Lavagens");
                });

            modelBuilder.Entity("LavoCar.Models.MarcaModelo", b =>
                {
                    b.Navigation("Carros");
                });
#pragma warning restore 612, 618
        }
    }
}
