namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            var sb = new StringBuilder();
            var dictionary = new Dictionary<string, List<(string name, long size)>>();
            foreach (var file in new DirectoryInfo(inputFolderPath).GetFiles())
            {
                var fileName = file.Name.Split('.');
                if (!dictionary.ContainsKey($".{fileName[1]}"))
                {
                    dictionary.Add($".{fileName[1]}", new List<(string name, long size)>());
                }

                dictionary[$".{fileName[1]}"].Add((file.Name, file.Length));
            }

            foreach (var key in dictionary.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key).Select(x => x.Key))
            {
                sb.AppendLine(key);
                foreach (var value in dictionary[key].OrderBy(x => x.size))
                {
                    var sizeKb = value.size / 1024.0;
                    sb.AppendLine($"--{value.name} - {sizeKb}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            var desktopPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{reportFileName}";
            File.WriteAllText(desktopPath, textContent);
        }
    }
}
