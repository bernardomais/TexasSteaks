using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TexasSteaks.Models;
using TexasSteaks.Repositories.Interfaces;

namespace TexasSteaks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISteakRepository _steakRepository;

        public HomeController(ISteakRepository steakRepository)
        {
            _steakRepository = steakRepository;
        }

        public IActionResult Index()
        {
            var favoritesSteaks = _steakRepository.FavoritesSteaks;
            return View(favoritesSteaks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
