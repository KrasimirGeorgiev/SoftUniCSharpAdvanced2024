using System.Linq;

var songs = Console.ReadLine()
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

var songQueue = new Queue<string>();
foreach (var song in songs)
{
    songQueue.Enqueue(song);
}

while (songQueue.Any())
{
    var command = Console.ReadLine();
    if (command == "Play")
    {
        songQueue.Dequeue();
    }
    else if (command.StartsWith("Add"))
    {
        var songName = command.Substring(4);
        if (songQueue.Contains(songName))
        {
            Console.WriteLine($"{songName} is already contained!");
        }
        else
        {
            songQueue.Enqueue(songName);
        }
    }
    else if (command == "Show")
    {
        Console.WriteLine(string.Join(", ", songQueue));
    }
}

Console.WriteLine("No more songs!");
