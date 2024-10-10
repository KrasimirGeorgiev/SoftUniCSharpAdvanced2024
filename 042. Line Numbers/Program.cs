namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            var sr = new StreamReader(inputFilePath);
            var line = sr.ReadLine();
            var count = 1;
            var resultList = new List<string>();
            while (line != null)
            {
                var punctuations = 0;
                var letters = 0;
                foreach (var symbol in line)
                {
                    if (char.IsLetter(symbol))
                    {
                        letters++;
                    }
                    else if (symbol != ' ')
                    {
                        punctuations++;
                    }
                }

                resultList.Add($"Line {count}: {line} ({letters})({punctuations})");

                count++;
                line = sr.ReadLine();
            }

            using (var streamWriter = new StreamWriter(outputFilePath))
            {
                foreach (var str in resultList)
                {
                    streamWriter.WriteLine(str);
                }
            }
        }
    }
}
