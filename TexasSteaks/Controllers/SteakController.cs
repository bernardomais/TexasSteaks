using Microsoft.AspNetCore.Mvc;
using TexasSteaks.Repositories.Interfaces;

namespace TexasSteaks.Controllers
{
    public class SteakController : Controller
    {
        private readonly ISteakRepository _steakRepository;

        public SteakController(ISteakRepository steakRepository)
        {
            _steakRepository = steakRepository;
        }

        public IActionResult List()
        {
            var steaks = _steakRepository.Steaks;
            return View(steaks);
        }
    }
}
