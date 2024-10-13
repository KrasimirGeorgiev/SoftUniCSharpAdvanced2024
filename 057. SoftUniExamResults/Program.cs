var input = Console.ReadLine();

var examsSubmissions = new Dictionary<string, int>();
var bannedStudents = new HashSet<string>();
var studentCourses = new Dictionary<string, Dictionary<string, List<int>>>();
while (input != "exam finished")
{
    var inputSpl = input.Split('-', StringSplitOptions.RemoveEmptyEntries).ToList();
    if (inputSpl.Count() == 3)
    {
        var student = inputSpl[0];
        var course = inputSpl[1];
        var points = int.Parse(inputSpl[2]);
        if (!bannedStudents.Contains(student))
        {
            if (!studentCourses.ContainsKey(student))
            {
                studentCourses.Add(student, new Dictionary<string, List<int>>());
                studentCourses[student].Add(course, new List<int>() { points });
            }
            else if (!studentCourses[student].ContainsKey(course))
            {
                studentCourses[student].Add(course, new List<int>() { points });
            }
            else
            {
                studentCourses[student][course].Add(points);
            }

            if (!examsSubmissions.ContainsKey(course))
            {
                examsSubmissions.Add(course, 1);
            }
            else
            {
                examsSubmissions[course] += 1;
            }
        }
    } 
    else if (inputSpl.Count() == 2 && inputSpl[1] == "banned")
    {
        bannedStudents.Add(inputSpl[0]);
    }

    input = Console.ReadLine();
}



Console.WriteLine("Results:");
foreach (var student in studentCourses.Keys.Where(x => !bannedStudents.Contains(x)).OrderByDescending(k => studentCourses[k].Values.Select(x => x.Max()).Sum()).ThenBy(x => x))
{
    var points = studentCourses[student].Values.Select(x => x.Max()).Sum();
    Console.WriteLine($"{student} | {points}");
}

Console.WriteLine("Submissions:");
foreach (var exam in examsSubmissions.Keys.OrderByDescending(e => examsSubmissions[e]))
{
    Console.WriteLine($"{exam} - {examsSubmissions[exam]}");
}
