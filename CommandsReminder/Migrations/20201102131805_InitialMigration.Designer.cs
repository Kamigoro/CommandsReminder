﻿// <auto-generated />
using System;
using CommandsReminder.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CommandsReminder.Migrations
{
    [DbContext(typeof(CommandsDbContext))]
    [Migration("20201102131805_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommandsReminder.Models.Command", b =>
                {
                    b.Property<int>("CommandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Example")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("CommandId");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("CommandsReminder.Models.CommandPlatform", b =>
                {
                    b.Property<int>("CommandId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.HasKey("CommandId", "PlatformId");

                    b.HasIndex("PlatformId");

                    b.ToTable("CommandPlatforms");
                });

            modelBuilder.Entity("CommandsReminder.Models.Parameter", b =>
                {
                    b.Property<int>("ParameterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommandId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Example")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("String")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParameterId");

                    b.HasIndex("CommandId");

                    b.ToTable("CommandParameters");
                });

            modelBuilder.Entity("CommandsReminder.Models.Platform", b =>
                {
                    b.Property<int>("PlatformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("PlatformId");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("CommandsReminder.Models.CommandPlatform", b =>
                {
                    b.HasOne("CommandsReminder.Models.Command", "Command")
                        .WithMany("CommandPlatforms")
                        .HasForeignKey("CommandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommandsReminder.Models.Platform", "Platform")
                        .WithMany("CommandPlatforms")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CommandsReminder.Models.Parameter", b =>
                {
                    b.HasOne("CommandsReminder.Models.Command", null)
                        .WithMany("Parameters")
                        .HasForeignKey("CommandId");
                });
#pragma warning restore 612, 618
        }
    }
}