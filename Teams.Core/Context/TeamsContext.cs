using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.Core.Entities;

namespace Teams.Core.Context
{
    public class TeamsContext : DbContext
    {
        public TeamsContext()
        {

        }
        public TeamsContext(DbContextOptions<TeamsContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KORKMAZ\\MSSQLSERVER04;Database=Teams;uid=sa;pwd=1");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>()
            //    .HasOne(a => a.PersonDetail)
            //    .WithMany(a => a.Person)
            //    .HasForeignKey(a => a.PersonID);

            //modelBuilder.Entity<PersonDetail>()
            //    .HasOne(a => a.Title)
            //    .WithMany(a => a.PersonDetails)
            //    .HasForeignKey(a => a.TitleID);

            //modelBuilder.Entity<PersonDetail>()
            //  .HasOne(a => a.Team)
            //    .WithOne(a => a.PersonDetails)
            //  .HasForeignKey(a =>a.);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<PersonDetail> PersonDetail { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Title> Title { get; set; }



    }
}
