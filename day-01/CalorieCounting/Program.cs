// Part 1:
//var bestElf = 0;
//var currentElf = 0;

//while (true)
//{
//    var currentLine = Console.ReadLine();
//    if (string.IsNullOrEmpty(currentLine))
//	{
//        // end of elf
//        currentElf = 0;
//        continue;

//    }

//    var calories = int.Parse(currentLine);

//    currentElf += calories;
//    if (currentElf > bestElf)
//    {
//        bestElf = currentElf;
//    }


//    Console.WriteLine("Current Best elf: " + bestElf);
//}

// Part 2:
var top3Elfs = new List<int>();
var currentElf = 0;

while (true)
{
    var currentLine = Console.ReadLine();
    if (string.IsNullOrEmpty(currentLine))
    {
        // end of elf

        if (top3Elfs.Any(x => x < currentElf) || top3Elfs.Count < 3)
        {
            if (top3Elfs.Count == 3)
            {
                top3Elfs.Remove(top3Elfs.Min());
            }
            
            top3Elfs.Add(currentElf);
        }

        currentElf = 0;

        Console.WriteLine("Current Sum of Top 3 elfs: " + top3Elfs.Sum());
        continue;

    }

    var calories = int.Parse(currentLine);

    currentElf += calories;

    Console.WriteLine("Current Sum of Top 3 elfs: " + top3Elfs.Sum());
}

