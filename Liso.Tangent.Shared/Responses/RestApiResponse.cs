using System.Collections.Generic;

namespace Liso.Tangent
{
    public class RestApiResponse
    {
        public string Response { get; set; }

        public string ResultsFor { get; set; }

        public List<Result> Results { get; set; }
    }
}
