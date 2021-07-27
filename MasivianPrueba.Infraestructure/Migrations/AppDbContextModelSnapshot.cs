﻿// <auto-generated />
using MasivianPrueba.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MasivianPrueba.Infraestructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MasivianPrueba.Core.Entitiy.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("amount")
                        .HasColumnType("int")
                        .HasColumnName("Amount");

                    b.Property<int>("idRoullette")
                        .HasColumnType("int")
                        .HasColumnName("IdRoulette");

                    b.Property<string>("idUser")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IdUser");

                    b.Property<int>("number")
                        .HasColumnType("int")
                        .HasColumnName("Number");

                    b.HasKey("Id");

                    b.HasIndex("idRoullette");

                    b.ToTable("Bet");
                });

            modelBuilder.Entity("MasivianPrueba.Core.Entitiy.Roulette", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("isOpen")
                        .HasColumnType("bit")
                        .HasColumnName("IsOpen");

                    b.HasKey("Id");

                    b.ToTable("Roulette");
                });

            modelBuilder.Entity("MasivianPrueba.Core.Entitiy.Bet", b =>
                {
                    b.HasOne("MasivianPrueba.Core.Entitiy.Roulette", "Roulette")
                        .WithMany("idBets")
                        .HasForeignKey("idRoullette")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roulette");
                });

            modelBuilder.Entity("MasivianPrueba.Core.Entitiy.Roulette", b =>
                {
                    b.Navigation("idBets");
                });
#pragma warning restore 612, 618
        }
    }
}
