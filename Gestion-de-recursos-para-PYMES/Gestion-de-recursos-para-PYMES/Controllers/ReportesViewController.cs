using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Gestion_de_recursos_para_PYMES.Constants;

namespace Gestion_de_recursos_para_PYMES.Controllers
{
    [Authorize(Roles = Roles.Vendedor)]
    public class ReportesViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}