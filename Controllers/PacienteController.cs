using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;

namespace Hospital.controllers
{
    public class PacienteController : Controller
    {
        private readonly HospitalContext _context;

        public PacienteController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Paciente
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paciente.ToListAsync());
        }

        // GET: Paciente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Paciente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paciente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaciente,Nombre,Apellido,Cedula,Email,Direccion")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: Paciente/Edit/5
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

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaciente,Nombre,Apellido,Cedula,Email,Direccion")] Paciente paciente)
        {
            if (id != paciente.IdPaciente)
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
                    if (!PacienteExists(paciente.IdPaciente))
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

        // GET: Paciente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            string eliminar = Request.Form["del"].ToString();
            if(eliminar.Equals("eliminar")){
                var paciente = await _context.Paciente.FindAsync(id);
                _context.Paciente.Remove(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }else{
                return RedirectToAction(nameof(Index));
            }
            
        }

        private bool PacienteExists(int id)
        {
            return _context.Paciente.Any(e => e.IdPaciente == id);
        }
    }
}
