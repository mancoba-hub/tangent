using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Liso.Tangent
{
    public class FavouriteRepository : BaseRepository<Favourite>, IFavouriteRepository
    {
        #region Properties

        private readonly TangentContext _tangentContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FavouriteRepository"/> class.
        /// </summary>
        /// <param name="tangentContext"></param>
        public FavouriteRepository(TangentContext tangentContext) : base(tangentContext)
        {
            _tangentContext = tangentContext;
        }

        #endregion


        #region Implemented Members

        /// <summary>
        /// Adds a superhero to favourites
        /// </summary>
        /// <param name="favourite"></param>
        /// <returns></returns>
        public async Task<bool> AddFavourite(Favourite favourite)
        {
            var response = await CreateAsync(favourite);
            await _tangentContext.SaveChangesAsync();
            return response;
        }

        /// <summary>
        /// Adds superheros to the favourites
        /// </summary>
        /// <param name="favouriteList"></param>
        /// <returns></returns>
        public async Task<bool> AddFavourites(List<Favourite> favouriteList)
        {
            var response = await CreateListAsync(favouriteList);
            await _tangentContext.SaveChangesAsync();
            return response;
        }

        /// <summary>
        /// Gets a superhero favourite
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Favourite> GetFavourite(string name)
        {
            return await GetByQueryAsync(x => x.Name == name);
        }

        /// <summary>
        /// Gets all superhero favourites
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Favourite>> GetFavourites()
        {
            return await GetAllAsync();
        }

        #endregion
    }
}
