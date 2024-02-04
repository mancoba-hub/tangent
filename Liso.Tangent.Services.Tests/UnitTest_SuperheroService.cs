using Moq;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Liso.Tangent.Services.Tests
{
    [TestClass]
    public class UnitTest_SuperheroService
    {
        #region Properties

        private Mock<IRestHelper> _mockRestHelper;        
        private ISuperheroService superheroService;
        private Mock<IFavouriteRepository> _mockFavouriteRepository;

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes the tests
        /// </summary>
        [TestInitialize]
        public void InitializeTests()
        {
            _mockRestHelper = new Mock<IRestHelper>(MockBehavior.Strict);
            _mockFavouriteRepository = new Mock<IFavouriteRepository>(MockBehavior.Strict);
        }

        #endregion

        #region Unit Tests

        /// <summary>
        /// Test the method to add superhero to favourites failure
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        public void TestMethod_AddFavourites_Failure()
        {
            //Arrange
            bool outcome = false;
            var superhero = TestData.GetSuperheroes().First();
            _mockFavouriteRepository.Setup(x => x.AddFavourite(It.IsAny<Favourite>())).Returns(Task.FromResult(outcome));
            superheroService = new SuperheroService(_mockRestHelper.Object, _mockFavouriteRepository.Object);

            //Act
            var response = superheroService.AddFavouritesAsync(superhero);

            //Assert
            Assert.IsNotNull(response);
            var results = response.Result;
            Assert.IsFalse(results);
        }

        /// <summary>
        /// Test the method to add superhero to favourites successfully
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        public void TestMethod_AddFavourites_Success()
        {
            //Arrange
            bool outcome = true;
            var superhero = TestData.GetSuperheroes().First();
            _mockFavouriteRepository.Setup(x => x.AddFavourite(It.IsAny<Favourite>())).Returns(Task.FromResult(outcome));
            superheroService = new SuperheroService(_mockRestHelper.Object, _mockFavouriteRepository.Object);

            //Act
            var response = superheroService.AddFavouritesAsync(superhero);

            //Assert
            Assert.IsNotNull(response);
            var results = response.Result;
            Assert.IsTrue(results);
        }

        /// <summary>
        /// Test the method to search for superhero by name successfully
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        public void TestMethod_SearchSuperhero_ByName_Success()
        {
            //Arrange
            string name = "Firebird";
            var superheros = TestData.GetSuperheroes();
            var superheroResponse = TestData.GetRestApiResponse(name);
            _mockRestHelper.Setup(x => x.SearchSuperhero(It.IsAny<string>())).Returns(Task.FromResult(superheroResponse));
            superheroService = new SuperheroService(_mockRestHelper.Object, _mockFavouriteRepository.Object);

            //Act
            var response = superheroService.SearchSuperheroAsync(name);

            //Assert
            Assert.IsNotNull(response);
            var result = response.Result.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.AreEqual(name, result.Name);
        }

        /// <summary>
        /// Test the method to search for superhero by id successfully
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        public void TestMethod_SearchSuperhero_ById_Success()
        {
            //Arrange
            int id = 257;
            string name = "Firebird";
            var superheros = TestData.GetSuperheroes();
            var superheroResponse = TestData.GetSuperheroResponse(name);
            _mockRestHelper.Setup(x => x.SearchSuperhero(It.IsAny<int>())).Returns(Task.FromResult(superheroResponse));
            superheroService = new SuperheroService(_mockRestHelper.Object, _mockFavouriteRepository.Object);

            //Act
            var response = superheroService.SearchSuperheroAsync(id);

            //Assert
            Assert.IsNotNull(response);
            var result = response.Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(id.ToString(), result.Id);
            Assert.AreEqual(name, result.Name);
        }

        #endregion
    }
}
