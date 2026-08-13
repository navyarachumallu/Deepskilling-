using NUnit.Framework;
using CalcLibrary;
using System;

namespace CalcLibrary.Tests
{
    public class Tests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        [Test]
        public void AdditionTest()
        {
            double result = calculator.Addition(10, 20);
            Assert.AreEqual(30, result);
        }

        [Test]
        public void SubtractionTest()
        {
            double result = calculator.Subtraction(20, 10);
            Assert.AreEqual(10, result);
        }

        [Test]
        public void MultiplicationTest()
        {
            double result = calculator.Multiplication(5, 4);
            Assert.AreEqual(20, result);
        }

        [Test]
        public void DivisionTest()
        {
            double result = calculator.Division(20, 4);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void DivisionByZeroTest()
        {
            var ex = Assert.Throws<ArgumentException>(() => calculator.Division(10, 0));
            Assert.AreEqual("Second Parameter Can't be Zero", ex.Message);
        }

        [Test]
        public void AllClearTest()
        {
            calculator.Addition(10, 20);
            calculator.AllClear();

            Assert.AreEqual(0, calculator.GetResult);
        }
    }
}
