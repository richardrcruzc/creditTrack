
#define SeedOnly
#if SeedOnly

using CreditReport.Authorization;
using CreditReport.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Data.PersonalInformation
{
    public static class SeedData
    {
        #region snippet_Initialize
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // For sample purposes we are seeding 2 users both with the same password.
                // The password is set with the following command:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@contoso.com");
                await EnsureRole(serviceProvider, adminID, Constants.ContactAdministratorsRole);

                // allowed user can create and edit contacts that they create
                var uid = await EnsureUser(serviceProvider, testUserPw, "manager@contoso.com");
                await EnsureRole(serviceProvider, uid, Constants.ContactManagersRole);

                SeedDB(context, adminID);
            }
        }
        #endregion

        #region snippet_CreateRoles        

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new ApplicationUser { UserName = UserName };
                await userManager.CreateAsync(user, testUserPw);
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByIdAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
        #endregion
        #region snippet1
        public static void SeedDB(ApplicationDbContext context, string adminID)
        {
            if (!context.Provinces.Any())
            {
               
                 var dn=   new Province {
                        Name = "Distrito Nacional",
                        ProvinceType = ProvinceType.DistritoMunicipal,                        
                    };

                dn.AddChildren(new Province
                {
                    Name = "Distrito Nacional",
                    ProvinceType = ProvinceType.Municipio,
                });

                context.Provinces.Add(dn);

                var az=  new Province
                    {
                        Name = "Azua",
                        ProvinceType = ProvinceType.Provincia,
                    };

                az.AddChildren(new Province
                {
                    Name = "Azua de Compostela",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                az.AddChildren(new Province
                {
                    Name = "Estebanía",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });

                az.AddChildren(new Province
                {
                    Name = "Guayabal",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                az.AddChildren(new Province
                {
                    Name = "Las Charcas",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                az.AddChildren(new Province
                {
                    Name = " Las Yayas de Viajama",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                az.AddChildren(new Province
                {
                    Name = "Padre Las Casas",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                az.AddChildren(new Province
                {
                    Name = "Peralta",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                az.AddChildren(new Province
                {
                    Name = "Pueblo Viejo",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                az.AddChildren(new Province
                {
                    Name = "Sabana Yegua",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                az.AddChildren(new Province
                {
                    Name = "Tábara Arriba",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });

                context.Provinces.Add(az);

               var ba =  new Province
                    {
                        Name = "Baoruco",
                        ProvinceType = ProvinceType.Provincia,
                    };
                ba.AddChildren(new Province
                {
                    Name = "Neiba",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ba.AddChildren(new Province
                {
                    Name = "Galván",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ba.AddChildren(new Province
                {
                    Name = " Los Ríos",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ba.AddChildren(new Province
                {
                    Name = "Tamayo",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ba.AddChildren(new Province
                {
                    Name = "Villa Jaragua",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
               

                context.Provinces.Add(ba); 

               var bar = new Province
                    {
                        Name = "Barahona",
                        ProvinceType = ProvinceType.Provincia,
                    };
                bar.AddChildren(new Province
                {
                    Name = "Barahona",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                bar.AddChildren(new Province
                {
                    Name = "Cabral",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                bar.AddChildren(new Province
                {
                    Name = "El Peñón",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                bar.AddChildren(new Province
                {
                    Name = "Enriquillo",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                bar.AddChildren(new Province
                {
                    Name = "Fundación",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                bar.AddChildren(new Province
                {
                    Name = "Jaquimeyes",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                bar.AddChildren(new Province
                {
                    Name = "La Ciénaga",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                bar.AddChildren(new Province
                {
                    Name = "Las Salinas",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                bar.AddChildren(new Province
                {
                    Name = "Paraíso",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                bar.AddChildren(new Province
                {
                    Name = "Polo",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                bar.AddChildren(new Province
                {
                    Name = "Vicente Noble",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });

                var da = new Province
                    {
                        Name = "Dajabón",
                        ProvinceType = ProvinceType.Provincia,
                    };

                da.AddChildren(new Province
                {
                    Name = "Dajabón",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                da.AddChildren(new Province
                {
                    Name = "El Pino",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                da.AddChildren(new Province
                {
                    Name = "Loma de Cabrera",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                da.AddChildren(new Province
                {
                    Name = "Partido",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                da.AddChildren(new Province
                {
                    Name = "Restauración",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });

                context.Provinces.Add(da);


              var du=  new Province
                {
                    Name = "Duarte",
                    ProvinceType = ProvinceType.Provincia,
                };
                du.AddChildren(new Province
                {
                    Name = "San Francisco de Macorís",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                du.AddChildren(new Province
                {
                    Name = "Arenoso",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                du.AddChildren(new Province
                {
                    Name = "Castillo",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                du.AddChildren(new Province
                {
                    Name = "Eugenio María de Hostos",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                du.AddChildren(new Province
                {
                    Name = "Las Guáranas",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                du.AddChildren(new Province
                {
                    Name = "Pimentel",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                du.AddChildren(new Province
                {
                    Name = "Villa Riva",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(du);

                 

                var el = new Province
                    {
                        Name = "El Seibo",
                        ProvinceType = ProvinceType.Provincia,
                    };

                el.AddChildren(new Province
                {
                    Name = "El Seibo",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });

                el.AddChildren(new Province
                {
                    Name = "Miches",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(el);




                var ep = new Province
                    {
                        Name = "Elías Piña",
                        ProvinceType = ProvinceType.Provincia,
                    };
                ep.AddChildren(new Province
                {
                    Name = "Comendador",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ep.AddChildren(new Province
                {
                    Name = "Bánica",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ep.AddChildren(new Province
                {
                    Name = "El Llano",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ep.AddChildren(new Province
                {
                    Name = "Hondo Valle",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ep.AddChildren(new Province
                {
                    Name = "Juan Santiago",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ep.AddChildren(new Province
                {
                    Name = "Pedro Santana",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(ep);



               var es =  new Province
                    {
                        Name = "Espaillat",
                        ProvinceType = ProvinceType.Provincia,
                    };
                ep.AddChildren(new Province
                {
                    Name = "Moca",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ep.AddChildren(new Province
                {
                    Name = "Cayetano Germosén",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ep.AddChildren(new Province
                {
                    Name = "Gaspar Hernández",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ep.AddChildren(new Province
                {
                    Name = "Jamao al Norte",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(ep);

                http://mipais.jmarcano.com/geografia/province/municipios/index.html
                new Province
                    {
                        Name = "Hato Mayor",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "Hermanas Mirabal",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "Independencia",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "La Altagracia",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "La Romana",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "La Vega",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "María Trinidad Sánchez",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "Monseñor Nouel",
                        ProvinceType = ProvinceType.Provincia,

                    });
           
                new Province
                    {
                        Name = "Montecristi",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "Monte Plata",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "Pedernales",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "Puerto Plata",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "Samaná",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "San Cristóbal",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "San José de Ocoa",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "San Juan",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "San Pedro de Macorís",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "Sánchez Ramírez",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "Santiago",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "Santiago Rodríguez",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "Santo Domingo",
                        ProvinceType = ProvinceType.Provincia,
                    });
           
                new Province
                    {
                        Name = "Valverde",
                        ProvinceType = ProvinceType.Provincia,

                    });
            

            }

            if (!context.Contacts.Any())
            { 
                context.Contacts.AddRange(
                #region snippet_Contact
                new Contact
                {
                    Name = "Debra Garcia",
                    Address = "1234 Main St",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "debra@example.com",
                    Status = ContactStatus.Approved,
                    OwnerID = adminID
                },
                #endregion
                #endregion
                new Contact
                {
                    Name = "Thorsten Weinrich",
                    Address = "5678 1st Ave W",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "thorsten@example.com",
                    Status = ContactStatus.Approved,
                    OwnerID = adminID
                },
                 new Contact
                 {
                     Name = "Yuhong Li",
                     Address = "9012 State st",
                     City = "Redmond",
                     State = "WA",
                     Zip = "10999",
                     Email = "yuhong@example.com",
                     Status = ContactStatus.Approved,
                     OwnerID = adminID
                 },
                 new Contact
                 {
                     Name = "Jon Orton",
                     Address = "3456 Maple St",
                     City = "Redmond",
                     State = "WA",
                     Zip = "10999",
                     Email = "jon@example.com",
                     OwnerID = adminID
                 },
                 new Contact
                 {
                     Name = "Diliana Alexieva-Bosseva",
                     Address = "7890 2nd Ave E",
                     City = "Redmond",
                     State = "WA",
                     Zip = "10999",
                     Email = "diliana@example.com",
                     OwnerID = adminID
                 }
                 );
                context.SaveChanges();
            }

            if (!context.Companies.Any())
            {
                var companies = new Company[] {
                     Company.New("ORANGE", "123 main street, cit, 000 WA", "12312312123", "John Does"),
                     Company.New("BANCO SANTA CRUZ", "123 main street, cit, 000 WA", "12312312123", "John Does"),
                     Company.New("BANRESERVAS", "123 main street, cit, 000 WA", "12312312123", "John Does"),
                     Company.New("Associacion Popular de Ahorros y Prestamos", "123 main street, cit, 000 WA", "12312312123", "John Does"),
                     Company.New("Associacion La Vega Real", "123 main street, cit, 000 WA", "12312312123", "John Does"),
                };
                foreach (Company s in companies)
                {
                    context.Companies.Add(s);
                }

                context.SaveChanges();


            }


            // Look for any persons.
            if (!context.Persons.Any())
            {
                var persons = new Person[] {
                Person.CreateNew(Gender.Masculino, "12341", "Alexander", "Carson", DateTime.Parse("1971-09-08"),"",CivilStatus.Single,"","AMERICANA" ),
                Person.CreateNew(Gender.Masculino, "12342", "Meredith", "Alonso",DateTime.Parse("1972-09-08"),"unknown", CivilStatus.Single, "unknown" ,"AMERICANA"),
                Person.CreateNew(Gender.Masculino, "12343", "Arturo", "Anand",DateTime.Parse("1977-09-08"),"unknown", CivilStatus.Single, "unknown","AMERICANA" ),
                Person.CreateNew(Gender.Femenino, "12344", "Gytis", "Barzdukas",DateTime.Parse("1977-09-08"),"unknown", CivilStatus.Married, "unknown" ,"AMERICANA"),
                Person.CreateNew(Gender.Masculino, "12345", "Yan", "Li",DateTime.Parse("1978-09-08"),"unknown",CivilStatus.Single, "unknown","CHINA" ),
                Person.CreateNew(Gender.Femenino, "12346", "Peggy", "Justice",DateTime.Parse("1937-09-08"),"unknown" ,CivilStatus.Single, "unknown","COLOMBIANA" ),
                Person.CreateNew(Gender.Femenino, "12347", "Laura", "Norman",DateTime.Parse("1957-09-08"),"unknown" ,CivilStatus.Single, "unknown" ,"VENECO"),
                Person.CreateNew(Gender.Masculino, "12348", "Nino", "Olivetto",DateTime.Parse("1967-09-08"),"unknown" ,CivilStatus.Married, "unknown" ,"DOMINICANA"),
                Person.CreateNew(Gender.Masculino, "12349", "Richard", "Cruz",DateTime.Parse("1987-09-08"),"unknown" ,CivilStatus.Married, "unknown","DOMINICANA" ),
            };

                foreach (Person p in persons)
                {

                    var addresses = new Address[]
                    {
                         Address.Create("C/MERENGUE 15 BO.","LA ALTAGRACIA","SANTO DOMINGO","33","DOMINICAN REPUBLIC", DateTime.Parse("2001-09-08")),
                         Address.Create("C/JOSE RAMON ORTIZ #15 ENS.","LA ALTAGRACIA","HERRERA SANTO DOMINGO","33","DOMINICAN REPUBLIC", DateTime.Parse("2001-09-08")),
                         Address.Create("C/MERENGUE 15 BO.","LA ALTAGRACIA","SANTO DOMINGO","44","DOMINICAN REPUBLIC", DateTime.Parse("2001-09-08")),
                         Address.Create("CIMA ESQ. LAS COLINAS/EDF.LENA","LA ALTAGRACIA","SANTO DOMINGO","55","DOMINICAN REPUBLIC", DateTime.Parse("2001-09-08")),
                         Address.Create("C/JACOBO MAJLUTA","DN","SANTO DOMINGO","55","DOMINICAN REPUBLIC", DateTime.Parse("2001-09-08")),

                    };
                   // p.AddAddress(addresses);


                    //var contacts = new Contact[] 
                    //{
                    //     new Contact{ ContactType = ContactType.Email, Description="12345678901", Date =DateTime.Parse("2001-09-08"), ContactTypeLocation = ContactLocationTypes.Residencia},
                    //     new Contact{ ContactType = ContactType.Telefono, Description="23423423423", Date =DateTime.Parse("2001-09-08"), ContactTypeLocation = ContactLocationTypes.Celular},
                    //     new Contact{ ContactType = ContactType.Telefono, Description="67867867867", Date =DateTime.Parse("2001-09-08"), ContactTypeLocation = ContactLocationTypes.Trabajo},
                    //     new Contact{ ContactType = ContactType.Telefono, Description="45365464564", Date =DateTime.Parse("2001-09-08"), ContactTypeLocation = ContactLocationTypes.Otros},
                    //     new Contact{ ContactType = ContactType.Telefono, Description="63453453453", Date =DateTime.Parse("2001-09-08"), ContactTypeLocation = ContactLocationTypes.Trabajo},
                    //     new Contact{ ContactType = ContactType.Telefono, Description="90755454355", Date =DateTime.Parse("2001-09-08"), ContactTypeLocation = ContactLocationTypes.Residencia},


                    //};

                    //p.AddContacts(contacts);

                    var company = context.Companies.FirstOrDefault();
                    var company2 = context.Companies.Find(2);
                    var company3 = context.Companies.Find(3);

                    var inqueries = new Inquiry[]
               {
                     Inquiry.New(DateTime.Now,company,InquiryType.CreditApplication, p),
                     Inquiry.New(DateTime.Now,company2,InquiryType.PorfolioRevision, p),
                     Inquiry.New(DateTime.Now,company3,InquiryType.Other, p),
                     Inquiry.New(DateTime.Now,company2,InquiryType.Other, p),
                     Inquiry.New(DateTime.Now,company,InquiryType.PorfolioRevision, p),
                     Inquiry.New(DateTime.Now,company3,InquiryType.CreditApplication, p),
                     Inquiry.New(DateTime.Now,company,InquiryType.CreditApplication, p),

               };

                   // p.AddInquiries(inqueries);



                    var credit = new CreditHistory
                    {

                         Note = "Esta persona no quedo bien tomo 1500 pesos hace mas de 6 meses",
                        CreateDate = DateTime.Now,
                        Person = p,

                    };


                    var credit1 = new CreditHistory
                    {
                         CreateDate = DateTime.Now.AddYears(-3),

                        Note = "Credit note for test sample 1",

                        Person = p,

                    };


                    var credits = new CreditHistory[] { credit, credit1 };


                    p.AddCreditHistory(credits);

                    context.Persons.Add(p);
                }


                //var person = persons[0];
                //var relatedPersons = new List<RelatedPerson>();
                //int x = 1;

                //foreach (var p in persons)
                //{
                //    if (x <= 1)
                //    {
                //         person = p;
                //        ++x;
                //        continue;
                //    }

                //    var rel = new RelatedPerson { Person =person, Related=p, RelationShip= PersonRelationShip.CoAplicante };


                //    relatedPersons.Add(rel);
                //}
                //person.AddPersons(relatedPersons);

                //context.Update(person);
                context.SaveChanges();
            }


            //if (context.Persons.Any())
            //{
            //    var person = context.Persons
            //        .Include("RelatedPersons.PersonRelated")
            //        .FirstOrDefault();
            //    if (person.RelatedPersons == null || person.RelatedPersons.Count == 0)
            //        if (person != null)
            //        {
            //            // var person = persons[0];
            //            var relatedPersons = new List<RelatedPerson>();
            //            int x = 1;
            //            var persons = context.Persons.ToList();
            //            foreach (var p in persons)
            //            {
            //                if (x <= 1)
            //                {
            //                    person = p;
            //                    ++x;
            //                    continue;
            //                }

            //                var rel = new RelatedPerson { PersonPrincipal = person, PersonRelated = p, RelationShip = PersonRelationShip.CoAplicante };


            //                relatedPersons.Add(rel);
            //            }


            //            person.AddPersons(relatedPersons);
            //            context.Update(person);

            //            context.SaveChanges();

            //        }


            //}


            //if (!context.RelateCompanies.Any())
            //{
            //    var relations = new RelateCompany[] {
            //        new RelateCompany { CompanyID =1, PersonID =1, RelationShip = CompanyRelationShip.Deudor,  Date=DateTime.Parse("2001-09-08") },
            //        new RelateCompany { CompanyID =2, PersonID =1, RelationShip = CompanyRelationShip.Deudor,  Date=DateTime.Parse("2002-03-01") },
            //        new RelateCompany { CompanyID =3, PersonID =1, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2005-05-06") },
            //        new RelateCompany { CompanyID =4, PersonID =1, RelationShip = CompanyRelationShip.Deudor,  Date=DateTime.Parse("2010-10-01") },
            //        new RelateCompany { CompanyID =5, PersonID =1, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2005-09-01") },

            //        new RelateCompany { CompanyID =1, PersonID =2, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2000-09-01") },
            //        new RelateCompany { CompanyID =2, PersonID =2, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2002-01-01") },
            //        new RelateCompany { CompanyID =3, PersonID =2, RelationShip = CompanyRelationShip.Deudor,  Date=DateTime.Parse("2003-09-08") },
            //        new RelateCompany { CompanyID =4, PersonID =2, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2004-09-01") },

            //        new RelateCompany { CompanyID =1, PersonID =3, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2005-10-10") },
            //        new RelateCompany { CompanyID =2, PersonID =3, RelationShip = CompanyRelationShip.Deudor,  Date=DateTime.Parse("2003-03-02") },
            //        new RelateCompany { CompanyID =3, PersonID =3, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2015-09-01") },

            //        new RelateCompany { CompanyID =1, PersonID =4, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2015-09-01") },

            //        new RelateCompany { CompanyID =2, PersonID =5, RelationShip = CompanyRelationShip.Deudor,  Date=DateTime.Parse("2016-09-01") },

            //        new RelateCompany { CompanyID =1, PersonID =6, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2017-09-01") },
            //        new RelateCompany { CompanyID =5, PersonID =6, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2015-09-01") },

            //        new RelateCompany { CompanyID =1, PersonID =7, RelationShip = CompanyRelationShip.Deudor,  Date=DateTime.Parse("2007-09-01") },
            //        new RelateCompany { CompanyID =5, PersonID =7, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2008-09-01") },

            //        new RelateCompany { CompanyID =1, PersonID =8, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2005-09-01") },
            //        new RelateCompany { CompanyID =5, PersonID =8, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2009-09-01") },

            //        new RelateCompany { CompanyID =2, PersonID =9, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2010-09-01") },
            //        new RelateCompany { CompanyID =3, PersonID =9, RelationShip = CompanyRelationShip.Empleado,  Date=DateTime.Parse("2005-09-01") },
            //    };
            //    foreach (RelateCompany s in relations)
            //    {
            //        context.RelateCompanies.Add(s);
            //    }

            //    context.SaveChanges();
            //}
        }
    }
}
#endif