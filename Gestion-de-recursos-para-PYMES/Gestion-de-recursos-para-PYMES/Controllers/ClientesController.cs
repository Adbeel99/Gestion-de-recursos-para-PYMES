using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestion_de_recursos_para_PYMES.Data;
using Gestion_de_recursos_para_PYMES.Models;
using System.Threading.Tasks;

namespace Gestion_de_recursos_para_PYMES.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ClientesController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var clientes = await _db.Clientes.AsNoTracking().ToListAsync();
            return View(clientes);
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (!ModelState.IsValid) return View(cliente);
            cliente.FechaRegistro = DateTime.UtcNow;
            _db.Clientes.Add(cliente);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}