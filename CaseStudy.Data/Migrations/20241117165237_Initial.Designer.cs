﻿// <auto-generated />
using System;
using CaseStudy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CaseStudy.Data.Migrations
{
    [DbContext(typeof(CaseStudyApplicationContext))]
    [Migration("20241117165237_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("CaseStudy.Data.Entities.Books.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("Genre")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("PublishYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("CaseStudy.Data.Entities.Collections.Collection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("CaseStudy.Data.Entities.Relational.BookCollections.BookCollection", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CollectionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("BookId1")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CollectionId1")
                        .HasColumnType("TEXT");

                    b.HasKey("BookId", "CollectionId");

                    b.HasIndex("BookId1");

                    b.HasIndex("CollectionId");

                    b.HasIndex("CollectionId1");

                    b.ToTable("BookCollection");
                });

            modelBuilder.Entity("CaseStudy.Data.Entities.Relational.BookCollections.BookCollection", b =>
                {
                    b.HasOne("CaseStudy.Data.Entities.Books.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaseStudy.Data.Entities.Books.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId1");

                    b.HasOne("CaseStudy.Data.Entities.Collections.Collection", null)
                        .WithMany()
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaseStudy.Data.Entities.Collections.Collection", "Collection")
                        .WithMany()
                        .HasForeignKey("CollectionId1");

                    b.Navigation("Book");

                    b.Navigation("Collection");
                });
#pragma warning restore 612, 618
        }
    }
}
