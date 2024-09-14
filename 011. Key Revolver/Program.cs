var amountPerBullet = int.Parse(Console.ReadLine());
var sizeOfGunBarrel = int.Parse(Console.ReadLine());
var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
var amountOfTheReward = int.Parse(Console.ReadLine());
var initialNumberOfBullets = bullets.Count();
var initialNumberOfLocks = locks.Count();

var currentAmountOfBullets = sizeOfGunBarrel;
while (bullets.Any() && locks.Any())
{
    if (currentAmountOfBullets == 0)
    {
        Console.WriteLine("Reloading!");
        currentAmountOfBullets = sizeOfGunBarrel;
    }

    var currentBullet = bullets.Pop();
    var currentLock = locks.Peek();
    if (currentBullet <= currentLock)
    {
        locks.Dequeue();
        Console.WriteLine("Bang!");
    }
    else
    {
        Console.WriteLine("Ping!");
    }

    currentAmountOfBullets--;
}

if (locks.Any())
{
    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count()}");
}
else
{
    if (currentAmountOfBullets == 0 && bullets.Any())
    {
        Console.WriteLine("Reloading!");
    }

    var amountEarned = amountOfTheReward - ((initialNumberOfBullets - bullets.Count) * amountPerBullet);
    Console.WriteLine($"{bullets.Count} bullets left. Earned ${amountEarned}");
}
