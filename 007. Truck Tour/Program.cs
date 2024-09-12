var nOfPetrolPumps = int.Parse(Console.ReadLine());

var pumps = new Queue<Tuple<int, int>>();
for (int i = 0; i < nOfPetrolPumps; i++)
{
    var currentLine = Console.ReadLine().Split();
    pumps.Enqueue(new Tuple<int, int>(int.Parse(currentLine[0]), int.Parse(currentLine[1])));
}

var resultIndex = 0;
while (resultIndex < nOfPetrolPumps)
{
    var currentPump = pumps.Dequeue();
    var currentFuel = currentPump.Item1;
    var distanceToTheNextPump = currentPump.Item2;
    var isResult = true;
    foreach (var pump in pumps)
    {
        
        if (currentFuel < distanceToTheNextPump)
        {
            isResult = false;
            break;
        }
        else
        {
            currentFuel -= distanceToTheNextPump;
            currentFuel += pump.Item1;
            distanceToTheNextPump = pump.Item2;
        }
    }

    if (isResult)
        break;

    resultIndex++;
}

Console.WriteLine(resultIndex);