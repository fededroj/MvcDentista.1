using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcDentista.Data;
using MvcDentista.Models;

namespace MvcDentista.Controllers
{
    public class PacientesController : Controller
    {
        private readonly MvcDentistaContext _context;

        public PacientesController(MvcDentistaContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index(string apellidoPaciente, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Paciente
                                            orderby m.Apellido
                                            select m.Apellido;

            var pacientes = from m in _context.Paciente
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                pacientes = pacientes.Where(s => s.Nombre.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(apellidoPaciente))
            {
                pacientes = pacientes.Where(x => x.Apellido == apellidoPaciente);
            }

            var pacienteApellidoVM = new ApellidoPacienteViewModel
            {
                Apellido = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Pacientes = await pacientes.ToListAsync()
            };

            return View(pacienteApellidoVM);
        }

        //
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }


        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,FechaAsistencia,Domicilio,Localidad,Profesion,Edad")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,FechaAsistencia,Domicilio,Localidad,Profesion,Edad")] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _context.Paciente.Any(e => e.Id == id);
        }
    }
}
