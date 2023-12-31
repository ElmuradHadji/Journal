using AutoMapper;
using Journal.Context;
using Journal.DTOs;
using Journal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Journal.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public HomeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IActionResult Index()
        {

            List<journal> journals = _context.Journals.Where(c => !c.IsDeleted).ToList();
            List<JournalGetDto> journalsGet = _mapper.Map<List<JournalGetDto>>(journals);
            return View(journalsGet);
        }

        
    }
}