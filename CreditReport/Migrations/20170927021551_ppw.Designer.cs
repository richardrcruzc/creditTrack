﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CreditReport.Data;
using CreditReport.Data.PersonalInformation;

namespace CreditReport.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170927021551_ppw")]
    partial class ppw
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CreditReport.Data.PersonalInformation.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("ContactName");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("CompanyID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("CreditReport.Data.PersonalInformation.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerID");

                    b.Property<string>("State");

                    b.Property<int>("Status");

                    b.Property<string>("Zip");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CreditReport.Data.PersonalInformation.CreditHistory", b =>
                {
                    b.Property<int>("CreditHistoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(1500);

                    b.Property<int?>("PersonID");

                    b.HasKey("CreditHistoryID");

                    b.HasIndex("PersonID");

                    b.ToTable("CreditHistory");
                });

            modelBuilder.Entity("CreditReport.Data.PersonalInformation.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy");

                    b.Property<DateTime>("Created");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("PersonID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("CreditReport.Data.PersonalInformation.Province", b =>
                {
                    b.Property<int>("ProvinceID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MotherProvinceProvinceID");

                    b.Property<string>("Name");

                    b.Property<int>("ProvinceType");

                    b.HasKey("ProvinceID");

                    b.HasIndex("MotherProvinceProvinceID");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("CreditReport.Data.PersonalInformation.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("MotherQuestionQuestionID");

                    b.Property<int>("Status");

                    b.HasKey("QuestionID");

                    b.HasIndex("MotherQuestionQuestionID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("CreditReport.Data.PersonalInformation.RelateCompany", b =>
                {
                    b.Property<int>("RelateCompanyID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyID");

                    b.Property<string>("ContactType");

                    b.Property<DateTime>("Date");

                    b.Property<int>("PersonID");

                    b.Property<int>("RelationShip");

                    b.HasKey("RelateCompanyID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("PersonID");

                    b.ToTable("RelateCompany");
                });

            modelBuilder.Entity("CreditReport.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("IPAddress");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("CreditReport.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Barrio");

                    b.Property<string>("Calle");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Empresa");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Municipio");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Provincia");

                    b.Property<string>("Sector");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CreditReport.Data.PersonalInformation.CreditHistory", b =>
                {
                    b.HasOne("CreditReport.Data.PersonalInformation.Person", "Person")
                        .WithMany("CreditHistories")
                        .HasForeignKey("PersonID");
                });

            modelBuilder.Entity("CreditReport.Data.PersonalInformation.Province", b =>
                {
                    b.HasOne("CreditReport.Data.PersonalInformation.Province", "MotherProvince")
                        .WithMany("ChildrenProvinces")
                        .HasForeignKey("MotherProvinceProvinceID");
                });

            modelBuilder.Entity("CreditReport.Data.PersonalInformation.Question", b =>
                {
                    b.HasOne("CreditReport.Data.PersonalInformation.Question", "MotherQuestion")
                        .WithMany("ChildrenQuestion")
                        .HasForeignKey("MotherQuestionQuestionID");
                });

            modelBuilder.Entity("CreditReport.Data.PersonalInformation.RelateCompany", b =>
                {
                    b.HasOne("CreditReport.Data.PersonalInformation.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CreditReport.Data.PersonalInformation.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("CreditReport.Models.ApplicationRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CreditReport.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CreditReport.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("CreditReport.Models.ApplicationRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CreditReport.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
