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
    public class AtencionController : Controller
    {
        private readonly HospitalContext _context;

        public AtencionController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Atencion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Atencion.ToListAsync());
        }

        // GET: Atencion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atencion = await _context.Atencion
                .Where(m => m.IdAtencion == id).Include(me =>me.AtencionMedico)
                .ThenInclude(e => e.Medico).FirstOrDefaultAsync();
          

           

            if (atencion == null)
            {
                return NotFound();
            }

            return View(atencion);
        }

        // GET: Atencion/Create
        public IActionResult Create()
        {
           
            ViewData["ListaMedicos"] = new SelectList(_context.Medico,"IdMedico","Nombre");
            return View();
        }

        // POST: Atencion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAtencion,NombrePaciente,NombreMedicamento,Fecha,Hora,Categoria")] Atencion atencion, int IdMedico)
        {
            if (ModelState.IsValid)
            {
                atencion.Fecha = DateTime.Now;
                atencion.Hora = DateTime.Now;
                _context.Add(atencion);
                await _context.SaveChangesAsync();

                //Guarda la especialida en la tabla relacion MedicoEspecialidad
                var atencionMedico = new AtencionMedico();
                atencionMedico.IdAtencion = atencion.IdAtencion;
                atencionMedico.IdMedico = IdMedico;

                _context.Add(atencionMedico);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(atencion);
        }

        // GET: Atencion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atencion = await _context.Atencion.Where( m => m.IdAtencion == id)
             .Include(me => me.AtencionMedico).FirstOrDefaultAsync();

            if (atencion == null)
            {
                return NotFound();
            }
             ViewData["ListaMedicos"] = new SelectList(
                _context.Medico, "IdMedico","Nombre",atencion.AtencionMedico[0].IdMedico);
            return View(atencion);
        }

        // POST: Atencion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAtencion,NombrePaciente,NombreMedicamento,Fecha,Hora,Categoria")] Atencion atencion, int IdMedico)
        {
            if (id != atencion.IdAtencion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atencion);
                    await _context.SaveChangesAsync();

                   var atencionMedico = await _context.AtencionMedico
                    .FirstOrDefaultAsync(me => me.IdAtencion == id);

                    _context.Remove(atencionMedico);
                    await _context.SaveChangesAsync();

                    atencionMedico.IdMedico = IdMedico;
                    atencion.Fecha = DateTime.Now;
                    atencion.Hora = DateTime.Now;
                    _context.Add(atencionMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtencionExists(atencion.IdAtencion))
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
            return View(atencion);
        }

        // GET: Atencion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atencion = await _context.Atencion
                .FirstOrDefaultAsync(m => m.IdAtencion == id);
            if (atencion == null)
            {
                return NotFound();
            }

            return View(atencion);
        }

        // POST: Atencion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atencionMedico = await _context.AtencionMedico
            .FirstOrDefaultAsync(me => me.IdAtencion == id);

            _context.AtencionMedico.Remove(atencionMedico);
            await _context.SaveChangesAsync();

            var atencion = await _context.Atencion.FindAsync(id);

            _context.Atencion.Remove(atencion);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool AtencionExists(int id)
        {
            return _context.Atencion.Any(e => e.IdAtencion == id);
        }
    }
}
