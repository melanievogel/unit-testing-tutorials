using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace xUnitTutorial
{
    public class xUnitCalculatorTests
    {
        private readonly Calculator _sut;

        public xUnitCalculatorTests()
        {
            _sut = new Calculator();
        }

        // Simple Test Case
        [Fact]
        public void AddTwoNumbersShouldEqualTheirSum()
        {
            _sut.Add(5);
            _sut.Add(8);
            Assert.Equal(13, _sut.Value);
        }
        
        // Skip Test Case
        [Fact(Skip = "This test is broken.")]
        public void AddTwoNumbersShouldEqualTheirSumBroken()
        {
            _sut.Add(5);
            _sut.Add(8);
            Assert.Equal(13, _sut.Value);
        }

        // Parametrized tests - codebase do not change, only parameters
        [Theory]
        [InlineData(13, 5, 8)]
        [InlineData(0, -7, 7)]
        [InlineData(-11, -3, -8)]
        [InlineData(0, 0, 0)]
        public void AddTwoNumbersShouldEqualTheirSumParametrized( decimal expected, decimal firstToAdd, decimal secondToAdd)
        {
            _sut.Add(firstToAdd);
            _sut.Add(secondToAdd);
            Assert.Equal(expected, _sut.Value);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void AddManyNumbersShouldEqualTheirEqualTheory(decimal expected, params decimal[] valuesToAdd)
        {
            foreach (var value in valuesToAdd)
            {
                _sut.Add(value);
            }

            Assert.Equal(expected, _sut.Value);
        }

        // If you don't want to have multiple InlineData(), generate some test data
        // yield: 
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]{ 15, new decimal[] {10, 5} };
            yield return new object[]{ 15, new decimal[] {5, 5, 5} };
            yield return new object[]{ -20, new decimal[] {-10, -30, 20} };
        }


        [Theory]
        [ClassData(typeof(DivisionTestData))]
        public void DivideManyNumbersShouldEqualTheirTheory(decimal expected, params decimal[] valuesToDivide)
        {

            foreach (var value in valuesToDivide)
            {
                _sut.Divide(value);
            }

            Assert.Equal(expected, _sut.Value);
        }
    }

    // If you don't want method as TestData(); but have lots of logic and data to generate --> create public class
    public class DivisionTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 30, new decimal[] { 60, 2 } };
            yield return new object[] { 0, new decimal[] { 0, 1 } };
            yield return new object[] { 1, new decimal[] { 50, 50 } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    // XUnit tests run all in parallel - using each time an own instance of the object created in the constructor
    // If you don't want to run them parallel create new class - see class "CollectionBehaviorOverride"
}
