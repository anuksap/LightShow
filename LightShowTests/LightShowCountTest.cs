using LightShow.Constants;
using LightShow.Services;
using System;
using Xunit;

namespace LightShowTests
{
    public class LightShowCountTest
    {
        [Fact]
        public void TestInvalidOperation()
        {
            // Arrange
            LightOperations lights = new(100, 100);
            string line = "ADD 0,0 through 100,100";
            var operationalDetails = OperationDetails.GetOperationDetails(line);
            Assert.Null(operationalDetails);
        }

        [Fact]
        public void TestInValidRowCount()
        {
            // Arrange
            LightOperations lights = new(100, 100);
            string line = "turn on 0,0 through 101,999";
            var operationalDetails = OperationDetails.GetOperationDetails(line);

            // Act
            Action act = () => lights.OperateLights(operationalDetails);

            // Assert
            Exception ex = Assert.Throws<Exception>(act);
            Assert.Equal(LightShowErrorMessage.InvalidRowCountMessage, ex.Message);
        }

        [Fact]
        public void TestInValidColumnCount()
        {
            // Arrange
            LightOperations lights = new(100, 100);
            string line = "turn on 0,0 through 999,100";
            var operationalDetails = OperationDetails.GetOperationDetails(line);

            // Act
            Action act = () => lights.OperateLights(operationalDetails);

            // Assert
            Exception ex = Assert.Throws<Exception>(act);
            Assert.Equal(LightShowErrorMessage.InvalidColumnCountMessage, ex.Message);
        }

        [Fact]
        public void TestSwitchLightForSeries()
        {
            LightOperations lights = new(1000, 1000);
            string line = "turn on 0,0 through 999,999";
            var operationalDetails = OperationDetails.GetOperationDetails(line);
            _ = lights.OperateLights(operationalDetails);

            line = "turn off 499,499 through 500,500";
            operationalDetails = OperationDetails.GetOperationDetails(line);
            _ = lights.OperateLights(operationalDetails);

            line = "toggle 0,499 through 999,500";
            operationalDetails = OperationDetails.GetOperationDetails(line);
            int result = lights.OperateLights(operationalDetails);

            Assert.Equal(998004, result);
        }


        [Fact]
        public void TestSwitchLightForFileInput()
        {
            LightOperations lights = new(1000, 1000);
            string fileName = "coding_challenge_input2.txt";
            string[] lines = FileOperations.ReadFile(fileName);
            int lightsOnCount = 0;

            foreach (string line in lines)
            {
                lightsOnCount = lights.OperateLights(OperationDetails.GetOperationDetails(line));
            }

            Assert.Equal(385705, lightsOnCount);
        }
    }
}