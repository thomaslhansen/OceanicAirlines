﻿// <auto-generated />
using System;
using CESParcelDeliverySystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CESParcelDeliverySystem.Migrations
{
    [DbContext(typeof(CesContext))]
    [Migration("20211209180552_TypeNullableFee")]
    partial class TypeNullableFee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CESParcelDeliverySystem.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CESParcelDeliverySystem.Models.Config", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DurationInHours")
                        .HasColumnType("int");

                    b.Property<int>("MaxDimension")
                        .HasColumnType("int");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Config");
                });

            modelBuilder.Entity("CESParcelDeliverySystem.Models.Connection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FromLocationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Moves")
                        .HasColumnType("int");

                    b.Property<int?>("ToLocationId")
                        .HasColumnType("int");

                    b.Property<string>("TransportationMode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FromLocationId");

                    b.HasIndex("ToLocationId");

                    b.ToTable("Connection");
                });

            modelBuilder.Entity("CESParcelDeliverySystem.Models.Costumer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Costumer");
                });

            modelBuilder.Entity("CESParcelDeliverySystem.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("CESParcelDeliverySystem.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CostumerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("FromLocationId")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("ToLocationId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CostumerId");

                    b.HasIndex("FromLocationId");

                    b.HasIndex("ToLocationId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CESParcelDeliverySystem.Models.OrderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("TypeId");

                    b.ToTable("OrderType");
                });

            modelBuilder.Entity("CESParcelDeliverySystem.Models.Pricing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LatestShippingPrice")
                        .HasColumnType("int");

                    b.Property<int>("LatestTruckingPrice")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("SizeCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeightCategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pricing");
                });

            modelBuilder.Entity("CESParcelDeliverySystem.Models.Shipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("FromLocationId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("ToLocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromLocationId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ToLocationId");

                    b.ToTable("Shipment");
                });

            modelBuilder.Entity("CESParcelDeliverySystem.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Fee")
                        .HasColumnType("float");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("CESParcelDeliverySystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CESParcelDeliverySystem.Models.Connection", b =>
                {
                    b.HasOne("CESParcelDeliverySystem.Models.Location", "FromLocation")
                        .WithMany()
                        .HasForeignKey("FromLocationId");

                    b.HasOne("CESParcelDeliverySystem.Models.Location", "ToLocation")
                        .WithMany()
                        .HasForeignKey("ToLocationId");

                    b.Navigation("FromLocation");

                    b.Navigation("ToLocation");
                });

            modelBuilder.Entity("CESParcelDeliverySystem.Models.Order", b =>
                {
                    b.HasOne("CESParcelDeliverySystem.Models.Costumer", "Costumer")
                        .WithMany()
                        .HasForeignKey("CostumerId");

                    b.HasOne("CESParcelDeliverySystem.Models.Location", "FromLocation")
                        .WithMany()
                        .HasForeignKey("FromLocationId");

                    b.HasOne("CESParcelDeliverySystem.Models.Location", "ToLocation")
                        .WithMany()
                        .HasForeignKey("ToLocationId");

                    b.Navigation("Costumer");

                    b.Navigation("FromLocation");

                    b.Navigation("ToLocation");
                });

            modelBuilder.Entity("CESParcelDeliverySystem.Models.OrderType", b =>
                {
                    b.HasOne("CESParcelDeliverySystem.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("CESParcelDeliverySystem.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Order");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("CESParcelDeliverySystem.Models.Shipment", b =>
                {
                    b.HasOne("CESParcelDeliverySystem.Models.Location", "FromLocation")
                        .WithMany()
                        .HasForeignKey("FromLocationId");

                    b.HasOne("CESParcelDeliverySystem.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("CESParcelDeliverySystem.Models.Location", "ToLocation")
                        .WithMany()
                        .HasForeignKey("ToLocationId");

                    b.Navigation("FromLocation");

                    b.Navigation("Order");

                    b.Navigation("ToLocation");
                });
#pragma warning restore 612, 618
        }
    }
}
