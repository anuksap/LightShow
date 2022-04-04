using System.Reflection;

namespace LightShow.Services
{
    public static class FileOperations
    {
        public static void WriteFile(List<string> outputLines, string outputFileName)
        {
            try
            {
                var outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);
                File.WriteAllLines(outputFilePath, outputLines);
            }
            catch
            {
                throw new Exception("File Write operation failed.");
            }

        }

        public static string[] ReadFile(string fileName)
        {
            try
            {
                var currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
                if (currentDirectory != null)
                {
                    string filePath = Path.Combine(currentDirectory, "input", fileName);

                    if (File.Exists(filePath))
                    {
                        return File.ReadAllLines(filePath);
                    }
                    else
                    {
                        Console.WriteLine("File does not exist.");
                    }
                }
                return null;
            }
            catch
            {
                throw new Exception("File Read operation failed.");
            }
        }
    }
}
