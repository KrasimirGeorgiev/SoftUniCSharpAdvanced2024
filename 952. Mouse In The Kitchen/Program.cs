namespace _952._Mouse_In_The_Kitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nM = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var n = nM[0];
            var m = nM[1];
            var row = -1;
            var col = -1;
            var matrix = new char[n, m];
            var cheeseAmount = 0;
            for (var i = 0; i < n; i++) 
            {
                var input = Console.ReadLine();
                for (var j = 0; j < m; j++) 
                {
                    var currentSymbol = input[j];
                    matrix[i, j] = currentSymbol;
                    if (currentSymbol == 'M')
                    {
                        row = i;
                        col = j; 
                    }
                    else if(currentSymbol == 'C')
                    {
                        cheeseAmount++;
                    }
                }
            }

            var command = Console.ReadLine();
            if (command == "danger" && cheeseAmount > 0)
            {
                Console.WriteLine("Mouse will come back later!");
            }

            while (command != "danger") 
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
                    Console.WriteLine("No more cheese for tonight!");
                    break;
                }
                else
                {
                    var currentSymbol = matrix[cRow, cCol];
                    if (currentSymbol == '@')
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    matrix[row, col] = '*';
                    matrix[cRow, cCol] = 'M';
                    row = cRow;
                    col = cCol;

                    if (currentSymbol == 'C')
                    {
                        cheeseAmount--;
                        if (cheeseAmount == 0)
                        {
                            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                            break;
                        }
                    } 
                    else if (currentSymbol == 'T')
                    {
                        Console.WriteLine("Mouse is trapped!");
                        break;
                    }
                }

                command = Console.ReadLine();
                if (command == "danger" && cheeseAmount > 0)
                {
                    Console.WriteLine("Mouse will come back later!");
                }
            }

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
