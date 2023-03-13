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

        [Fact]
        private void VerifyNoRoll_FrameIsOne()
        {
            // Arrange
            BowlingGameCal unitToTest = new BowlingGameCal();

            // Act
            int actual = unitToTest.CurrentFrame;

            // Assert
            Assert.Equal(1, actual);
        }

        [Fact]
        private void VerifyOneRoll_FrameIsOne()
        {
            // Arrange
            BowlingGameCal unitToTest = new BowlingGameCal();

            // Act
            int result = unitToTest.Roll(2);
            int actual = unitToTest.CurrentFrame;

            // Assert
            Assert.Equal(1, actual);
        }

        [Fact]
        private void VerifyTwoRoll_FrameIsTwo()
        {
            // Arrange
            BowlingGameCal unitToTest = new BowlingGameCal();

            // Act
            int result1 = unitToTest.Roll(2);
            int result2 = unitToTest.Roll(2);
            int actual = unitToTest.CurrentFrame;

            // Assert
            Assert.Equal(2, actual);
        }

        [Fact]
        private void VerifyThreeRoll_FrameIsTwo()
        {
            // Arrange
            BowlingGameCal unitToTest = new BowlingGameCal();

            // Act
            int result1 = unitToTest.Roll(2);
            int result2 = unitToTest.Roll(2);
            int result3 = unitToTest.Roll(2);
            int actual = unitToTest.CurrentFrame;

            // Assert
            Assert.Equal(2, actual);
        }

        [Fact]
        private void VerifyFourRoll_FrameIsThree()
        {
            // Arrange
            BowlingGameCal unitToTest = new BowlingGameCal();

            // Act
            int result1 = unitToTest.Roll(2);
            int result2 = unitToTest.Roll(2);
            int result3 = unitToTest.Roll(2);
            int result4 = unitToTest.Roll(2);
            int actual = unitToTest.CurrentFrame;

            // Assert
            Assert.Equal(3, actual);
        }

        [Fact]
        private void VerifyThreeRoll_LastStrike_FrameIsThree()
        {
            // Arrange
            BowlingGameCal unitToTest = new BowlingGameCal();

            // Act
            int result1 = unitToTest.Roll(2);
            int result2 = unitToTest.Roll(2);
            int result3 = unitToTest.Roll(10);
            int actual = unitToTest.CurrentFrame;

            // Assert
            Assert.Equal(3, actual);
        }
    }
}