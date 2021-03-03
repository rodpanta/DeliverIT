﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestAPI.Models;

namespace RestAPI.Migrations
{
    [DbContext(typeof(TesteDeliverItContext))]
    partial class TesteDeliverItContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:Collation", "Latin1_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestAPI.Models.ContasApagar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DiasEmAtraso")
                        .HasColumnType("int");

                    b.Property<int>("Idfornecedor")
                        .HasColumnName("idfornecedor")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ValorCorrigido")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("ValorOriginal")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("Idfornecedor");

                    b.ToTable("ContasAPagar");
                });

            modelBuilder.Entity("RestAPI.Models.Fornecedore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("RestAPI.Models.ContasApagar", b =>
                {
                    b.HasOne("RestAPI.Models.Fornecedore", "fornecedor")
                        .WithMany("ContasApagars")
                        .HasForeignKey("Idfornecedor")
                        .HasConstraintName("FK_ContasAPagar_Fornecedores")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
