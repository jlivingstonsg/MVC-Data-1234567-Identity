using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Repository
{
    public class PeopleContext:IdentityDbContext<User>
    {
        public PeopleContext():base()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(PL => PL.Person)
                .WithMany(b => b.Languages)
                .HasForeignKey(bc => bc.PersonID);
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(PL => PL.Language)
                .WithMany(b => b.People)
                .HasForeignKey(bc => bc.LanguageID);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ///<summary>
            ///Use Below Connection For Remote Database
            ///</summary>
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PeopleDB;Trusted_Connection=True;");
            ///<summary>
            ///Use Below Connection For Local Database
            ///</summary>
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-MVCBasics;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public DbSet<Person> People { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<PersonLanguage> PersonLanguage { get; set; }
    }
}
