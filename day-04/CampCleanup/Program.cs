var total = 0;
while (true)
{
    var pair = Console.ReadLine();
    if (string.IsNullOrEmpty(pair))
    {
        break;
    }
    var numbers = pair.Split(',');
    var firstElf = numbers[0];
    var secondElf = numbers[1];

    var firstElfFirstNumber = int.Parse(firstElf.Split('-')[0]);
    var firstElfSecondNumber = int.Parse(firstElf.Split('-')[1]);
    var secondElfFirstNumber = int.Parse(secondElf.Split('-')[0]);
    var secondElfSecondNumber = int.Parse(secondElf.Split('-')[1]);

    total += Part2(firstElfFirstNumber, firstElfSecondNumber, secondElfFirstNumber, secondElfSecondNumber) ? 1 : 0;
}

Console.WriteLine(total);

bool Part1(int firstElfFirstNumber, int firstElfSecondNumber, int secondElfFirstNumber, int secondElfSecondNumber)
{
    if (firstElfFirstNumber >= secondElfFirstNumber && firstElfSecondNumber <= secondElfSecondNumber)
    {
        return true;
    }
    else if (firstElfFirstNumber <= secondElfFirstNumber && firstElfSecondNumber >= secondElfSecondNumber)
    {
        return true;
    }

    return false;
}

bool Part2(int firstElfFirstNumber, int firstElfSecondNumber, int secondElfFirstNumber, int secondElfSecondNumber)
{
    if (firstElfFirstNumber > secondElfSecondNumber && firstElfSecondNumber > secondElfSecondNumber)
    {
        return false;
    }

    if (firstElfFirstNumber < secondElfFirstNumber && firstElfSecondNumber < secondElfFirstNumber)
    {
        return false;
    }

    return true;
}