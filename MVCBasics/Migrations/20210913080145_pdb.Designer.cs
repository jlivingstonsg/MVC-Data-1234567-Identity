﻿// <auto-generated />
using System;
using MVCBasics.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCBasics.Migrations
{
    [DbContext(typeof(PeopleContext))]
    [Migration("20210913080145_pdb")]
    partial class pdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCBasics.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("MVCBasics.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("MVCBasics.Models.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("MVCBasics.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("MVCBasics.Models.PersonLanguage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LanguageID")
                        .HasColumnType("int");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LanguageID");

                    b.HasIndex("PersonID");

                    b.ToTable("PersonLanguage");
                });

            modelBuilder.Entity("MVCBasics.Models.City", b =>
                {
                    b.HasOne("MVCBasics.Models.Country", "Country")
                        .WithMany("City")
                        .HasForeignKey("CountryID");
                });

            modelBuilder.Entity("MVCBasics.Models.Person", b =>
                {
                    b.HasOne("MVCBasics.Models.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityID");
                });

            modelBuilder.Entity("MVCBasics.Models.PersonLanguage", b =>
                {
                    b.HasOne("MVCBasics.Models.Language", "Language")
                        .WithMany("People")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCBasics.Models.Person", "Person")
                        .WithMany("Languages")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
