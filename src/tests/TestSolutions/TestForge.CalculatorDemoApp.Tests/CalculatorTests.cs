using NUnit.Framework;

namespace TestForge.CalculatorDemoApp.Tests
{
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_GivenTwoNumbers_ShouldReturnTheirSum()
        {
            int x = 5;
            int y = 10;

            int result = _calculator.Add(x, y);

            Assert.That(result, Is.EqualTo(x + y));
        }

        [Test]
        public void Subtract_GivenTwoNumbers_ShouldReturnTheirDifference()
        {
            int x = 20;
            int y = 10;

            int result = _calculator.Subtract(x, y);

            Assert.That(result, Is.EqualTo(x - y));
        }

        [Test]
        public void Divide_GivenTwoNumbers_ShouldReturnTheirQuotient()
        {
            int x = 20;
            int y = 10;

            int result = _calculator.Divide(x, y);

            Assert.That(result, Is.EqualTo(x / y));
        }

        //[Test]
        //public void Multiply_GivenTwoNumbers_ShouldReturnTheirProduct()
        //{
        //    int x = 5;
        //    int y = 10;

        //    int result = _calculator.Multiply(x, y);

        //    Assert.That(result, Is.EqualTo(x * y));
        //}

        [Test]
        public void Divide_GivenZeroAsDenominator_ShouldThrowDivideByZeroException()
        {
            int x = 20;
            int y = 0;

            Assert.That(() => _calculator.Divide(x, y), Throws.TypeOf<DivideByZeroException>());
        }
    }
}