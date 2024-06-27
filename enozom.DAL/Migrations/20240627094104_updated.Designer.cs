﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using enozom.DAL.Data;

#nullable disable

namespace enozom.DAL.Migrations
{
    [DbContext(typeof(EnozomDbContext))]
    [Migration("20240627094104_updated")]
    partial class updated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("enozom.Domain.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Author A",
                            Title = "Clean code"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Author B",
                            Title = "Algorithms"
                        });
                });

            modelBuilder.Entity("enozom.Domain.Models.BookCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("StatusId");

                    b.ToTable("BookCopy");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 3,
                            BookId = 2,
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("enozom.Domain.Models.BookCopyStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BookCopyStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "Good"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Damaged"
                        },
                        new
                        {
                            Id = 3,
                            Status = "Lost"
                        });
                });

            modelBuilder.Entity("enozom.Domain.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Ali@enozom.com",
                            Name = "Ali",
                            Phone = "0122224400"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Mohamed@enozom.com",
                            Name = "Mohamed",
                            Phone = "0111155000"
                        },
                        new
                        {
                            Id = 3,
                            Email = "ahmed@enozom.com",
                            Name = "Ahmed",
                            Phone = "0155553311"
                        });
                });

            modelBuilder.Entity("enozom.Domain.Models.StudentBorrowBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ActualReturnDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CopyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpectedReturnDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ReturnStatusId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CopyId");

                    b.HasIndex("ReturnStatusId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentBorrowBook");
                });

            modelBuilder.Entity("enozom.Domain.Models.BookCopy", b =>
                {
                    b.HasOne("enozom.Domain.Models.Book", "Book")
                        .WithMany("BookCopies")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("enozom.Domain.Models.BookCopyStatus", "Status")
                        .WithMany("BookCopies")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("enozom.Domain.Models.StudentBorrowBook", b =>
                {
                    b.HasOne("enozom.Domain.Models.BookCopy", "BookCopy")
                        .WithMany("BorrowRecords")
                        .HasForeignKey("CopyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("enozom.Domain.Models.BookCopyStatus", "ReturnStatus")
                        .WithMany()
                        .HasForeignKey("ReturnStatusId");

                    b.HasOne("enozom.Domain.Models.Student", "Student")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookCopy");

                    b.Navigation("ReturnStatus");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("enozom.Domain.Models.Book", b =>
                {
                    b.Navigation("BookCopies");
                });

            modelBuilder.Entity("enozom.Domain.Models.BookCopy", b =>
                {
                    b.Navigation("BorrowRecords");
                });

            modelBuilder.Entity("enozom.Domain.Models.BookCopyStatus", b =>
                {
                    b.Navigation("BookCopies");
                });

            modelBuilder.Entity("enozom.Domain.Models.Student", b =>
                {
                    b.Navigation("BorrowedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}