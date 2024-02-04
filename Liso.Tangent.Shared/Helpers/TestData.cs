using System.Collections.Generic;

namespace Liso.Tangent
{
    public static class TestData
    {
        /// <summary>
        /// Gets the favourites
        /// </summary>
        /// <returns></returns>
        public static List<Favourite> GetFavourites()
        {
            return new List<Favourite>
            {
                new Favourite
                {
                    Id = 1,
                    HeroId = "483",
                    Name = "Namora",
                    DateCreated = System.DateTime.Now.AddDays(-1),
                    Image = "https://www.superherodb.com/pictures2/portraits/10/100/1364.jpg",
                    RawData = "{\"response\":\"success\",\"results\":[{\"appearance\":{\"eye-color\":\"Blue\",\"gender\":\"Female\",\"hair-color\":\"Blond\",\"height\":[\"5'11\",\"180cm\"],\"race\":\"null\",\"weight\":[\"189lb\",\"85kg\"]},\"biography\":{\"aliases\":[\"Sub-Mariner\",\"AvengingDaughter\",\"theSeaBeauty\"],\"alignment\":\"good\",\"alter-egos\":\"Noalteregosfound.\",\"first-appearance\":\"MarvelMysteryComics#82(1947)\",\"full-name\":\"AquariaNauticaNeptunia\",\"place-of-birth\":\"UnnamedAtlanteanoutpost\",\"publisher\":\"MarvelComics\"},\"connections\":{\"group-affiliation\":\"AgentsofAtlas,Long-timeallyofNamor;MonsterHunters,Invaders,AllWinnersSquad;AtonetimeoranotherwaspartneredwithFBIAgentJimmyWoo,SunGirl,Venus,GoldenGirl,Hulk\",\"relatives\":\"Namor(cousin),Talan(husband,deceased),Namorita\"},\"id\":\"483\",\"image\":{\"url\":\"https://www.superherodb.com/pictures2/portraits/10/100/1364.jpg\"},\"name\":\"Namora\",\"powerstats\":{\"combat\":\"64\",\"durability\":\"42\",\"intelligence\":\"50\",\"power\":\"48\",\"speed\":\"42\",\"strength\":\"85\"},\"work\":{\"base\":\"-\",\"occupation\":\"-\"}}],\"results-for\":\"Namora\"}"
                }
            };
        }

        /// <summary>
        /// Gets the superheros
        /// </summary>
        /// <returns></returns>
        public static List<Superhero> GetSuperheroes()
        {
            return new List<Superhero>
            {
                new Superhero
                {
                    Id = "257",
                    Name = "Firebird",
                    Powerstats = GetPowerstats(),
                    Biography = GetBiography(),
                    Appearance = GetAppearance(),
                    Work = GetWork(),
                    Connections = GetConnections(),
                    Image = GetImage()
                }
            };
        }

        public static RestApiResponse GetRestApiResponse(string name)
        {
            return new RestApiResponse
            {
                Response = "success",
                ResultsFor = name,
                Results = GetResults(name)
            };
        }

        /// <summary>
        /// Gets the superhero response by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SuperheroResponse GetSuperheroResponse(string name)
        {
            return new SuperheroResponse
            {
                Id = "257",
                Name = name,
                Response = "success",
                Powerstats = GetPowerstats(),
                Biography = GetBiography(),
                Appearance = GetAppearance(),
                Work = GetWork(),
                Connections = GetConnections(),
                Image = GetImage()
            };
        }

        /// <summary>
        /// Get the results by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static List<Result> GetResults(string name)
        {
            List<Result> results = new()
            {
                new Result
                {
                    Id = "483",
                    Name = name,
                    Powerstats = GetPowerstats(),
                    Biography = GetBiography(),
                    Appearance = GetAppearance(),
                    Work = GetWork(),
                    Connections = GetConnections(),
                    Image = GetImage()
                }
            };

            return results;
        }

        /// <summary>
        /// Get the power stats
        /// </summary>
        /// <returns></returns>
        private static Powerstats GetPowerstats()
        {
            return new Powerstats
            {
                Intelligence = "50",
                Strength = "85",
                Speed = "42",
                Durability = "48",
                Power = "48",
                Combat = "64"
            };
        }

        /// <summary>
        /// Gets the biography
        /// </summary>
        /// <returns></returns>
        private static Biography GetBiography()
        {
            return new Biography
            {
                Fullname = "Bonita Espirita",
                Alteregos = "No alter egos found.",
                Aliases = new List<string> { "Pajaro Del Fuego", "La Espirita" },
                PlaceOfBirth = "Buena Vista, New Mexico",
                FirstAppearance = "INCREDIBLE HULK Vol. 2 #265",
                Publisher = "Marvel Comics",
                Alignment = "Good"
            };
        }

        /// <summary>
        /// Gets the appearance
        /// </summary>
        /// <returns></returns>
        private static Appearance GetAppearance()
        {
            return new Appearance
            {
                Gender = "Female",
                Race = "White",
                EyeColor = "Brown",
                HairColor = "Black",
                Height = new List<string> { "5,5", "165 cm" },
                Weight = new List<string> { "125 lb", "59 kg"}
            };
        }

        /// <summary>
        /// Gets the work
        /// </summary>
        /// <returns></returns>
        private static Work GetWork()
        {
            return new Work
            {
                Occupation = "Social worker",
                Base = "New Mexico"
            };
        }

        /// <summary>
        /// Gets the connections
        /// </summary>
        /// <returns></returns>
        private static Connections GetConnections()
        {
            return new Connections
            {
                GroupAffiliation = "Catholic Church",
                Relatives = "-"
            };
        }

        /// <summary>
        /// Gets the image
        /// </summary>
        /// <returns></returns>
        private static Image GetImage()
        {
            return new Image
            {
                Url = "https://www.superherodb.com/pictures2/portraits/10/100/1364.jpg"
            };
        } 
    }
}
