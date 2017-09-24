

//using CreditReport.Data.PersonalInformation;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace CreditReport.Data
//{
//        public class CreditReportContext : DbContext
//        {
//            public CreditReportContext(DbContextOptions<CreditReportContext> options) : base(options)
//            {
//            }

//            public DbSet<Person> Persons { get; set; }
//        public DbSet<Company> Companies { get; set; }
//        public DbSet<RelateCompany> RelateCompanies { get; set; }

//        public DbSet<Contact> Contacts { get; set; }

//        //  public DbSet<RelatedPerson> RelatedPersons { get; set; }            
//        //public DbSet<ContactHistory> ContactHistories { get; set; }
//        //public DbSet<CreditHistory> CreditHistories { get; set; }



//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Person>()
//                .ToTable("Person");           
//            modelBuilder.Entity<Company>().ToTable("Company");
//            modelBuilder.Entity<RelateCompany>().ToTable("RelateCompany");

//            modelBuilder.Entity<RelatedPerson>()
//             .ToTable("RelatedPerson");

//            //modelBuilder.Entity<RelatedPerson>()
//            //  .ToTable("RelatedPerson")
//            //   .HasKey(k => new { k.PersonID, k.RelatedID });

//            modelBuilder.Entity<RelatedPerson>()
//            .HasOne(p => p.PersonRelated)
//           .WithMany()
//            .HasForeignKey(p => p.PersonRelatedID);

//            modelBuilder.Entity<RelatedPerson>()
//            .HasOne(p => p.PersonPrincipal)
            
//             .WithMany(b => b.RelatedPersons)
//            .HasForeignKey(p => p.PersonPrincipalID);


//            //modelBuilder.Entity<ContactHistory>().ToTable("ContactHistory");
//            //modelBuilder.Entity<CreditHistory>().ToTable("CreditHistory");
//            //modelBuilder.Entity<RelatedPerson>().ToTable("RelatedPerson");
//        }
        
//     //  public DbSet<RelatedPerson> RelatedPersons { get; set; }            
//        //public DbSet<ContactHistory> ContactHistories { get; set; }
//        //public DbSet<CreditHistory> CreditHistories { get; set; }



//        public DbSet<CreditReport.Data.PersonalInformation.CreditHistory> CreditHistory { get; set; }
//    }
//    }
 