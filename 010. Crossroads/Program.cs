var greenLightInSeconds = int.Parse(Console.ReadLine());
var windowLeftInSeconds = int.Parse(Console.ReadLine());
var command = Console.ReadLine();

var queueOfCars = new Queue<string>();
var hasCrashOccured = false;
char theSymbolOfTheHitCar = default;
var numberOfCarsSafelyPassed = 0;
while (command != "END" && !hasCrashOccured)
{
    if (command == "green")
    {
        var greenLight = greenLightInSeconds;
        var window = windowLeftInSeconds;
        while (greenLight > 0 && queueOfCars.Any())
        {
            var currentCar = queueOfCars.Peek();
            var secondsLeftInGreenLight = greenLight - currentCar.Length;
            if (secondsLeftInGreenLight > 0)
            {
                greenLight -= currentCar.Length;
            }
            else
            {
                if (Math.Abs(secondsLeftInGreenLight) > window)
                {
                    theSymbolOfTheHitCar = currentCar[greenLight + window];
                    hasCrashOccured = true;
                    break;
                }

                greenLight = 0;
            }

            queueOfCars.Dequeue();
            numberOfCarsSafelyPassed++;
        }
    }
    else
    {
        queueOfCars.Enqueue(command);
    }

    command = Console.ReadLine();
}

if (hasCrashOccured)
{
    Console.WriteLine("A crash happened!");
    Console.WriteLine($"{queueOfCars.Peek()} was hit at {theSymbolOfTheHitCar}.");
}
else
{
    Console.WriteLine("Everyone is safe.");
    Console.WriteLine($"{numberOfCarsSafelyPassed} total cars passed the crossroads.");
}