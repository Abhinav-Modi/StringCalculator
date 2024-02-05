using StringCalculatorLib;
using Xunit;

namespace StringCalculatorLib.test
{
    public class UnitTest1
    {
        [Fact]
        public void GivenEmptyStringInput_WhenAddIsCalled_ThenResultShouldBeZero()
        {
            string input = "";
            int expectedResult = 0;

            var actualResult = Calculator.Add(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GivenSingleNumberStringInput_WhenAddIsCalled_ThenResultShouldBeNumber()
        {
            string input = "1";
            int expectedResult = 1;

            var actualResult = Calculator.Add(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GivenTwoNumbersSeparatedByDelimiter_WhenAddIsCalled_ThenResultShouldBeSumOfNumbers()
        {
            string input = "1,2";
            int expectedResult = 3;

            var actualResult = Calculator.Add(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GivenNegativeValueInStringInput_WhenAddIsCalled_ThenExceptionShouldBeThrown()
        {
            string input = "-1,2";

            Assert.Throws<ArgumentException>(() => Calculator.Add(input));
        }

        [Fact]
        public void GivenNumbersSeparatedByNewline_WhenAddIsCalled_ThenResultShouldBeSumOfNumbers()
        {
            string input = "1\n2,3";
            int expectedResult = 6;

            var actualResult = Calculator.Add(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GivenNumberAbove1000_WhenAddIsCalled_ThenResultShouldExcludeNumber()
        {
            string input = "2,1001";
            int expectedResult = 2;

            var actualResult = Calculator.Add(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GivenDifferentDelimiter_WhenAddIsCalled_ThenResultShouldBeSumOfNumbers()
        {
            string input = "//;\n1;2";
            int expectedResult = 3;

            var actualResult = Calculator.Add(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GivenAnyLengthOfDelimiter_WhenAddIsCalled_ThenResultShouldBeSumOfNumbers()
        {
            string input = "//[***]\n1***2***3";
            int expectedResult = 6;

            var actualResult = Calculator.Add(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GivenMultipleDelimiters_WhenAddIsCalled_ThenResultShouldBeSumOfNumbers()
        {
            string input = "//[*][%]\n1*2%3";
            int expectedResult = 6;

            var actualResult = Calculator.Add(input);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
