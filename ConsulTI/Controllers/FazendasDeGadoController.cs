using ConsulTI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConsulTI.Controllers
{

    public class FazendasDeGadoController : Controller
    {
        private readonly FazendaDeGadoServices _fazendaDeGadoServices;

        public FazendasDeGadoController(FazendaDeGadoServices fazendaDeGadoServices)
        {
            _fazendaDeGadoServices = fazendaDeGadoServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _fazendaDeGadoServices.GetFazendasAsync());
        }

    }
}
