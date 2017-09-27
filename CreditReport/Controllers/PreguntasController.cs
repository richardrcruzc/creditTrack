using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CreditReport.Models;
using CreditReport.Data;
using CreditReport.Data.PersonalInformation;
using Microsoft.EntityFrameworkCore;

namespace CreditReport.Controllers
{
    [Authorize]
    public class PreguntasController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;


        public PreguntasController(
            ApplicationDbContext context, 
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        // GET: People
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString,   int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["descriptionSortParm"] = String.IsNullOrEmpty(sortOrder) ? "description" : "";
         
           
            if (searchString != null  )
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var questions = from p in _context.Questions.Include(x=>x.MotherQuestion)
                            where p.MotherQuestion ==null select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                questions = questions.Where(s => s.Description.Contains(searchString));
            }
            


            switch (sortOrder)
            {
                case "description":
                    questions = questions.OrderBy(s => s.Description);
                    break;
                 
                default:
                    questions = questions.OrderByDescending(s => s.Created);
                    break;
            }

            int pageSize = 5;

            return View(await PaginatedList<Question>.CreateAsync(questions.AsNoTracking(), page ?? 1, pageSize));


        }
        public async Task<IActionResult> Repuestas(int id, int? page)
        {


            var question = await (from p in _context.Questions
                            .Include(x => x.MotherQuestion)
                            .Include(x => x.ChildrenQuestion)
                            where p.QuestionID == id
                            select p).FirstOrDefaultAsync();

            IQueryable<Question> questions = question.ChildrenQuestion.AsQueryable(); 
            

            int pageSize = 5;

            return View(question);


        }


        //[HttpPost]       
        //public async Task<IActionResult> AgregarPregunta(string NuevaPregunta)
        //{
        //    if(string.IsNullOrEmpty(NuevaPregunta))
        //        return RedirectToAction("index");

        //    var user = _userManager.GetUserName(User);
        //    var date = DateTime.Now;
        //    var question = new Question
        //    {
        //        Created =date,
        //         CreatedBy= user,
        //          Description = NuevaPregunta,
        //           Status = QuestionStatus.Publica
        //    };

        //    _context.Add(question);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("index");
        //}


        [HttpPost]       
        public async Task<IActionResult> AgregarPregunta(string NuevaPregunta, int QuestionID = 0)
        {

            if (string.IsNullOrEmpty(NuevaPregunta))
                return RedirectToAction("index");

            var user = _userManager.GetUserName(User);
            var date = DateTime.Now;
            var question = new Question
            {
                Created =date,
                 CreatedBy= user,
                  Description = NuevaPregunta,
                   Status = QuestionStatus.Publica
            };
            if (QuestionID > 0)
            {
                var qMadre =await _context.Questions.FindAsync(QuestionID);
                question.MotherQuestion = qMadre;

            }

            _context.Add(question);
            await _context.SaveChangesAsync();
            if (QuestionID > 0)
                return RedirectToAction("Repuestas", new { id = QuestionID });

            return RedirectToAction("index");
        }
    }
}