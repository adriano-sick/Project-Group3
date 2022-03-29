﻿// <auto-generated />
using System;
using Group3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Project_Group3.Migrations
{
    [DbContext(typeof(EntitiesContext))]
    [Migration("20220329174854_initmig")]
    partial class initmig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Group3.Entities.Alternative", b =>
                {
                    b.Property<Guid>("AlternativeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AlternativeId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Alternative");
                });

            modelBuilder.Entity("Group3.Entities.Question", b =>
                {
                    b.Property<Guid>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("QuestionId");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Group3.Entities.Test", b =>
                {
                    b.Property<Guid>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestId");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("Group3.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Group3.Entities.Alternative", b =>
                {
                    b.HasOne("Group3.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");

                    b.HasOne("Group3.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Group3.Entities.Question", b =>
                {
                    b.HasOne("Group3.Entities.Test", null)
                        .WithMany("Questions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Group3.Entities.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId");

                    b.HasOne("Group3.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Group3.Entities.Test", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
