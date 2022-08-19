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
    public class MedicoController : Controller
    {
        private readonly HospitalContext _context;

        public MedicoController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Medico
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medico.ToListAsync());
        }

        // GET: Medico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico
                .Where(m => m.IdMedico == id).Include(me =>me.MedicoEspecialidad)
                .ThenInclude(e => e.Especialidad).FirstOrDefaultAsync();
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // GET: Medico/Create
        public IActionResult Create()
        {
            ViewData["ListaEspecialidades"] = new SelectList(_context.Especialidad,"IdEspecialidad","Nombre");
            return View();
        }

        // POST: Medico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedico,Nombre,Apellido,Cedula")] Medico medico,int IdEspecialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();
                //Guarda la especialida en la tabla relacion MedicoEspecialidad
                var medicoEspecialidad = new MedicoEspecialidad();
                medicoEspecialidad.IdMedico = medico.IdMedico;
                medicoEspecialidad.IdEspecialidad = IdEspecialidad;

                _context.Add(medicoEspecialidad);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        // GET: Medico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico.Where( m => m.IdMedico == id)
            .Include(me => me.MedicoEspecialidad).FirstOrDefaultAsync();

            if (medico == null)
            {
                return NotFound();
            }
            ViewData["ListaEspecialidades"] = new SelectList(
                _context.Especialidad, "IdEspecialidad","Nombre", medico.MedicoEspecialidad[0].IdEspecialidad);
            
            return View(medico);
        }

        // POST: Medico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedico,Nombre,Apellido,Cedula")] Medico medico, int IdEspecialidad)
        {
            if (id != medico.IdMedico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medico);
                    await _context.SaveChangesAsync();

                    var medicoEspecialidad = await _context.MedicoEspecialidad
                    .FirstOrDefaultAsync(me => me.IdMedico == id);

                    _context.Remove(medicoEspecialidad);
                    await _context.SaveChangesAsync();

                    medicoEspecialidad.IdEspecialidad = IdEspecialidad;

                    _context.Add(medicoEspecialidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoExists(medico.IdMedico))
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
            return View(medico);
        }

        // GET: Medico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico
                .FirstOrDefaultAsync(m => m.IdMedico == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // POST: Medico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string eliminar = Request.Form["del"].ToString();
            if(eliminar.Equals("eliminar")){
                var medicoEspecialidad = await _context.MedicoEspecialidad
                .FirstOrDefaultAsync(me => me.IdMedico == id);

                _context.MedicoEspecialidad.Remove(medicoEspecialidad);
                await _context.SaveChangesAsync();

                var medico = await _context.Medico.FindAsync(id);
                _context.Medico.Remove(medico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }else{
                return RedirectToAction(nameof(Index));
            }
            
        }

        private bool MedicoExists(int id)
        {
            return _context.Medico.Any(e => e.IdMedico == id);
        }
    }
}
