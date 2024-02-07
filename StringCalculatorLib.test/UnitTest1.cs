using StringCalculatorLib;
using Xunit;

namespace StringCalculatorLib.test
{
    public class ClaculatorTests
    {
        [Theory]
        [CsvData(@"C:\Users\x6abmodi\Documents\CalculatorInputData.csv", true)]
        public void GivenNumbersFromCsvFile_WhenAddIsCalled_ThenResultShouldBeCorrect(string input, int expectedResult)
        {
            var actualResult = Calculator.Add(input);

            Assert.Equal(expectedResult, actualResult);
        }
        //[Theory]
        //[ClassData(typeof(CalculatorTestData))]
        //public void GivenNumbersSeparatedByDelimiter_WhenAddIsCalled_ThenResultShouldBeSumOfNumbers(string input, int expectedResult)
        //{
        //    var actualResult = Calculator.Add(input);

        //    Assert.Equal(expectedResult, actualResult);
        //}
        //[Theory]
        //[InlineData("1,2", 3)]
        //[InlineData("1\n2,3", 6)]
        //[InlineData("2,1001", 2)]
        //[InlineData("//;\n1;2", 3)]
        //[InlineData("//[***]\n1***2***3", 6)]
        //[InlineData("//[*][%]\n1*2%3", 6)]
        //public void GivenNumbersSeparatedByDelimiter_WhenAddIsCalled_ThenResultShouldBeSumOfNumbers(string input, int expectedResult)
        //{
        //    int actualResult = Calculator.Add(input);

        //    Assert.Equal(expectedResult, actualResult);
        //}
        //[Fact]
        //public void GivenEmptyStringInput_WhenAddIsCalled_ThenResultShouldBeZero()
        //{
        //    string input = "";
        //    int expectedResult = 0;

        //    var actualResult = Calculator.Add(input);

        //    Assert.Equal(expectedResult, actualResult);
        //}

        //[Fact]
        //public void GivenSingleNumberStringInput_WhenAddIsCalled_ThenResultShouldBeNumber()
        //{
        //    string input = "1";
        //    int expectedResult = 1;

        //    var actualResult = Calculator.Add(input);

        //    Assert.Equal(expectedResult, actualResult);
        //}

        //[Fact]
        //public void GivenTwoNumbersSeparatedByDelimiter_WhenAddIsCalled_ThenResultShouldBeSumOfNumbers()
        //{
        //    string input = "1,2";
        //    int expectedResult = 3;

        //    var actualResult = Calculator.Add(input);

        //    Assert.Equal(expectedResult, actualResult);
        //}

        //[Fact]
        //public void GivenNegativeValueInStringInput_WhenAddIsCalled_ThenExceptionShouldBeThrown()
        //{
        //    string input = "-1,2";

        //    Assert.Throws<ArgumentException>(() => Calculator.Add(input));
        //}

        //[Fact]
        //public void GivenNumbersSeparatedByNewline_WhenAddIsCalled_ThenResultShouldBeSumOfNumbers()
        //{
        //    string input = "1\n2,3";
        //    int expectedResult = 6;

        //    var actualResult = Calculator.Add(input);

        //    Assert.Equal(expectedResult, actualResult);
        //}

        //[Fact]
        //public void GivenNumberAbove1000_WhenAddIsCalled_ThenResultShouldExcludeNumber()
        //{
        //    string input = "2,1001";
        //    int expectedResult = 2;

        //    var actualResult = Calculator.Add(input);

        //    Assert.Equal(expectedResult, actualResult);
        //}

        //[Fact]
        //public void GivenDifferentDelimiter_WhenAddIsCalled_ThenResultShouldBeSumOfNumbers()
        //{
        //    string input = "//;\n1;2";
        //    int expectedResult = 3;

        //    var actualResult = Calculator.Add(input);

        //    Assert.Equal(expectedResult, actualResult);
        //}

        //[Fact]
        //public void GivenAnyLengthOfDelimiter_WhenAddIsCalled_ThenResultShouldBeSumOfNumbers()
        //{
        //    string input = "//[***]\n1***2***3";
        //    int expectedResult = 6;

        //    var actualResult = Calculator.Add(input);

        //    Assert.Equal(expectedResult, actualResult);
        //}

        //[Fact]
        //public void GivenMultipleDelimiters_WhenAddIsCalled_ThenResultShouldBeSumOfNumbers()
        //{
        //    string input = "//[*][%]\n1*2%3";
        //    int expectedResult = 6;

        //    var actualResult = Calculator.Add(input);

        //    Assert.Equal(expectedResult, actualResult);
        //}
    }
}
