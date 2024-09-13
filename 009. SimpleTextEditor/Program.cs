
var numberOfCommands = int.Parse(Console.ReadLine());

var historyOfRecordAndDeleteOperations = new Stack<Tuple<OperationType, string>>();
var resultString = string.Empty;
for (int i = 0; i < numberOfCommands; i++)
{
    var currentCommand = Console.ReadLine().Split();
    switch (currentCommand[0])
    {
        case "1":
            resultString += currentCommand[1];
            historyOfRecordAndDeleteOperations.Push(new Tuple<OperationType, string>(OperationType.Add, currentCommand[1].Length.ToString()));
            break;
        case "2":
            var numberOfCharsToDelete = int.Parse(currentCommand[1]);
            historyOfRecordAndDeleteOperations.Push(new Tuple<OperationType, string>(OperationType.Delete, resultString[(resultString.Length - numberOfCharsToDelete)..]));
            resultString = resultString.Substring(0, resultString.Length - numberOfCharsToDelete);
            break;
        case "3":
            Console.WriteLine(resultString[int.Parse(currentCommand[1]) - 1]);
            break;
        case "4":
            resultString = UndoLastOperation(historyOfRecordAndDeleteOperations, resultString);
            break;
    }
}

static string UndoLastOperation(Stack<Tuple<OperationType, string>> operations, string resultString)
{
    if (operations.Any())
    {
        var lastOperation = operations.Pop();
        var opositeOperation = (OperationType)(((int)lastOperation.Item1 + 1) % 2);
        if (opositeOperation == OperationType.Add)
        {
            resultString += lastOperation.Item2;
        }
        else
        {
            resultString = resultString.Substring(0, resultString.Length - int.Parse(lastOperation.Item2));
        }
    }

    return resultString;
}

enum OperationType
{
    Add,
    Delete
}


