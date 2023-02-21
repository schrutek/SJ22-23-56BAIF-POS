using Newtonsoft.Json.Linq;
using Spg.BowlingCalculator.Game;
using Xunit.Sdk;

namespace Spg.BowlingCalculator.GameTest
{
    public class BowlingGameCalcTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void NumberOf_PinsThrown_ExpectedSumIs_NumberOfPinsThown(int value)
        {
            // Arrange
            BowlingGameCal unitToTest = new BowlingGameCal();

            // Act
            int actual = unitToTest.Roll(value);

            // Assert
            Assert.Equal(value, actual);
        }

        [Fact()]
        public void Calculate_SumOfThronPins()
        {
            // Arrange
            BowlingGameCal unitToTest = new BowlingGameCal();

            // Act
            int actual1 = unitToTest.Roll(2);
            int actual2 = unitToTest.Roll(3);

            // Assert
            Assert.Equal(5, actual2);
        }

        [Fact()]
        public void ThrowBowlingGameException_IfTooManyPins()
        {
            // Arrange
            BowlingGameCal unitToTest = new BowlingGameCal();

            // Act, Assert
            Assert.Throws<BowlingGameException>(() => unitToTest.Roll(12));
        }

        [Fact()]
        public void ThrowBowlingGameException_IfTooFewPins()
        {
            // Arrange
            BowlingGameCal unitToTest = new BowlingGameCal();

            // Act, Assert
            Assert.Throws<BowlingGameException>(() => unitToTest.Roll(-1));
        }

        //private static void Throws<T>(Action testCode) where T: Exception
        //{
        //    try
        //    {
        //        testCode();
        //        // Mache das Ergebis rot
        //    }
        //    catch (T ex)
        //    {
        //        // Mache das Ergebis grün
        //    }
        //}
    }
}