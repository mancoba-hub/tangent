using System.Collections.Generic;
using System.Threading.Tasks;

namespace Liso.Tangent
{
    public class SuperheroService : ISuperheroService
    {
        #region Properties

        private readonly IRestHelper _restHelper;
        private readonly IFavouriteRepository _favouriteRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SuperheroService"/> class.
        /// </summary>
        /// <param name="restHelper"></param>
        /// <param name="favouriteRepository"></param>
        public SuperheroService(IRestHelper restHelper, IFavouriteRepository favouriteRepository)
        {
            _restHelper = restHelper;
            _favouriteRepository = favouriteRepository;
        }

        #endregion

        #region Implemented Members

        /// <summary>
        /// Adds the superhero to favourites asynchronously
        /// </summary>
        /// <param name="superheroes"></param>
        /// <returns></returns>
        public async Task<bool> AddFavouritesAsync(Superhero superhero)
        {
            var favourite = superhero.ToFavourite();
            return await _favouriteRepository.AddFavourite(favourite);
        }

        /// <summary>
        /// Gets all favourites asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Favourite>> GetFavouritesAsync()
        {
            return await _favouriteRepository.GetFavourites();
        }

        /// <summary>
        /// Searches for superhero asynchronously
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<List<Superhero>> SearchSuperheroAsync(string search)
        {
            var heroList = await _restHelper.SearchSuperhero(search);
            return heroList.ToSuperheroList();
        }

        /// <summary>
        /// Searches the superhero asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Superhero> SearchSuperheroAsync(int id)
        {
            var heroList = await _restHelper.SearchSuperhero(id);
            return heroList.ToSuperhero();
        }

        #endregion
    }
}
