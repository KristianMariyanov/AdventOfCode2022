var monkeys = new Dictionary<int, List<long>>();
var monkeyCommands = new Dictionary<int, List<string>>();
var moneyInspectCounter = new Dictionary<int, long>();

Part2();

void Part1()
{
    while (true)
    {
        var row = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(row))
        {
            break;
        }

        var monkey = int.Parse(row.Split(" ")[1].TrimEnd(':'));

        if (!monkeys.ContainsKey(monkey))
        {
            monkeys.Add(monkey, new List<long>());
        }
        
        monkeyCommands[monkey] = new List<string>();

        var worryLevelRow = Console.ReadLine();
        monkeyCommands[monkey].Add(worryLevelRow);
        var worryLevels = worryLevelRow.Split(":")[1]
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var moneyItemList = monkeys[monkey];
        for (int j = 0; j < worryLevels.Count; j++)
        {
            var worryLevel = worryLevels[j];
            var alreadyHasThisItem = moneyItemList.Count > j;
            if (alreadyHasThisItem)
            {
                moneyItemList.Insert(0, long.Parse(worryLevel));
            }
            else
            {
                moneyItemList.Add(long.Parse(worryLevel));
            }
        }

        var operationRow = Console.ReadLine();
        monkeyCommands[monkey].Add(operationRow);
        var expressionParts = operationRow.Split("=")[1].Trim().Split(" ");
        var firstPart = expressionParts[0];
        var sign = expressionParts[1];
        var secondPart = expressionParts[2];

        for (int i = 0; i < moneyItemList.Count; i++)
        {
            if (!moneyInspectCounter.ContainsKey(monkey))
            {
                moneyInspectCounter.Add(monkey, 1);
            }
            else
            {

                moneyInspectCounter[monkey]++;
            }

            var item = moneyItemList[i];
            long worryLevelAfterTest;
            long firstNum;
            if (firstPart == "old")
            {
                firstNum = item;
            }
            else
            {
                firstNum = int.Parse(firstPart);
            }

            long secondNum;
            if (secondPart == "old")
            {
                secondNum = item;
            }
            else
            {
                secondNum = int.Parse(secondPart);
            }

            if (sign == "+")
            {
                worryLevelAfterTest = firstNum + secondNum;
            }
            else
            {
                worryLevelAfterTest = firstNum * secondNum;
            }

            worryLevelAfterTest = worryLevelAfterTest / 3;

            moneyItemList[i] = worryLevelAfterTest;
        }

        var testRow = Console.ReadLine();
        monkeyCommands[monkey].Add(testRow);
        var number = int.Parse(testRow.Split("divisible by ")[1]);

        var ifTrueRow = Console.ReadLine();
        monkeyCommands[monkey].Add(ifTrueRow);
        var ifTrueMonkey = int.Parse(ifTrueRow.Split("to monkey ")[1]);
        var ifFalseRow = Console.ReadLine();
        monkeyCommands[monkey].Add(ifFalseRow);
        var ifFalseMoneky = int.Parse(ifFalseRow.Split("to monkey ")[1]);

        foreach (var item in moneyItemList)
        {
            var isTrue = item % number == 0;

            if (isTrue)
            {
                if (!monkeys.ContainsKey(ifTrueMonkey))
                {
                    monkeys.Add(ifTrueMonkey, new List<long>());
                }

                monkeys[ifTrueMonkey].Add(item);
            }
            else
            {
                if (!monkeys.ContainsKey(ifFalseMoneky))
                {
                    monkeys.Add(ifFalseMoneky, new List<long>());
                }

                monkeys[ifFalseMoneky].Add(item);
            }
        }

        moneyItemList.Clear();

        var endRow = Console.ReadLine();
    }

    for (int round = 0; round < 19; round++)
    {
        foreach (var item in monkeyCommands)
        {
            var operationRow = monkeyCommands[item.Key][1];
            var expressionParts = operationRow.Split("=")[1].Trim().Split(" ");
            var firstPart = expressionParts[0];
            var sign = expressionParts[1];
            var secondPart = expressionParts[2];

            var moneyItemList = monkeys[item.Key];
            for (int i = 0; i < moneyItemList.Count; i++)
            {
                if (!moneyInspectCounter.ContainsKey(item.Key))
                {
                    moneyInspectCounter.Add(item.Key, 1);
                }
                else
                {

                    moneyInspectCounter[item.Key]++;
                }

                var worryLevel = moneyItemList[i];
                long worryLevelAfterTest;
                long firstNum;
                if (firstPart == "old")
                {
                    firstNum = worryLevel;
                }
                else
                {
                    firstNum = int.Parse(firstPart);
                }

                long secondNum;
                if (secondPart == "old")
                {
                    secondNum = worryLevel;
                }
                else
                {
                    secondNum = int.Parse(secondPart);
                }

                if (sign == "+")
                {
                    worryLevelAfterTest = firstNum + secondNum;
                }
                else
                {
                    worryLevelAfterTest = firstNum * secondNum;
                }

                worryLevelAfterTest = worryLevelAfterTest / 3;

                moneyItemList[i] = worryLevelAfterTest;
            }

            var testRow = monkeyCommands[item.Key][2];
            var number = int.Parse(testRow.Split("divisible by ")[1]);


            var ifTrueRow = monkeyCommands[item.Key][3];
            var ifTrueMonkey = int.Parse(ifTrueRow.Split("to monkey ")[1]);
            var ifFalseRow = monkeyCommands[item.Key][4];
            var ifFalseMoneky = int.Parse(ifFalseRow.Split("to monkey ")[1]);

            foreach (var monkeyItem in moneyItemList)
            {
                var isTrue = monkeyItem % number == 0;

                if (isTrue)
                {
                    if (!monkeys.ContainsKey(ifTrueMonkey))
                    {
                        monkeys.Add(ifTrueMonkey, new List<long>());
                    }

                    monkeys[ifTrueMonkey].Add(monkeyItem);
                }
                else
                {
                    if (!monkeys.ContainsKey(ifFalseMoneky))
                    {
                        monkeys.Add(ifFalseMoneky, new List<long>());
                    }

                    monkeys[ifFalseMoneky].Add(monkeyItem);
                }
            }

            moneyItemList.Clear();
        }
    }
}

void Part2()
{
    long totalCombinedTestFactors = 1;
    while (true)
    {
        var row = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(row))
        {
            break;
        }

        var monkey = int.Parse(row.Split(" ")[1].TrimEnd(':'));

        if (!monkeys.ContainsKey(monkey))
        {
            monkeys.Add(monkey, new List<long>());
        }
        monkeyCommands[monkey] = new List<string>();

        var worryLevelRow = Console.ReadLine();
        monkeyCommands[monkey].Add(worryLevelRow);
        var worryLevels = worryLevelRow.Split(":")[1]
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var moneyItemList = monkeys[monkey];
        for (int j = 0; j < worryLevels.Count; j++)
        {
            var worryLevel = worryLevels[j];
            var alreadyHasThisItem = moneyItemList.Count > j;
            if (alreadyHasThisItem)
            {
                moneyItemList.Insert(0, long.Parse(worryLevel));
            }
            else
            {
                moneyItemList.Add(long.Parse(worryLevel));
            }
        }

        var operationRow = Console.ReadLine();
        monkeyCommands[monkey].Add(operationRow);
        var expressionParts = operationRow.Split("=")[1].Trim().Split(" ");
        var firstPart = expressionParts[0];
        var sign = expressionParts[1];
        var secondPart = expressionParts[2];

        for (int i = 0; i < moneyItemList.Count; i++)
        {
            if (!moneyInspectCounter.ContainsKey(monkey))
            {
                moneyInspectCounter.Add(monkey, 1);
            }
            else
            {

                moneyInspectCounter[monkey]++;
            }

            var item = moneyItemList[i];
            long worryLevelAfterTest;
            long firstNum;
            if (firstPart == "old")
            {
                firstNum = item;
            }
            else
            {
                firstNum = int.Parse(firstPart);
            }

            long secondNum;
            if (secondPart == "old")
            {
                secondNum = item;
            }
            else
            {
                secondNum = int.Parse(secondPart);
            }

            if (sign == "+")
            {
                worryLevelAfterTest = firstNum + secondNum;
            }
            else
            {
                worryLevelAfterTest = firstNum * secondNum;
            }

            moneyItemList[i] = worryLevelAfterTest;
        }

        var testRow = Console.ReadLine();
        monkeyCommands[monkey].Add(testRow);
        var number = int.Parse(testRow.Split("divisible by ")[1]);
        totalCombinedTestFactors *= number;

        var ifTrueRow = Console.ReadLine();
        monkeyCommands[monkey].Add(ifTrueRow);
        var ifTrueMonkey = int.Parse(ifTrueRow.Split("to monkey ")[1]);
        var ifFalseRow = Console.ReadLine();
        monkeyCommands[monkey].Add(ifFalseRow);
        var ifFalseMoneky = int.Parse(ifFalseRow.Split("to monkey ")[1]);

        foreach (var item in moneyItemList)
        {
            var isTrue = item % number == 0;

            if (isTrue)
            {
                if (!monkeys.ContainsKey(ifTrueMonkey))
                {
                    monkeys.Add(ifTrueMonkey, new List<long>());
                }

                monkeys[ifTrueMonkey].Add(item);
            }
            else
            {
                if (!monkeys.ContainsKey(ifFalseMoneky))
                {
                    monkeys.Add(ifFalseMoneky, new List<long>());
                }

                monkeys[ifFalseMoneky].Add(item);
            }
        }

        moneyItemList.Clear();

        var endRow = Console.ReadLine();
    }

    for (int round = 0; round < 9999; round++)
    {
        foreach (var item in monkeyCommands)
        {
            var operationRow = monkeyCommands[item.Key][1];
            var expressionParts = operationRow.Split("=")[1].Trim().Split(" ");
            var firstPart = expressionParts[0];
            var sign = expressionParts[1];
            var secondPart = expressionParts[2];

            var moneyItemList = monkeys[item.Key];
            for (int i = 0; i < moneyItemList.Count; i++)
            {
                if (!moneyInspectCounter.ContainsKey(item.Key))
                {
                    moneyInspectCounter.Add(item.Key, 1);
                }
                else
                {

                    moneyInspectCounter[item.Key]++;
                }

                var worryLevel = moneyItemList[i];
                long worryLevelAfterTest;
                long firstNum;
                if (firstPart == "old")
                {
                    firstNum = worryLevel;
                }
                else
                {
                    firstNum = long.Parse(firstPart);
                }

                long secondNum;
                if (secondPart == "old")
                {
                    secondNum = worryLevel;
                }
                else
                {
                    secondNum = long.Parse(secondPart);
                }

                if (sign == "+")
                {
                    worryLevelAfterTest = firstNum + secondNum;
                }
                else
                {
                    worryLevelAfterTest = firstNum * secondNum;
                }

                worryLevelAfterTest %= totalCombinedTestFactors;

                moneyItemList[i] = worryLevelAfterTest;

            }

            var testRow = monkeyCommands[item.Key][2];
            var number = long.Parse(testRow.Split("divisible by ")[1]);


            var ifTrueRow = monkeyCommands[item.Key][3];
            var ifTrueMonkey = int.Parse(ifTrueRow.Split("to monkey ")[1]);
            var ifFalseRow = monkeyCommands[item.Key][4];
            var ifFalseMoneky = int.Parse(ifFalseRow.Split("to monkey ")[1]);

            foreach (var monkeyItem in moneyItemList)
            {
                var isTrue = monkeyItem % number == 0;

                if (isTrue)
                {
                    if (!monkeys.ContainsKey(ifTrueMonkey))
                    {
                        monkeys.Add(ifTrueMonkey, new List<long>());
                    }

                    monkeys[ifTrueMonkey].Add(monkeyItem);
                }
                else
                {
                    if (!monkeys.ContainsKey(ifFalseMoneky))
                    {
                        monkeys.Add(ifFalseMoneky, new List<long>());
                    }

                    monkeys[ifFalseMoneky].Add(monkeyItem);
                }
            }

            moneyItemList.Clear();
        }
    }
}

var top2 = moneyInspectCounter.OrderByDescending(x => x.Value).Select(x => x.Value).Take(2).ToList();
Console.WriteLine(top2[0] * top2[1]) ;

