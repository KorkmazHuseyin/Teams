﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teams.Core.Context;

namespace Teams.Core.Migrations
{
    [DbContext(typeof(TeamsContext))]
    [Migration("20230914202945_deneme")]
    partial class deneme
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Teams.Core.Entities.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Teams.Core.Entities.PersonDetail", b =>
                {
                    b.Property<int>("PersonDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<int>("TitleID")
                        .HasColumnType("int");

                    b.HasKey("PersonDetailID");

                    b.HasIndex("PersonID")
                        .IsUnique();

                    b.HasIndex("TeamID");

                    b.HasIndex("TitleID");

                    b.ToTable("PersonDetail");
                });

            modelBuilder.Entity("Teams.Core.Entities.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TeamsName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Teams.Core.Entities.Title", b =>
                {
                    b.Property<int>("TitleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TitleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TitleID");

                    b.ToTable("Title");
                });

            modelBuilder.Entity("Teams.Core.Entities.PersonDetail", b =>
                {
                    b.HasOne("Teams.Core.Entities.Person", "Person")
                        .WithOne("PersonDetail")
                        .HasForeignKey("Teams.Core.Entities.PersonDetail", "PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Teams.Core.Entities.Team", "Team")
                        .WithMany("PersonDetails")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Teams.Core.Entities.Title", "Title")
                        .WithMany("PersonDetails")
                        .HasForeignKey("TitleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Team");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("Teams.Core.Entities.Person", b =>
                {
                    b.Navigation("PersonDetail");
                });

            modelBuilder.Entity("Teams.Core.Entities.Team", b =>
                {
                    b.Navigation("PersonDetails");
                });

            modelBuilder.Entity("Teams.Core.Entities.Title", b =>
                {
                    b.Navigation("PersonDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
