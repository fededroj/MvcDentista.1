using Microsoft.AspNetCore.Mvc;
using MvcDentista.Data;
using MvcDentista.Models;

namespace MvcDentista.Controllers
{
    public class TurnosController : Controller
    {

        private readonly MvcDentistaContext _context;
        public IActionResult Index()
        {
            return View();
        }
    }
}
