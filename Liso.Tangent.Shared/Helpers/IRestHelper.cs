using System.Threading.Tasks;

namespace Liso.Tangent
{
    public interface IRestHelper
    {
        public Task<SuperheroResponse> SearchSuperhero(int id);

        public Task<RestApiResponse> SearchSuperhero(string name);
    }
}
