﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjetoNegocie.DAL.Data;

namespace ProjetoNegocie.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ProjetoNegocie.Negocio.Dominio.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("text")
                        .HasColumnName("bairro");

                    b.Property<string>("Cep")
                        .HasColumnType("text")
                        .HasColumnName("cep");

                    b.Property<string>("Complemento")
                        .HasColumnType("text")
                        .HasColumnName("complemento");

                    b.Property<int>("DDD")
                        .HasColumnType("integer")
                        .HasColumnName("ddd");

                    b.Property<string>("GIA")
                        .HasColumnType("text")
                        .HasColumnName("gia");

                    b.Property<string>("IBGE")
                        .HasColumnType("text")
                        .HasColumnName("ibge");

                    b.Property<string>("Localidade")
                        .HasColumnType("text")
                        .HasColumnName("localidade");

                    b.Property<string>("Logradouro")
                        .HasColumnType("text")
                        .HasColumnName("logradouro");

                    b.Property<string>("SIAFI")
                        .HasColumnType("text")
                        .HasColumnName("siafi");

                    b.Property<string>("UF")
                        .HasColumnType("text")
                        .HasColumnName("uf");

                    b.HasKey("Id");

                    b.ToTable("app_negocie_endereco");
                });
#pragma warning restore 612, 618
        }
    }
}