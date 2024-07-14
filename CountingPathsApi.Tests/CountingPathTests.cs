using CountingPathsApi.Services;

namespace CountingPathsApi.Tests
{
    [TestFixture]
    public class CountingPathTests
    {
        private PathCalculator _pathCalculator;

        [SetUp]
        public void Setup()
        {
            _pathCalculator = new PathCalculator();
        }

        [Test]
        public void GetAllPaths_Input2_2_Returns6Paths()
        {
            // Arrange
            int x = 2;
            int y = 2;
            var expectedPaths = new List<string> { "EENN", "ENEN", "ENNE", "NEEN", "NENE", "NNEE" };

            // Act
            var result = _pathCalculator.CalculatePaths(x, y);

            // Assert
            Assert.That(result.Count, Is.EqualTo(6));
            CollectionAssert.AreEquivalent(expectedPaths, result);
        }

        [Test]
        public void GetAllPaths_Input0_7_Returns1Path()
        {
            // Arrange
            int x = 0;
            int y = 7;
            var expectedPath = new List<string> { "NNNNNNN" };

            // Act
            var result = _pathCalculator.CalculatePaths(x, y);

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
            CollectionAssert.AreEquivalent(expectedPath, result);
        }

        [Test]
        public void GetAllPaths_Input0_0_Returns1Path()
        {
            // Arrange
            int x = 0;
            int y = 0;
            var expectedPath = new List<string> { "" };

            // Act
            var result = _pathCalculator.CalculatePaths(x, y);

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
            CollectionAssert.AreEquivalent(expectedPath, result);
        }

        [Test]
        public void GetAllPaths_Input3_3_ReturnsPaths_ExcludingExactly3ConsecutiveSteps()
        {
            // Arrange
            int x = 3;
            int y = 3;

            // Act
            var result = _pathCalculator.CalculatePaths(x, y);

            // Assert
            Assert.IsTrue(result.All(path => !path.Contains("EEEN") && !path.Contains("NNNE")));
        }

    }
}