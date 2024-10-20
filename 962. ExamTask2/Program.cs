using System.Diagnostics.Metrics;

namespace _962._ExamTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nM = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var n = nM[0];
            var m = nM[1];
            var startR = -1;
            var startC = -1;
            var row = -1;
            var col = -1;
            var count = 16;
            var matrix = new char[n, m];
            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                for (var j = 0; j < m; j++)
                {
                    var currentSymbol = input[j];
                    matrix[i, j] = currentSymbol;
                    if (currentSymbol == 'C')
                    {
                        row = i;
                        col = j;
                        startR = i;
                        startC = j;
                        matrix[i, j] = '*';
                    }
                }
            }

            var command = Console.ReadLine();
            while (true)
            {
                var cRow = row;
                var cCol = col;
                if (command == "up")
                    cRow--;
                else if (command == "down")
                    cRow++;
                else if (command == "left")
                    cCol--;
                else if (command == "right")
                    cCol++;

                if (cRow < 0 || n <= cRow || cCol < 0 || m <= cCol)
                {

                }
                else
                {
                    row = cRow;
                    col = cCol;
                    var currentSymbol = matrix[row, col];
                    if (currentSymbol == 'T')
                    {
                        matrix[row, col] = '*';
                        Console.WriteLine("Terrorists win!");
                        break;
                    }

                    if (command == "defuse" )
                    {
                        if (currentSymbol == 'B')
                        {
                            if (count - 4 >= 0)
                            {
                                // defused
                                Console.WriteLine("Counter-terrorist wins!");
                                Console.WriteLine($"Bomb has been defused: {count - 4} second/s remaining."); //
                                matrix[row, col] = 'D';
                                break;
                            }
                            else
                            {
                                //boom
                                Console.WriteLine("Terrorists win!");
                                Console.WriteLine("Bomb was not defused successfully!");
                                Console.WriteLine($"Time needed: {Math.Abs(count - 4)} second/s."); 
                                matrix[row, col] = 'X';
                                break;
                            }
                        }
                        else
                        {
                            count--;
                        }
                    }
                }

                count--;
                if (count <= 0)
                {
                    Console.WriteLine("Terrorists win!");
                    Console.WriteLine("Bomb was not defused successfully!");
                    Console.WriteLine("Time needed: 0 second/s."); //
                    break;
                }

                command = Console.ReadLine();
            }

            matrix[startR, startC] = 'C';
            
            PrintMatrix();
            void PrintMatrix()
            {

                for (int i = 0; i < n; i++)
                {
                    var line = "";
                    for (int j = 0; j < m; j++)
                    {
                        var currentCel = matrix[i, j];

                        line += currentCel;
                        //if (j != n - 1)
                        //{
                        //    line += ' ';
                        //}
                    }

                    Console.WriteLine(line);
                }
            }
        }
    }
}
