﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using zoologicoBlazor.Server;

namespace zoologicoBlazor.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("zoologicoBlazor.Shared.Animal", b =>
                {
                    b.Property<int>("IdAnimal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("EspecieIdEspecie")
                        .HasColumnType("int");

                    b.Property<int>("IdEspecie")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("IdAnimal");

                    b.HasIndex("EspecieIdEspecie");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("zoologicoBlazor.Shared.Cuidador", b =>
                {
                    b.Property<int>("IdCuidador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Funcao")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdCuidador");

                    b.ToTable("Cuidadores");
                });

            modelBuilder.Entity("zoologicoBlazor.Shared.CuidadorAnimal", b =>
                {
                    b.Property<int>("IdCuidador")
                        .HasColumnType("int");

                    b.Property<int>("IdAnimal")
                        .HasColumnType("int");

                    b.Property<string>("Observacoes")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdCuidador", "IdAnimal");

                    b.HasIndex("IdAnimal");

                    b.ToTable("CuidadorAnimais");
                });

            modelBuilder.Entity("zoologicoBlazor.Shared.CuidadorDetails", b =>
                {
                    b.Property<int>("IdCuidadorDetails")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CEP")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Estado")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("IdCuidador")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdCuidadorDetails");

                    b.HasIndex("IdCuidador")
                        .IsUnique();

                    b.ToTable("CuidadorDetails");
                });

            modelBuilder.Entity("zoologicoBlazor.Shared.Especie", b =>
                {
                    b.Property<int>("IdEspecie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdEspecie");

                    b.ToTable("Especies");
                });

            modelBuilder.Entity("zoologicoBlazor.Shared.Animal", b =>
                {
                    b.HasOne("zoologicoBlazor.Shared.Especie", "Especie")
                        .WithMany("Animais")
                        .HasForeignKey("EspecieIdEspecie");
                });

            modelBuilder.Entity("zoologicoBlazor.Shared.CuidadorAnimal", b =>
                {
                    b.HasOne("zoologicoBlazor.Shared.Animal", "Animal")
                        .WithMany("CuidadorAnimais")
                        .HasForeignKey("IdAnimal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("zoologicoBlazor.Shared.Cuidador", "Cuidador")
                        .WithMany("CuidadorAnimais")
                        .HasForeignKey("IdCuidador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("zoologicoBlazor.Shared.CuidadorDetails", b =>
                {
                    b.HasOne("zoologicoBlazor.Shared.Cuidador", "Cuidador")
                        .WithOne("CuidadorDetails")
                        .HasForeignKey("zoologicoBlazor.Shared.CuidadorDetails", "IdCuidador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
