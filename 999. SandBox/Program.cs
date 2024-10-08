using System.Runtime.InteropServices;

var coursesPass = new Dictionary<string, string>();
var input = Console.ReadLine();
while (input != "end of contests")
{
    var inputSpl = input.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();
    var course = inputSpl[0];
    var pass = inputSpl[1];
    if (!coursesPass.ContainsKey(input))
    {
        coursesPass.Add(course, pass);
    }

    input = Console.ReadLine();
}

input = Console.ReadLine();
var studendsCoursesPoints = new Dictionary<string, Dictionary<string, int>>();

while (input != "end of submissions")
{
    var inputSpl = input.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
    var course = inputSpl[0];
    var coursePass = inputSpl[1];
    var studentName = inputSpl[2];
    var points = inputSpl[3];
    if (coursesPass.TryGetValue(course, out var pass) && pass == coursePass)
    {
        if (!studendsCoursesPoints.ContainsKey(studentName))
        {
            studendsCoursesPoints.Add(studentName, new Dictionary<string, int>());
        }

        if (!studendsCoursesPoints[studentName].ContainsKey(course))
        {
            studendsCoursesPoints[studentName].Add(course, int.Parse(points));
        }
        else if (studendsCoursesPoints[studentName][course] < int.Parse(points))
        {
            studendsCoursesPoints[studentName][course] = int.Parse(points);
        }
    }
    input = Console.ReadLine();
}

var studentWithMaxPoints = studendsCoursesPoints.OrderByDescending(x => x.Value.Values.Sum()).Select(x => x.Key).First();
Console.WriteLine($"Best candidate is {studentWithMaxPoints} with total {studendsCoursesPoints[studentWithMaxPoints].Values.Sum()} points.");
Console.WriteLine("Ranking: ");
foreach (var student in studendsCoursesPoints.Keys.OrderBy(x => x))
{
    Console.WriteLine($"{student}");
    foreach (var course in studendsCoursesPoints[student].OrderByDescending(x => x.Value))
    {
        Console.WriteLine($"#  {course.Key} -> {course.Value}");
    }
}