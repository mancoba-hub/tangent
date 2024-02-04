using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Liso.Tangent.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class SuperheroController : ControllerBase
    {
        #region Properties

        private readonly ISuperheroService _superheroService;
        private readonly ILogger<SuperheroController> _superheroLogger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SuperheroController"/> class.
        /// </summary>
        /// <param name="superheroLogger"></param>
        /// <param name="superheroService"></param>
        public SuperheroController(ILogger<SuperheroController> superheroLogger, ISuperheroService superheroService)
        {
            _superheroLogger = superheroLogger;
            _superheroService = superheroService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds the superhero to favourites
        /// </summary>
        /// <param name="superhero"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("favourite/")]
        public async Task<Response<bool>> AddFavourite([FromBody] Superhero superhero)
        {
            try
            {
                var response = await _superheroService.AddFavouritesAsync(superhero);
                return ResponseMessage.ToResponseHelper(response);
            }
            catch (TangentException exc)
            {
                _superheroLogger.LogError($"An error occured", exc);
                return ResponseMessage.ToResponseHelper<bool>(false, exc.Message, exc.ToString(), false);
            }
        }

        /// <summary>
        /// Gets all favourites
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("favourites/")]
        public async Task<Response<List<Superhero>>> GetFavourites()
        {
            try
            {
                var response = await _superheroService.GetFavouritesAsync();
                return ResponseMessage.ToResponseHelper(response.ToList().ToSuperheroes());
            }
            catch (TangentException exc)
            {
                _superheroLogger.LogError($"An error occured", exc);
                return ResponseMessage.ToResponseHelper<List<Superhero>>(null, exc.Message, exc.ToString(), false);
            }
        }

        /// <summary>
        /// Gets the superhero by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getById/")]
        public async Task<Response<Superhero>> GetSuperheroById(string id)
        {
            try
            {
                var response = await _superheroService.SearchSuperheroAsync(id.ToInt());
                return ResponseMessage.ToResponseHelper(response);
            }
            catch (TangentException exc)
            {
                _superheroLogger.LogError($"An error occured", exc);
                return ResponseMessage.ToResponseHelper<Superhero>(null, exc.Message, exc.ToString(), false);
            }
        }

        /// <summary>
        /// Gets the superhero by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getByName/")]
        public async Task<Response<List<Superhero>>> GetSuperheroByName(string name)
        {
            try
            {
                var response = await _superheroService.SearchSuperheroAsync(name);
                return ResponseMessage.ToResponseHelper(response);
            }
            catch (TangentException exc)
            {
                _superheroLogger.LogError($"An error occured", exc);
                return ResponseMessage.ToResponseHelper<List<Superhero>>(null, exc.Message, exc.ToString(), false);
            }
        }

        #endregion
    }
}
