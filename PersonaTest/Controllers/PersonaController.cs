using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PersonaTest.Models;

namespace PersonaTest.Controllers
{
    public class PersonaController : Controller
    {
        private readonly PctestContext _context;

        public PersonaController(PctestContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() => View( await _context.Personas.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FirstOrDefaultAsync(p => p.Identidad == id);

            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(persona);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FirstOrDefaultAsync(p => p.Identidad == id);

            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(Persona persona)
        {
            if (ModelState.IsValid) 
            {
                _context.Update(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FirstOrDefaultAsync(p => p.Identidad == id);
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


      
    }
}
