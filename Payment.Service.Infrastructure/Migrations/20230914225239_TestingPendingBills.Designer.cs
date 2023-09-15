﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payment.Service.Infrastructure.EF.Contexts;

#nullable disable

namespace Payment.Service.Infrastructure.Migrations
{
    [DbContext(typeof(ReadDBContext))]
    [Migration("20230914225239_TestingPendingBills")]
    partial class TestingPendingBills
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Payment.Service.Infrastructure.EF.ReadModel.BillReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("billId");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("amount");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT")
                        .HasColumnName("categoryId");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT")
                        .HasColumnName("clientId");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT")
                        .HasColumnName("period");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT")
                        .HasColumnName("state");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClientId");

                    b.ToTable("bill");
                });

            modelBuilder.Entity("Payment.Service.Infrastructure.EF.ReadModel.CategoryReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("categoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("Payment.Service.Infrastructure.EF.ReadModel.ClientReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("clientId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("client");
                });

            modelBuilder.Entity("Payment.Service.Infrastructure.EF.ReadModel.BillReadModel", b =>
                {
                    b.HasOne("Payment.Service.Infrastructure.EF.ReadModel.CategoryReadModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Payment.Service.Infrastructure.EF.ReadModel.ClientReadModel", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
