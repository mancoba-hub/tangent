using System.Threading.Tasks;
using System.Collections.Generic;

namespace Liso.Tangent
{
    public interface IFavouriteRepository
    {
        Task<bool> AddFavourite(Favourite favourite);

        Task<bool> AddFavourites(List<Favourite> favouriteList);

        Task<Favourite> GetFavourite(string name);

        Task<IEnumerable<Favourite>> GetFavourites();
    }
}
