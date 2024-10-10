namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream streamRead = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream streamWrite = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
            {
                int bytesRead = 0;

                byte[] buffer = new byte[4096];

                while ((bytesRead = streamRead.Read(buffer, 0, buffer.Length)) > 0)
                {
                    streamWrite.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}
