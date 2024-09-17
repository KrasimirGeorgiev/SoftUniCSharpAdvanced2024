//// 01. Reverse Strings
//var inputStr = new Stack<char>(Console.ReadLine());
//Console.WriteLine(string.Join("", inputStr));


//// 02. Stack Sum
//var stack =  new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
//var command = Console.ReadLine().ToLower();

//while (command != "end")
//{
//    var commands = command.Split();
//    if (commands[0] == "add")
//    {
//        stack.Push(int.Parse(commands[1]));
//        stack.Push(int.Parse(commands[2]));
//    }
//    else if (int.Parse(commands[1]) <= stack.Count())
//    {
//        var deleteCounter = int.Parse(commands[1]);
//        while (deleteCounter > 0)
//        {
//            stack.Pop();
//            deleteCounter--;
//        }
//    }

//    command = Console.ReadLine().ToLower();
//}

//Console.WriteLine($"Sum: {stack.Sum()}");

//// 03. Simple Calculator
//var inputExpression = new Queue<string>(Console.ReadLine().Split());
//var currentNumber = inputExpression.Any() ? int.Parse(inputExpression.Dequeue()) : 0;
//while (inputExpression.Any())
//{
//    var operation = inputExpression.Dequeue();
//    var secondNumber = int.Parse(inputExpression.Dequeue());
//    if (operation == "+")
//        currentNumber += secondNumber;
//    else
//        currentNumber -= secondNumber;
//}

//Console.WriteLine(currentNumber);

//// 04. Matching Brackets
//var inputExpression = Console.ReadLine();
//var defaultIndex = 0;
//PrintOutSubExpresstions2(inputExpression, ref defaultIndex);

//// solution type 1 (where nothing is returned)
//static void PrintOutSubExpresstions1(string input, ref int index, bool isRoot = true)
//{
//    var openBracket = '(';
//    var closeBracket = ')';
//    var isExpression = !isRoot;
//    int expressionStartingIndex = index;
//    for (int i = index; i < input.Length; i++)
//    {
//        var currentSymbol = input[i];
//        if (currentSymbol == openBracket) 
//        {
//            i++;
//            PrintOutSubExpresstions1(input, ref i, false);
//        }
//        else if(isExpression && currentSymbol == closeBracket)
//        {
//            var subExpression = input.Substring(expressionStartingIndex - 1, (i + 2) - expressionStartingIndex);
//            Console.WriteLine(subExpression);
//            index = i;
//            return;
//        }
//    }

//}

//// solution type 2 (where the sub calls are returning the subExpression)
//static string PrintOutSubExpresstions2(string input, ref int index, bool isRoot = true)
//{
//    var openBracket = '(';
//    var closeBracket = ')';
//    var isExpression = !isRoot;
//    int expressionStartingIndex = index;
//    var result = "(";
//    for (int i = index; i < input.Length; i++)
//    {
//        var currentSymbol = input[i];
//        if (currentSymbol == openBracket)
//        {
//            i++;
//            result += PrintOutSubExpresstions2(input, ref i, false);
//        }
//        else if (isExpression)
//        {
//            result += input[i];
//            if (currentSymbol == closeBracket)
//            {
//                Console.WriteLine(result);
//                index = i;
//                return result;
//            }
//        }
//    }

//    return result;
//}

//// solution type 3 (where we use stacks and queues)
//var openingBracketsIndex = new Stack<int>();
//var openBracket = '(';
//var closeBracket = ')';

//for (int i = 0; i < inputExpression.Length; i++) {
//    var currentSymbol = inputExpression[i];
//    if (currentSymbol == openBracket)
//    {
//        openingBracketsIndex.Push(i);
//    } 
//    else if (currentSymbol == closeBracket)
//    {
//        var expressionStartIndex = openingBracketsIndex.Pop();
//        var subExpression = inputExpression.Substring(expressionStartIndex, (i + 1) - expressionStartIndex);
//        Console.WriteLine(subExpression);
//    }
//}

//// 05. Print Even Numbers
// solution 1
//var inputEvenNumbers = Console.ReadLine().Split().Where(x => int.Parse(x) % 2 == 0);
//Console.WriteLine(string.Join(", ", inputEvenNumbers));


//// solution 2
//var inputNumbers = Console.ReadLine().Split().Select(int.Parse);
//var queue = new Queue<int>();

//foreach (var number in inputNumbers)
//{
//	if (number % 2 == 0)
//	{
//        queue.Enqueue(number);
//    }
//}

////Console.WriteLine(string.Join(", ", queue));


//// 06. Supermarket
//var command = Console.ReadLine();
//var customers = new Queue<string>();
//while(command.ToLower() != "end")
//{
//	if (command.ToLower() == "paid")
//	{
//		while (customers.Any())
//		{
//            Console.WriteLine(customers.Dequeue());
//        }
//	}
//	else
//	{
//		customers.Enqueue(command);
//	}

//    command = Console.ReadLine();
//}

//Console.WriteLine($"{customers.Count()} people remaining.");


//// 07. Hot Potato
//var children = new LinkedList<string>(Console.ReadLine().Split());
//var step = int.Parse(Console.ReadLine()); 
//var counter = step;
//var node = children.First;
//var nextNode = node.Next;
//while (children.Count > 1)
//{
//    counter--;
//    if (counter == 0)
//    {
//        Console.WriteLine($"Removed {node.Value}");
//        children.Remove(node);

//        counter = step;
//    }

//    if (nextNode is null)
//    {
//        nextNode = children.First;
//    }

//    node = nextNode;
//    nextNode = nextNode.Next;
//}

//Console.WriteLine($"Last is {children.Last()}");

// 08. Traffic Jam
