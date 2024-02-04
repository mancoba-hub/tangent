using System.Collections.Generic;
using System.Threading.Tasks;

namespace Liso.Tangent
{
    public interface ISuperheroService
    {
        Task<List<Superhero>> SearchSuperheroAsync(string search);

        Task<Superhero> SearchSuperheroAsync(int id);

        Task<bool> AddFavouritesAsync(Superhero superhero);

        Task<IEnumerable<Favourite>> GetFavouritesAsync();
    }
}
