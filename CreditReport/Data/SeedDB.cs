
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
                await EnsureRole(serviceProvider, adminID, Constants.AdministratorsRole);

                // allowed user can create and edit contacts that they create
                var uid = await EnsureUser(serviceProvider, testUserPw, "manager@contoso.com");
                await EnsureRole(serviceProvider, uid, Constants.ManagersRole);

                 // allowed user can create and edit contacts that they create
                var customer = await EnsureUser(serviceProvider, testUserPw, "customer@contoso.com");
                await EnsureRole(serviceProvider, uid, Constants.CustomersRole);



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
                user = new ApplicationUser
                {
                    Email = UserName,
                    UserName = UserName,
                     Calle="Calle 1ra",
                     Sector="El Tamarindo",
                      Barrio="La Mata",
                    Municipio = "Puerto Plata",
                    Provincia = "Puerto Plata",
                    Empresa ="Colmado el que se ve de lejos",
                      
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            IdentityResult IR = null;
            var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
           
            //RoleManager<IdentityRole> roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new ApplicationRole {Name =role, Description = role });
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


                var ha = new Province
                    {
                        Name = "Hato Mayor",
                        ProvinceType = ProvinceType.Provincia,
                    };

                ha.AddChildren(new Province
                {
                    Name = "Hato Mayor del Rey",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ha.AddChildren(new Province
                {
                    Name = "El Valle",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ha.AddChildren(new Province
                {
                    Name = "Sabana de la Mar",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                
                context.Provinces.Add(ha);

                var he = new Province
                    {
                        Name = "Hermanas Mirabal",
                        ProvinceType = ProvinceType.Provincia,
                    };
                he.AddChildren(new Province
                {
                    Name = "Salcedo",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                he.AddChildren(new Province
                {
                    Name = "Tenares",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                he.AddChildren(new Province
                {
                    Name = "Villa Tapia",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(he);


             var ind = new Province
                    {
                        Name = "Independencia",
                        ProvinceType = ProvinceType.Provincia,
                    };
                ind.AddChildren(new Province
                {
                    Name = "Jimaní",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ind.AddChildren(new Province
                {
                    Name = "Cristóbal",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ind.AddChildren(new Province
                {
                    Name = "Duvergé",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ind.AddChildren(new Province
                {
                    Name = "La Descubierta",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ind.AddChildren(new Province
                {
                    Name = "Mella",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                ind.AddChildren(new Province
                {
                    Name = "Postrer Río",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                 
                context.Provinces.Add(ind);

                var la = new Province
                    {
                        Name = "La Altagracia",
                        ProvinceType = ProvinceType.Provincia,
                    };
                la.AddChildren(new Province
                {
                    Name = "Higüey",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                la.AddChildren(new Province
                {
                    Name = "San Rafael del Yuma",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                
                context.Provinces.Add(la);


               var lr =  new Province
                    {
                        Name = "La Romana",
                        ProvinceType = ProvinceType.Provincia,
                    };
                lr.AddChildren(new Province
                {
                    Name = "La Romana",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                lr.AddChildren(new Province
                {
                    Name = "Guaymate",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                lr.AddChildren(new Province
                {
                    Name = "Villa Hermosa",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                 
                context.Provinces.Add(lr);

               var lv =  new Province
                    {
                        Name = "La Vega",
                        ProvinceType = ProvinceType.Provincia,
                    };
                lv.AddChildren(new Province
                {
                    Name = "La Concepción de La Vega",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                lv.AddChildren(new Province
                {
                    Name = "Constanza",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                lv.AddChildren(new Province
                {
                    Name = "Jarabacoa",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                lv.AddChildren(new Province
                {
                    Name = "Jima Abajo",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                 context.Provinces.Add(lv);


                 
               var mt =  new Province
                    {
                        Name = "María Trinidad Sánchez",
                        ProvinceType = ProvinceType.Provincia,
                    };
                mt.AddChildren(new Province
                {
                    Name = "Nagua",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mt.AddChildren(new Province
                {
                    Name = "Cabrera",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mt.AddChildren(new Province
                {
                    Name = "El Factor",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mt.AddChildren(new Province
                {
                    Name = "Río San Juan",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(mt);
                  
                var mo = new Province
                    {
                        Name = "Monseñor Nouel",
                        ProvinceType = ProvinceType.Provincia,
                    };
                mo.AddChildren(new Province
                {
                    Name = "Bonao",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mo.AddChildren(new Province
                {
                    Name = "Maimón",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mo.AddChildren(new Province
                {
                    Name = "Piedra Blanca",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(mo);


                var mot = new Province
                    {
                        Name = "Montecristi",
                        ProvinceType = ProvinceType.Provincia,
                    };

                mot.AddChildren(new Province
                {
                    Name = "Montecristi",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mot.AddChildren(new Province
                {
                    Name = "Castañuela",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mot.AddChildren(new Province
                {
                    Name = "Guayubín",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mot.AddChildren(new Province
                {
                    Name = "Las Matas de Santa Cruz",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mot.AddChildren(new Province
                {
                    Name = "Pepillo Salcedo",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mot.AddChildren(new Province
                {
                    Name = "Villa Vásquez	",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(mot);



                var mp = new Province
                    {
                        Name = "Monte Plata",
                        ProvinceType = ProvinceType.Provincia,
                    };
                mp.AddChildren(new Province
                {
                    Name = "Monte Plata",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mp.AddChildren(new Province
                {
                    Name = "Bayaguana",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mp.AddChildren(new Province
                {
                    Name = "Peralvillo",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mp.AddChildren(new Province
                {
                    Name = "Sabana Grande de Boyá",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mp.AddChildren(new Province
                {
                    Name = "Yamasá",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(mp);

                
                var pe = new Province
                    {
                        Name = "Pedernales",
                        ProvinceType = ProvinceType.Provincia,
                    };
                pe.AddChildren(new Province
                {
                    Name = "Pedernales",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                pe.AddChildren(new Province
                {
                    Name = "Oviedo",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });

                context.Provinces.Add(pe);

                var per = new Province
                {
                    Name = "Peravia",
                    ProvinceType = ProvinceType.Provincia,
                };
                per.AddChildren(new Province
                {
                    Name = "Baní",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                per.AddChildren(new Province
                {
                    Name = "Nizao",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                 context.Provinces.Add(per);
                 

                var pp =  new Province
                    {
                        Name = "Puerto Plata",
                        ProvinceType = ProvinceType.Provincia,
                    };
                pp.AddChildren(new Province
                {
                    Name = "Puerto Plata",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                pp.AddChildren(new Province
                {
                    Name = "Altamira",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                pp.AddChildren(new Province
                {
                    Name = "Guananico",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                pp.AddChildren(new Province
                {
                    Name = "Imbert",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                pp.AddChildren(new Province
                {
                    Name = "Los Hidalgos",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                pp.AddChildren(new Province
                {
                    Name = "Sosúa",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                pp.AddChildren(new Province
                {
                    Name = "Villa Isabela",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                pp.AddChildren(new Province
                {
                    Name = "Villa Montellano",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(pp);

                 
               var sa= new Province
                    {
                        Name = "Samaná",
                        ProvinceType = ProvinceType.Provincia,
                    };
                sa.AddChildren(new Province
                {
                    Name = "Samaná",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sa.AddChildren(new Province
                {
                    Name = "Las Terrenas",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sa.AddChildren(new Province
                {
                    Name = "Sánchez",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(sa);
            
            var san=    new Province
                    {
                        Name = "San Cristóbal",
                        ProvinceType = ProvinceType.Provincia,
                    };
                san.AddChildren(new Province
                {
                    Name = "San Cristóbal",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                san.AddChildren(new Province
                {
                    Name = "Bajos de Haina",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                san.AddChildren(new Province
                {
                    Name = "Cambita Garabito",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                san.AddChildren(new Province
                {
                    Name = "Los Cacaos",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                san.AddChildren(new Province
                {
                    Name = "Sabana Grande de Palenque",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                san.AddChildren(new Province
                {
                    Name = "San Gregorio de Nigua",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                san.AddChildren(new Province
                {
                    Name = "Villa Altagracia",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                san.AddChildren(new Province
                {
                    Name = "Yaguate",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(san);


               var sj=  new Province
                    {
                        Name = "San José de Ocoa",
                        ProvinceType = ProvinceType.Provincia,
                    };
                sj.AddChildren(new Province
                {
                    Name = "San José de Ocoa",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sj.AddChildren(new Province
                {
                    Name = "Rancho Arriba",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sj.AddChildren(new Province
                {
                    Name = "Sabana Larga",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(sj);

                var sanj = new Province
                    {
                        Name = "San Juan",
                        ProvinceType = ProvinceType.Provincia,
                    };
                sanj.AddChildren(new Province
                {
                    Name = "San Juan de la Maguana",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sanj.AddChildren(new Province
                {
                    Name = "Bohechío",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sanj.AddChildren(new Province
                {
                    Name = "El Cercado",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sanj.AddChildren(new Province
                {
                    Name = "Las Matas de Farfán",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sanj.AddChildren(new Province
                {
                    Name = "Vallejuelo",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sanj.AddChildren(new Province
                {
                    Name = "Sabana Larga",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(sanj);

                var sp = new Province
                    {
                        Name = "San Pedro de Macorís",
                        ProvinceType = ProvinceType.Provincia,
                    };
                sp.AddChildren(new Province
                {
                    Name = "San Pedro de Macorís",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "Consuelo",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "Guayacanes",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "Quisqueya",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "Ramón Santana",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "San José de Los Llanos",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(sp);


                var sar = new Province
                    {
                        Name = "Sánchez Ramírez",
                        ProvinceType = ProvinceType.Provincia,
                    };
                sp.AddChildren(new Province
                {
                    Name = "Cotuí",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "Cevicos",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "Fantino",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "La Mata",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(sp);


                var snt = new Province
                    {
                        Name = "Santiago",
                        ProvinceType = ProvinceType.Provincia,
                    };
                sp.AddChildren(new Province
                {
                    Name = "Santiago",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "Bisonó",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "Jánico",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "Licey al Medio",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "Puñal",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "Sabana Iglesia",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "San José de las Matas",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "Tamboril",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sp.AddChildren(new Province
                {
                    Name = "Villa González",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(sp);


              var sanr=  new Province
                    {
                        Name = "Santiago Rodríguez",
                        ProvinceType = ProvinceType.Provincia,
                    };
                sanr.AddChildren(new Province
                {
                    Name = "San Ignacio de Sabaneta",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sanr.AddChildren(new Province
                {
                    Name = "Los Almácigos",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sanr.AddChildren(new Province
                {
                    Name = "Monción",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(sanr);
                 
                var sdg = new Province
                    {
                        Name = "Santo Domingo",
                        ProvinceType = ProvinceType.Provincia,
                    };
                sdg.AddChildren(new Province
                {
                    Name = "Santo Domingo Este",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sdg.AddChildren(new Province
                {
                    Name = "Boca Chica",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sdg.AddChildren(new Province
                {
                    Name = "Los Alcarrizos",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sdg.AddChildren(new Province
                {
                    Name = "Pedro Brand",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sdg.AddChildren(new Province
                {
                    Name = "San Antonio de Guerra",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sdg.AddChildren(new Province
                {
                    Name = "Santo Domingo Norte",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                sdg.AddChildren(new Province
                {
                    Name = "Santo Domingo Oeste",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(sdg);


                var mao = new Province
                    {
                        Name = "Valverde",
                        ProvinceType = ProvinceType.Provincia,

                    };
                mao.AddChildren(new Province
                {
                    Name = "Mao",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mao.AddChildren(new Province
                {
                    Name = "Esperanza",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                mao.AddChildren(new Province
                {
                    Name = "Laguna Salada",
                    ProvinceType = ProvinceType.DistritoMunicipal,
                });
                context.Provinces.Add(mao);


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