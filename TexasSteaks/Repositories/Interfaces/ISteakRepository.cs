using TexasSteaks.Models;

namespace TexasSteaks.Repositories.Interfaces
{
    public interface ISteakRepository
    {
        IEnumerable<Steak> Steaks { get; }
        IEnumerable<Steak> FavoritesSteaks { get; }
        Steak GetSteakById(int id);
    }
}
