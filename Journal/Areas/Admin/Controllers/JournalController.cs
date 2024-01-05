using AutoMapper;
using Journal.Context;
using Journal.DTOs;
using Journal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Journal.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class JournalController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public JournalController(AppDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }
        // GET: JournalController
        public ActionResult Index()
        {
            List<journal> journals = _context.Journals.Where(c => !c.IsDeleted).ToList();
            List<JournalGetDto> journalsGet = _mapper.Map<List<JournalGetDto>>(journals);
            foreach (JournalGetDto journalDto in journalsGet)
            {
                foreach (journal journal in journals)
                {
                    if (journal.Id == journalDto.Id)
                    {
                        journalDto.PrintTime = DateTime.Parse(journal.PrintTime);
                    }
                }
            }
            return View(journalsGet);
        }

   

        // GET: JournalController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JournalController/Create
        [HttpPost]
        public IActionResult Create(JournalPostDto journalPostDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something Went wrong");
                return View(journalPostDto);
            }
         
            journal journal = _mapper.Map<journal>(journalPostDto);
            journal.Display=journalPostDto.Display;

            journal.PrintTime = journalPostDto.PrintTime.ToString();


            _context.Journals.Add(journal);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: JournalController/Edit/5
        public IActionResult Update(int id)
        {
            journal journal = _context.Journals.Find(id);
            if (journal is null) { return NotFound(); }
            JournalUpdateDto journalUpdateDto = new JournalUpdateDto { journalGetDto = _mapper.Map<JournalGetDto>(journal) };
            journalUpdateDto.journalGetDto.PrintTime = DateTime.Parse(journal.PrintTime);
            return View(journalUpdateDto);
        }

        // POST: JournalController/Edit/5
        [HttpPost]
        public IActionResult Update(JournalUpdateDto journalUpdateDto)
        {
            journal journal = _context.Journals.Find(journalUpdateDto.journalGetDto.Id);
            if (journal is null) { return NotFound(); }
         

           /* if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something Went wrong");
                return View(journalUpdateDto);
            }*/
            //Category = _mapper.Map<Category>(CategoryUpdateDto.CategoryPostDto);





            

            // _context.Add(Category);
            journal.IsDeleted = false;
            journal.Name = journalUpdateDto.journalPostDto.Name;
            journal.Description = journalUpdateDto.journalPostDto.Description;
            journal.PrintTime = journalUpdateDto.journalPostDto.PrintTime.ToString();
            journal.Display= journalUpdateDto.journalPostDto.Display;

            _context.SaveChanges();
            //return Json(result1);
            return RedirectToAction(nameof(Index));
        }

        // GET: JournalController/Delete/5
        public IActionResult Delete(int id)
        {
            journal journal = _context.Journals.Find(id);
            if (journal == null) { return NotFound(); }
            journal.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

       
        
    }
}
