using TexasSteaks.Models;

namespace TexasSteaks.ViewModels
{
    public class SteakListViewModel
    {
        public IEnumerable<Steak> Steaks { get; set; }
        public string CurrentCategory { get; set; }
    }
}
