﻿// <auto-generated />
using System;
using Group3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Project_Group3.Migrations
{
    [DbContext(typeof(EntitiesContext))]
    partial class EntitiesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Group3.Entities.Avaliacao", b =>
                {
                    b.Property<int>("AvaliacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AvaliacaoNota")
                        .HasColumnType("real");

                    b.Property<int?>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("AvaliacaoId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("StudentId");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("Group3.Entities.Discipline", b =>
                {
                    b.Property<int>("DisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisciplinaName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TurmaId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("DisciplinaId");

                    b.HasIndex("TurmaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Discipline");
                });

            modelBuilder.Entity("Group3.Entities.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AvaliacaoId")
                        .HasColumnType("int");

                    b.Property<string>("QuestionCorreta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionEnunciado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionIncorreta1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionIncorreta2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionIncorreta3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.HasIndex("AvaliacaoId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Group3.Entities.Turma", b =>
                {
                    b.Property<int>("TurmaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("TurmaName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TurmaId");

                    b.HasIndex("DisciplinaId")
                        .IsUnique()
                        .HasFilter("[DisciplinaId] IS NOT NULL");

                    b.HasIndex("StudentId");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("Group3.Entities.User", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataNasc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ocupacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Group3.Entities.Professor", b =>
                {
                    b.HasBaseType("Group3.Entities.User");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Professor");
                });

            modelBuilder.Entity("Group3.Entities.Student", b =>
                {
                    b.HasBaseType("Group3.Entities.User");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Group3.Entities.Avaliacao", b =>
                {
                    b.HasOne("Group3.Entities.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplinaId");

                    b.HasOne("Group3.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Discipline");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Group3.Entities.Discipline", b =>
                {
                    b.HasOne("Group3.Entities.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId");

                    b.HasOne("Group3.Entities.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Professor");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Group3.Entities.Question", b =>
                {
                    b.HasOne("Group3.Entities.Avaliacao", "Avaliacao")
                        .WithMany()
                        .HasForeignKey("AvaliacaoId");

                    b.Navigation("Avaliacao");
                });

            modelBuilder.Entity("Group3.Entities.Turma", b =>
                {
                    b.HasOne("Group3.Entities.Discipline", "Discipline")
                        .WithOne()
                        .HasForeignKey("Group3.Entities.Turma", "DisciplinaId");

                    b.HasOne("Group3.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Discipline");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Group3.Entities.Professor", b =>
                {
                    b.HasOne("Group3.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Group3.Entities.Student", b =>
                {
                    b.HasOne("Group3.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}