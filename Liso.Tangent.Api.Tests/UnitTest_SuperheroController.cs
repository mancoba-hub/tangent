using Moq;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Liso.Tangent.Api.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Liso.Tangent.Api.Tests
{
    [TestClass]
    public class UnitTest_SuperheroController
    {
        #region Properties

        private Mock<ISuperheroService> _mockSuperheroService;
        private SuperheroController superheroController;
        private Mock<ILogger<SuperheroController>> _mockSuperheroControllerLogger;

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes the tests
        /// </summary>
        [TestInitialize]
        public void InitializeTests()
        {
            _mockSuperheroService = new Mock<ISuperheroService>(MockBehavior.Strict);
            _mockSuperheroControllerLogger = new Mock<ILogger<SuperheroController>>(MockBehavior.Strict);
        }

        #endregion

        #region Unit Tests

        /// <summary>
        /// Tests the method AddFavourite successfully
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        public void TestMethod_AddFavourite_Success()
        {
            //Arrange
            bool added = true;
            var superhero = TestData.GetSuperheroes().First();
            _mockSuperheroService.Setup(x => x.AddFavouritesAsync(It.IsAny<Superhero>())).Returns(Task.FromResult(added));
            superheroController = new SuperheroController(_mockSuperheroControllerLogger.Object, _mockSuperheroService.Object);

            //Act
            var response = superheroController.AddFavourite(superhero);

            //Assert
            Assert.IsNotNull(response);
            var result = response.Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccessful);
            Assert.IsTrue(result.Data);
            Assert.IsTrue(string.IsNullOrWhiteSpace(result.ErrorMessage));
        }

        /// <summary>
        /// Tests the method to GetFavourites successfully
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        public void TestMethod_GetFavourites_Success()
        {
            //Arrange
            var favourites = TestData.GetFavourites().AsEnumerable();
            _mockSuperheroService.Setup(x => x.GetFavouritesAsync()).Returns(Task.FromResult(favourites));
            superheroController = new SuperheroController(_mockSuperheroControllerLogger.Object, _mockSuperheroService.Object);

            //Act
            var response = superheroController.GetFavourites();


            //Assert
            Assert.IsNotNull(response);
            var result = response.Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccessful);
            Assert.IsTrue(string.IsNullOrWhiteSpace(result.ErrorMessage));
            List<Superhero> favList = result.Data;
            Assert.IsTrue(favList.Any());
        }

        /// <summary>
        /// Tests the method to GetSuperheroById successfully
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        public void TestMethod_GetSuperheroById_Success()
        {
            //Arrange
            string id = "257";
            var superhero = TestData.GetSuperheroes().First();
            _mockSuperheroService.Setup(x => x.SearchSuperheroAsync(It.IsAny<int>())).Returns(Task.FromResult(superhero));
            superheroController = new SuperheroController(_mockSuperheroControllerLogger.Object, _mockSuperheroService.Object);

            //Act
            var response = superheroController.GetSuperheroById(id);

            //Assert
            Assert.IsNotNull(response);
            var result = response.Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccessful);
            Assert.IsTrue(string.IsNullOrWhiteSpace(result.ErrorMessage));
            var hero = result.Data;
            Assert.AreEqual(id, hero.Id);
        }

        /// <summary>
        /// Tests the method to GetSuperheroByName successfully
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        public void TestMethod_GetSuperheroByName_Success()
        {
            //Arrange
            string name = "Firebird";
            var superhero = TestData.GetSuperheroes();
            _mockSuperheroService.Setup(x => x.SearchSuperheroAsync(It.IsAny<string>())).Returns(Task.FromResult(superhero));
            superheroController = new SuperheroController(_mockSuperheroControllerLogger.Object, _mockSuperheroService.Object);

            //Act
            var response = superheroController.GetSuperheroByName(name);

            //Assert
            Assert.IsNotNull(response);
            var result = response.Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccessful);
            Assert.IsTrue(string.IsNullOrWhiteSpace(result.ErrorMessage));
            var hero = result.Data.FirstOrDefault(x => x.Name == name);
            Assert.IsNotNull(hero);
        }

        /// <summary>
        /// Tests the method to GetSuperheroByName with failure
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        public void TestMethod_GetSuperheroByName_Failure()
        {
            //Arrange
            string name = "Firebird";
            List<Superhero> superhero = null;
            _mockSuperheroService.Setup(x => x.SearchSuperheroAsync(It.IsAny<string>())).Returns(Task.FromResult(superhero));
            superheroController = new SuperheroController(_mockSuperheroControllerLogger.Object, null);

            //Act
            var response = superheroController.GetSuperheroByName(name);

            //Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Exception != null);
        }

        #endregion
    }
}
