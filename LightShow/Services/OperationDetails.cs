namespace LightShow.Services
{
    public class OperationDetails
    {
        public bool Upgraded { get; set; }
        public string Operation { get; set; }
        public int StartColumn { get; set; }
        public int EndColumn { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }

        private readonly static Dictionary<string, string> OperationsDictionary = new() {
            {"turn on", "turn on" },
            { "turn off", "turn off" },
            { "toggle", "toggle" }
        };

        public static OperationDetails GetOperationDetails(string inputString, bool upgraded = false)
        {
            try
            {
                var parseValues = inputString.Split(",");
                if (parseValues.Length != 3)
                    return null;

                var firstValue = parseValues[0];
                var secondValue = parseValues[1];
                var thirdValue = parseValues[2];

                var startColumn = firstValue.Split(' ').Last();
                var startRow = secondValue.Split(' ').First();
                var endColumn = secondValue.Split(' ').Last();
                var endRow = thirdValue.Split(' ').First();

                var startColumnLen = startColumn.Length;
                var operationStr = firstValue.Substring(0, firstValue.Length - startColumnLen).Trim();

                bool success = int.TryParse(startColumn, out int StartColumn);
                if (!success)
                {
                    throw new Exception("Start Column could not be parsed");
                }

                success = int.TryParse(startRow, out int StartRow);
                if (!success)
                {
                    throw new Exception("Start row could not be parsed");
                }

                success = int.TryParse(endColumn, out int EndColumn);
                if (!success)
                {
                    throw new Exception("End Column could not be parsed");
                }

                success = int.TryParse(endRow, out int EndRow);
                if (!success)
                {
                    throw new Exception("End row could not be parsed");
                }

                if (operationStr != null)
                {
                    bool operationExists = OperationsDictionary.Keys.ToList().Contains(operationStr);
                    if (!operationExists)
                        return null;

                }
                return (new OperationDetails
                {
                    Upgraded = upgraded,
                    Operation = operationStr,
                    StartColumn = int.Parse(startColumn),
                    EndColumn = int.Parse(endColumn),
                    StartRow = int.Parse(startRow),
                    EndRow = int.Parse(endRow)
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message} while parsing {inputString}.");
            }
            return null;
        }
    }
}
