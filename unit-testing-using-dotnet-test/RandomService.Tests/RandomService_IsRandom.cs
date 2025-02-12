using Xunit;
using Random.Services;

namespace Random.UnitTests.Services
{
    public class PrimeService_IsPrimeShould
    {
        [Fact]
        public void IsRandom_WithinEasy_ReturnFalse()
        {
            var RandomService = new RandomService();
            bool result = RandomService.IsEasyRandom(11);

            Assert.False(result, "11 should not be within easy random.");
        }

        [Fact]
        public void IsRandom_Within_ReturnFalse()
        {
            var RandomService = new RandomService();
            bool result = RandomService.IsEasyRandom(10);

            Assert.true(result, "10 should be within easy random.");
        }

        [Fact]
        public void IsRandom_Within_ReturnFalse()
        {
            var RandomService = new RandomService();
            bool result = RandomService.IsEasyRandom(11);

            Assert.False(result, "11 should not be within easy random.");
        }
    }
}