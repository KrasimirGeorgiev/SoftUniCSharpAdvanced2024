namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var line = reader.ReadLine();
            var count = 0;
            var sb = new StringBuilder();
            while (line != null)
            {
                if (count % 2 == 0)
                {
                    line = Regex.Replace(line, @"[-',.!?]", "@");
                    sb.AppendLine(string.Join(" ", line.Split(' ').Reverse()));
                }

                count++;
                line = reader.ReadLine();
            }

            return sb.ToString();
        }
    }
}
