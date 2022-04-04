using LightShow.Services;
using Xunit;

namespace LightShowTests
{
    public class LightShowBrightnessCountTest
    {
        [Fact]
        public void TestBrightness()
        {
            LightOperations lights = new(1000, 1000);
            string line = "turn on 0,0 through 0,0";
            var operationalDetails = OperationDetails.GetOperationDetails(line,true);
            if (operationalDetails != null)
            {
                var result = lights.OperateLights(operationalDetails);
                Assert.Equal(1, result);
            }
        }

        [Fact]
        public void TestBrightnessForMultiple()
        {
            LightOperations lights = new(1000, 1000);
            string line = "turn on 0,0 through 999,999";
            var operationalDetails = OperationDetails.GetOperationDetails(line,true);
            _ = lights.OperateLights(operationalDetails);

            line = "turn off 499,499 through 500,500";
            operationalDetails = OperationDetails.GetOperationDetails(line,true);
            _ = lights.OperateLights(operationalDetails);

            line = "toggle 0,499 through 999,500";
            operationalDetails = OperationDetails.GetOperationDetails(line,true);
            int result = lights.OperateLights(operationalDetails);
            Assert.Equal(1003996, result);
        }
    }
}
