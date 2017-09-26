using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CreditReport.Models;
using CreditReport.Data.PersonalInformation;

namespace CreditReport.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder); 

            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<RelateCompany>().ToTable("RelateCompany");
            modelBuilder.Entity<Question>().ToTable("Question");

            modelBuilder.Entity<Province>().ToTable("Province");

            //modelBuilder.Entity<RelatedPerson>()
            // .ToTable("RelatedPerson");

            //modelBuilder.Entity<RelatedPerson>()
            //  .ToTable("RelatedPerson")
            //   .HasKey(k => new { k.PersonID, k.RelatedID });

            // modelBuilder.Entity<RelatedPerson>()
            // .HasOne(p => p.PersonRelated)
            //.WithMany()
            // .HasForeignKey(p => p.PersonRelatedID);

            // modelBuilder.Entity<RelatedPerson>()
            // .HasOne(p => p.PersonPrincipal)

            //  .WithMany(b => b.RelatedPersons)
            // .HasForeignKey(p => p.PersonPrincipalID);

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<RelateCompany> RelateCompanies { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<CreditHistory> CreditHistory { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Province> Provinces { get; set; }



    }
}
