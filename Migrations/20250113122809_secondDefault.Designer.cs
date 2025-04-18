﻿// <auto-generated />
using System;
using MarieSkema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarieSkema.Migrations
{
    [DbContext(typeof(SkemaDbContext))]
    [Migration("20250113122809_secondDefault")]
    partial class secondDefault
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FagDageLaerer", b =>
                {
                    b.Property<int>("fagsDageFagDageId")
                        .HasColumnType("int");

                    b.Property<int>("laerersLaererId")
                        .HasColumnType("int");

                    b.HasKey("fagsDageFagDageId", "laerersLaererId");

                    b.HasIndex("laerersLaererId");

                    b.ToTable("LaererFagDage", (string)null);
                });

            modelBuilder.Entity("FagFagDage", b =>
                {
                    b.Property<int>("FagId")
                        .HasColumnType("int");

                    b.Property<int>("fagDagesesFagDageId")
                        .HasColumnType("int");

                    b.HasKey("FagId", "fagDagesesFagDageId");

                    b.HasIndex("fagDagesesFagDageId");

                    b.ToTable("FagFagDage", (string)null);
                });

            modelBuilder.Entity("FagLaerer", b =>
                {
                    b.Property<int>("fagsFagId")
                        .HasColumnType("int");

                    b.Property<int>("laerersesLaererId")
                        .HasColumnType("int");

                    b.HasKey("fagsFagId", "laerersesLaererId");

                    b.HasIndex("laerersesLaererId");

                    b.ToTable("FagLaerer", (string)null);
                });

            modelBuilder.Entity("MarieSkema.Models.Fag", b =>
                {
                    b.Property<int>("FagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FagId"));

                    b.Property<string>("FagNavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("FagTid")
                        .HasColumnType("real");

                    b.Property<bool>("TPTid")
                        .HasColumnType("bit");

                    b.HasKey("FagId");

                    b.ToTable("Fag");
                });

            modelBuilder.Entity("MarieSkema.Models.FagDage", b =>
                {
                    b.Property<int>("FagDageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FagDageId"));

                    b.Property<int>("Dag")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("FagDageId");

                    b.ToTable("FagDages");
                });

            modelBuilder.Entity("MarieSkema.Models.Laerer", b =>
                {
                    b.Property<int>("LaererId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LaererId"));

                    b.Property<string>("LaererNavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LaererId");

                    b.ToTable("Laerer");
                });

            modelBuilder.Entity("FagDageLaerer", b =>
                {
                    b.HasOne("MarieSkema.Models.FagDage", null)
                        .WithMany()
                        .HasForeignKey("fagsDageFagDageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarieSkema.Models.Laerer", null)
                        .WithMany()
                        .HasForeignKey("laerersLaererId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FagFagDage", b =>
                {
                    b.HasOne("MarieSkema.Models.Fag", null)
                        .WithMany()
                        .HasForeignKey("FagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarieSkema.Models.FagDage", null)
                        .WithMany()
                        .HasForeignKey("fagDagesesFagDageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FagLaerer", b =>
                {
                    b.HasOne("MarieSkema.Models.Fag", null)
                        .WithMany()
                        .HasForeignKey("fagsFagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarieSkema.Models.Laerer", null)
                        .WithMany()
                        .HasForeignKey("laerersesLaererId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
