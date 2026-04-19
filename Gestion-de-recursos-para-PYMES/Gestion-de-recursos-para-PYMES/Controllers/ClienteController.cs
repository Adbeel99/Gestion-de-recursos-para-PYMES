using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Gestion_de_recursos_para_PYMES.Models;
using Gestion_de_recursos_para_PYMES.Services;

namespace Gestion_de_recursos_para_PYMES.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            var clientes = _clienteService.ObtenerTodos();
            return View(clientes);
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid) return View(cliente);
            cliente.FechaRegistro = DateTime.UtcNow;
            _clienteService.Crear(cliente);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var cliente = _clienteService.ObtenerPorId(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente cliente)
        {
            if (!ModelState.IsValid) return View(cliente);
            _clienteService.Editar(cliente);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var cliente = _clienteService.ObtenerPorId(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        public IActionResult Delete(int id)
        {
            var cliente = _clienteService.ObtenerPorId(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _clienteService.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
