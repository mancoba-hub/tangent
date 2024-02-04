using Newtonsoft.Json;
using System.Collections.Generic;

namespace Liso.Tangent
{
    public static class ConverterHelper
    {
        /// <summary>
        /// Converts to Favourites
        /// </summary>
        /// <param name="superheroes"></param>
        /// <returns></returns>
        public static List<Favourite> ToFavourites(this List<Superhero> superheroes)
        {
            List<Favourite> favourites = new List<Favourite>();
            foreach (var item in superheroes)
                favourites.Add(item.ToFavourite());

            return favourites;
        }

        /// <summary>
        /// Converts to Favourite
        /// </summary>
        /// <param name="superhero"></param>
        /// <returns></returns>
        public static Favourite ToFavourite(this Superhero superhero)
        {
            return new Favourite
            {
                HeroId = superhero.Id,
                Name = superhero.Name,
                Image = superhero.Image.Url,
                DateCreated = System.DateTime.Now,
                RawData = JsonConvert.SerializeObject(superhero)
            };
        }

        /// <summary>
        /// Converts to superhero list
        /// </summary>
        /// <param name="superheroResponse"></param>
        /// <returns></returns>
        public static List<Superhero> ToSuperheroList(this RestApiResponse response)
        {
            List<Superhero> superheroes = new();
            foreach (var item in response.Results)
            {
                superheroes.Add(new Superhero
                {
                    Id = item.Id,
                    Name = item.Name,
                    Appearance = item.Appearance,
                    Biography = item.Biography,
                    Connections = item.Connections,
                    Powerstats = item.Powerstats,
                    Work = item.Work,
                    Image = item.Image,
                });
            }

            return superheroes;
        }

        /// <summary>
        /// Converts to superhero list
        /// </summary>
        /// <param name="superheroResponse"></param>
        /// <returns></returns>
        public static Superhero ToSuperhero(this SuperheroResponse superheroResponse)
        {
            return new Superhero
            {
                Id = superheroResponse.Id,
                Name = superheroResponse.Name,
                Appearance = superheroResponse.Appearance,
                Biography = superheroResponse.Biography,
                Connections = superheroResponse.Connections,
                Powerstats = superheroResponse.Powerstats,
                Work = superheroResponse.Work,
                Image = superheroResponse.Image,                
            };
        }

        /// <summary>
        /// Converts favourites to superheros 
        /// </summary>
        /// <param name="favourites"></param>
        /// <returns></returns>
        public static List<Superhero> ToSuperheroes(this List<Favourite> favourites)
        {
            List<Superhero> superheroes = new List<Superhero>();
            foreach (var item in favourites)
            {
                superheroes.Add(item.ToSuperhero());
            }
            return superheroes;
        }

        /// <summary>
        /// Converts the favourites to superhero object
        /// </summary>
        /// <param name="favourite"></param>
        /// <returns></returns>
        public static Superhero ToSuperhero(this Favourite favourite)
        {
            var superhero = JsonConvert.DeserializeObject<Superhero>(favourite.RawData);
            return new Superhero
            {
                Id = favourite.HeroId,
                Name = favourite.Name,
                Appearance = superhero.Appearance,
                Biography = superhero.Biography,
                Connections = superhero.Connections,
                Powerstats = superhero.Powerstats,
                Work = superhero.Work,
                Image = superhero.Image
            };
        }
    }
}
