using CursoUnitTesting.API.Services;
using System;
using Xunit;

namespace CursoUnitTesting.API.UnitTests.Services
{
    public class MathOperationTests
    {
        //private readonly MathOperationService _MathOperationService;

        //public MathOperationTests()
        //{
        //   _primeService =  new MathOperationService();
        //}

        [Fact]
        public void Task_Add_TwoNumber()
        {
            // Arrange  
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 6;

            // Act  
            var sum = MathOperationService.Add(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, sum, 1);
        }

        [Fact]
        public void Task_Subtract_TwoNumber()
        {
            // Arrange  
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = -0.2;

            // Act  
            var sub = MathOperationService.Subtract(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, sub, 1);
        }

        [Fact]
        public void Task_Multiply_TwoNumber()
        {
            // Arrange  
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 8.99;

            // Act  
            var mult = MathOperationService.Multiply(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, mult, 2);
        }

        [Fact]
        public void Task_Divide_TwoNumber()
        {
            // Arrange  
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 0.94; //Rounded value  

            // Act  
            var div = MathOperationService.Divide(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, div, 2);
        }


        #region Primes
        [Fact]
        public void IsPrime_GivenValueLessThan2_ReturnFalse()
        {
            //Arrange
            int inputValue = 1;
            bool expectedResult = false;
            //Act
            var result = MathOperationService.IsPrime(inputValue);
            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void IsPrime_GivenNonPrimesValue_ReturnFalse()
        {
            //Arrange
            int inputValue = 4;
            bool expectedResult = false;
            //Act
            var result = MathOperationService.IsPrime(inputValue);
            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void IsPrime_GivenPrimesValue_ReturnTrue()
        {
            //Arrange
            int inputValue = 3;
            bool expectedResult = true;
            //Act
            var result = MathOperationService.IsPrime(inputValue);
            //Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

    }
}
