
using LightShow.Constants;
using LightShow.Data;
using System;

namespace LightShow.Services
{
    public class LightOperations
    {   
        LightStatus[,] lightsArray = new LightStatus[0, 0];

        public LightOperations(int rowCount, int columnCount)
        {
            InitializeLightsArray(rowCount, columnCount);
        }

        public int InitializeLightsArray(int rowCount, int columnCount)
        {
            lightsArray = new LightStatus[rowCount, columnCount];

            for (int rowIndex = 0; rowIndex != lightsArray.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex != lightsArray.GetLength(1); colIndex++)
                {
                    lightsArray[rowIndex, colIndex] = new LightStatus(false, 0); ;
                }
            }

            return GetLightOnCount();
        }

        public int OperateLights(OperationDetails details)
        {
            var existingLightsRowCount = lightsArray.GetLength(0); // Row Count
            if (details.EndRow > existingLightsRowCount)
            {
                throw new Exception(LightShowErrorMessage.InvalidRowCountMessage);
            }
            var existingLightsColCount = lightsArray.GetLength(1);  // Column Count
            if (details.EndColumn > existingLightsColCount)
            {
                throw new Exception(LightShowErrorMessage.InvalidColumnCountMessage);
            }
            if (details.Operation != null)
            {
                for (int rowIndex = details.StartRow; rowIndex <= details.EndRow; rowIndex++)
                {
                    for (int colIndex = details.StartColumn; colIndex <= details.EndColumn; colIndex++)
                    {
                        var lightStatus = GetLightStatus(details.Upgraded, details.Operation, rowIndex, colIndex);
                        lightsArray[rowIndex, colIndex] = lightStatus;
                    }
                }
            }
            return GetLightOnCount(details.Upgraded);
        }

        LightStatus GetLightStatus(bool upgraded, string operation, int rowIndex, int colIndex)
        {
            LightStatus lightStatus = lightsArray[rowIndex, colIndex];
            if (upgraded)
            {
                // NOTE - We sould be using Open closed Principle Here instead of Switch case.
                switch (operation)
                {
                    case "turn on":
                        {
                            lightStatus.TurnedOn = true;
                            lightStatus.BrightnessLevel += 1;
                        }
                        break;
                    case "turn off":
                        {
                            if (lightStatus.BrightnessLevel != 0)
                            {
                                lightStatus.BrightnessLevel -= 1;
                            }
                        }
                        break;
                    case "toggle":
                        {
                            var value = lightsArray[rowIndex, colIndex];
                            lightStatus.TurnedOn = !value.TurnedOn;
                            lightStatus.BrightnessLevel += 2;
                        }
                        break;
                }
            }
            else
            {
                switch (operation)
                {
                    case "turn on":
                        lightStatus.TurnedOn = true;
                        break;
                    case "turn off":
                        lightStatus.TurnedOn = false;
                        break;
                    case "toggle":
                        {
                            var value = lightsArray[rowIndex, colIndex];
                            lightStatus.TurnedOn = !value.TurnedOn;
                        }
                        break;
                }
            }
            return lightStatus;
        }   

        private int GetLightOnCount(bool upgraded = false)
        {
            var onCount = 0;
            var brightnessCount = 0;
            for (int i = 0; i < lightsArray.GetLength(0); i++)
            {
                for (int j = 0; j < lightsArray.GetLength(1); j++)
                {
                    var lightStatus = lightsArray[i, j];
                    if (lightStatus.TurnedOn)
                        onCount++;
                    if (lightStatus.BrightnessLevel > 0)
                        brightnessCount += lightStatus.BrightnessLevel;

                }
            }
            return upgraded ? brightnessCount : onCount;
        }
    }
}
