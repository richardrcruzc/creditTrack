using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CreditReport.Data;
using CreditReport.Data.PersonalInformation;
using CreditReport.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CreditReport.Models.People;
using System.Collections.Generic;

namespace CreditReport.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;


        public PeopleController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;    
        }
        // GET: People
        public async Task<IActionResult> Cedula(string Identification)
        {
            var exite = await _context.Persons.Where(x => x.Identification == Identification).FirstOrDefaultAsync();
            if (exite == null)
                return Json(true);
            
            else
                return Json(false);


        }
            // GET: People
            public async Task<IActionResult> Query(string cedula)
        {
             
            if (!string.IsNullOrWhiteSpace(cedula))
            {
                
                var exite =await _context.Persons.Where(x=>x.Identification==cedula).FirstOrDefaultAsync();



                if (exite != null)
                    return RedirectToAction("details", new { id = exite.PersonID });
                else
                    ViewBag.Info = "Información no encontrada";
            }

            
            return View();

        }

        // GET: People
         public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, string searchId, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["LastNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            ViewData["firstNameSortParm"] = sortOrder == "firstname" ? "firstname_desc" : "firstname";
          

            if (searchString != null || searchId!=null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var peoples = from p in _context.Persons select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                peoples = peoples.Where(s => s.LastName.Contains(searchString)
                                       || s.LastName.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(searchId))
            {
                peoples = peoples.Where(s => s.Identification.Contains(searchId));
            }


            switch (sortOrder)
            {
                case "lastname_desc":
                    peoples = peoples.OrderByDescending(s => s.LastName);
                    break;
                case "firstname":
                    peoples = peoples.OrderBy(s => s.FirstName);
                    break;
                case "firstname_desc":
                    peoples = peoples.OrderByDescending(s => s.FirstName);
                    break;
                default:
                    peoples = peoples.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 5;

            return View(await PaginatedList<Person>.CreateAsync(peoples.AsNoTracking(),page??1, pageSize));

             
        }

        // GET: People/Details/5
         public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            } 

            var person = await _context.Persons
                 .Include(c=>c.CreditHistories)
                 .AsNoTracking()
                .SingleOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create

        public IActionResult Agregar()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar(PeopleAddModel p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userManager.GetUserName(User);
                    var persona = new Person
                    {
                        Identification = p.Identification,
                         LastName =p.LastName,
                         FirstName = p.FirstName,
                         Created = DateTime.Now,
                         CreateBy= user, 
                    };

                    var credit = new CreditHistory { CreateDate = DateTime.Now, Note = p.Description, Person= persona };
                    var credits = new List<CreditHistory>();
                    credits.Add(credit);

                    persona.AddCreditHistory(credits);

                    _context.Add(persona);
                    
                    await _context.SaveChangesAsync();


                    ModelState.AddModelError("","La Persona ha Sido Creada.");
                    //return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException  ex )
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("",ex.Message+ " Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(p);
        }


        // GET: People/Create
        public IActionResult AgregarHistorial(int id)
        {
            var persona = _context.Persons.Where(x => x.PersonID == id).FirstOrDefault();
            if (persona == null)
                return null;

            var ch = new AddCreditHistory { PersonID = persona.PersonID, FirstName=persona.FirstName, LastName= persona.LastName, Identification = persona.Identification };

            return View(ch);
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarHistorial(AddCreditHistory c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userManager.GetUserName(User);
                    var persona = _context.Persons.Where(x => x.PersonID == c.PersonID).FirstOrDefault();
                    if(persona==null)
                        return View(c);

                    var credit = new CreditHistory { Person = persona, CreateDate = DateTime.Now, Note = c.Description, CreateBy= user };

                    var credits = new List<CreditHistory>();
                    credits.Add(credit); 

                    persona.AddCreditHistory(credits);

                    _context.Update(persona);

                    await _context.SaveChangesAsync();

                    ModelState.AddModelError("", "El historial hasido creado.");
                    //return RedirectToAction("Index");

                    c.FirstName = persona.FirstName;
                    c.LastName = persona.LastName;
                    c.PersonID = persona.PersonID;
                    c.Identification = persona.Identification;
                }
            }
            catch (DbUpdateException ex)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", ex.Message + " Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(c);
        }

       
        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(Person person)
        {
            try
            {
                if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists " +
                        "see your system administrator.");
                }
            return View(person);
        }

        // GET: People/Edit/5
       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons 
                .SingleOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Edit(int id, [Bind("PersonID,Identification,PasswordHash,FirstName,LastName,Email,Gender,Avatar")] Person person)
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        
        public async Task<IActionResult> Delete(int? id )
        {
            if (id == null)
            {
                return NotFound();
            } 

            var person = await _context.Persons
                 .AsNoTracking()
                .SingleOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> DeleteConfirmed(Person p)
        {
            var person = await _context.Persons.SingleOrDefaultAsync(m => m.PersonID == p.PersonID);

            try
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",  ex.Message);
                return View(person);
            }
           
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.PersonID == id);
        }
    }
}
