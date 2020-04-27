﻿// <auto-generated />
using System;
using Cinema.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cinema.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200423122959_bio")]
    partial class bio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cinema.Model.Customer", b =>
                {
                    b.Property<int>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phonenumber")
                        .HasColumnType("int");

                    b.Property<int>("zipcodeId")
                        .HasColumnType("int");

                    b.HasKey("customerId");

                    b.HasIndex("zipcodeId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Cinema.Model.Genre", b =>
                {
                    b.Property<int>("genreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("genre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("genreId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("Cinema.Model.Movie", b =>
                {
                    b.Property<int>("movieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ratingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("releasedate")
                        .HasColumnType("datetime2");

                    b.Property<int>("runtime")
                        .HasColumnType("int");

                    b.Property<int?>("showId")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("movieId");

                    b.HasIndex("ratingId");

                    b.HasIndex("showId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("Cinema.Model.MovieGenre", b =>
                {
                    b.Property<int>("movieId")
                        .HasColumnType("int");

                    b.Property<int>("genreId")
                        .HasColumnType("int");

                    b.HasKey("movieId", "genreId");

                    b.HasIndex("genreId");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("Cinema.Model.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("customerId")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<DateTime>("purchasedtime")
                        .HasColumnType("datetime2");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int?>("showId")
                        .HasColumnType("int");

                    b.HasKey("orderId");

                    b.HasIndex("customerId");

                    b.HasIndex("showId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Cinema.Model.Rating", b =>
                {
                    b.Property<int>("ratingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.HasKey("ratingId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("Cinema.Model.Seat", b =>
                {
                    b.Property<int>("seatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("available")
                        .HasColumnType("bit");

                    b.Property<int>("row")
                        .HasColumnType("int");

                    b.Property<int>("seat")
                        .HasColumnType("int");

                    b.Property<int?>("showId")
                        .HasColumnType("int");

                    b.HasKey("seatId");

                    b.HasIndex("showId");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("Cinema.Model.Show", b =>
                {
                    b.Property<int>("showId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("showtime")
                        .HasColumnType("int");

                    b.Property<int?>("theaterId")
                        .HasColumnType("int");

                    b.HasKey("showId");

                    b.HasIndex("theaterId");

                    b.ToTable("Show");
                });

            modelBuilder.Entity("Cinema.Model.Theater", b =>
                {
                    b.Property<int>("theaterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("seatings")
                        .HasColumnType("int");

                    b.Property<int>("showtime")
                        .HasColumnType("int");

                    b.HasKey("theaterId");

                    b.ToTable("Theater");
                });

            modelBuilder.Entity("Cinema.Model.Zipcode", b =>
                {
                    b.Property<int>("zipcodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("zipcode")
                        .HasColumnType("int");

                    b.HasKey("zipcodeId");

                    b.ToTable("Zipcode");
                });

            modelBuilder.Entity("Cinema.Model.Customer", b =>
                {
                    b.HasOne("Cinema.Model.Zipcode", "Zipcode")
                        .WithMany("Customer")
                        .HasForeignKey("zipcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cinema.Model.Movie", b =>
                {
                    b.HasOne("Cinema.Model.Rating", null)
                        .WithMany("Movie")
                        .HasForeignKey("ratingId");

                    b.HasOne("Cinema.Model.Show", "Show")
                        .WithMany("Movie")
                        .HasForeignKey("showId");
                });

            modelBuilder.Entity("Cinema.Model.MovieGenre", b =>
                {
                    b.HasOne("Cinema.Model.Genre", "Genre")
                        .WithMany("MovieGenre")
                        .HasForeignKey("genreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Model.Movie", "Movie")
                        .WithMany("MovieGenre")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cinema.Model.Order", b =>
                {
                    b.HasOne("Cinema.Model.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("customerId");

                    b.HasOne("Cinema.Model.Show", "Show")
                        .WithMany("Order")
                        .HasForeignKey("showId");
                });

            modelBuilder.Entity("Cinema.Model.Seat", b =>
                {
                    b.HasOne("Cinema.Model.Show", "Show")
                        .WithMany("Seat")
                        .HasForeignKey("showId");
                });

            modelBuilder.Entity("Cinema.Model.Show", b =>
                {
                    b.HasOne("Cinema.Model.Theater", "Theater")
                        .WithMany("Show")
                        .HasForeignKey("theaterId");
                });
#pragma warning restore 612, 618
        }
    }
}