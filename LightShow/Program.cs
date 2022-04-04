using LightShow.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace TechnicalChallengeLightShow
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var rowCount = 1000;
                var colCount = 1000;
                var lightsOnCount = 0;
                LightOperations lights = new(Convert.ToInt32(rowCount), Convert.ToInt32(colCount));
                List<String> outputLines = new();

                string fileName = "coding_challenge_input2.txt";
                string outputFileName = "coding_challenge_input2_Brightness_Result.txt";

                var lines = FileOperations.ReadFile(fileName).ToList();
                if (lines != null)
                {
                    foreach (string line in lines)
                    {
                        var operationDetails = OperationDetails.GetOperationDetails(line, true);
                        if (operationDetails == null)
                        {
                            Console.WriteLine($"{line} Could not be parsed in the correct format.");
                            continue;
                        }

                        lightsOnCount = lights.OperateLights(operationDetails);

                        Console.WriteLine($"{line} On Count : {lightsOnCount}");
                        outputLines.Add($"{line} {lightsOnCount}");
                    }
                }

                Console.WriteLine($"Final Count : {lightsOnCount}");
                FileOperations.WriteFile(outputLines, outputFileName);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

       
    }
}


