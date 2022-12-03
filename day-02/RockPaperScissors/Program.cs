//var signPoints = new Dictionary<string, int>
//{
//    { "X", 1 },
//    { "Y", 2 },
//    { "Z", 3 }
//};

//Part 1:
//var totalPoints = 0;
//while (true)
//{
//    var round = Console.ReadLine();
//    if (string.IsNullOrEmpty(round))
//    {
//        break;
//    }
//    var signs = round.Split(' ');
//    var firstSign = signs[0];
//    var secondSign = signs[1];
//    var points = GetMatchPoints(firstSign, secondSign);
//    totalPoints += points;
//}

//Console.WriteLine(totalPoints);

//int GetMatchPoints(string firstSign, string secondSign)
//{
//    var result = signPoints[secondSign];
//    if (firstSign == "A" && secondSign == "X" ||
//        firstSign == "B" && secondSign == "Y" ||
//        firstSign == "C" && secondSign == "Z")
//    {
//        result += 3;
//    }
//    else if (firstSign == "A" && secondSign == "Y" ||
//             firstSign == "B" && secondSign == "Z" ||
//             firstSign == "C" && secondSign == "X")
//    {
//        result += 6;
//    }

//    return result;
//}

//Part2:

var signPointsMapping = new Dictionary<string, int>
{
    { "A", 1 },
    { "B", 2 },
    { "C", 3 }
};
var totalPoints = 0;
while (true)
{
    var round = Console.ReadLine();
    if (string.IsNullOrEmpty(round))
    {
        break;
    }
    var signs = round.Split(' ');
    var firstSign = signs[0];
    var secondSign = signs[1];
    var points = GetMatchPoints(firstSign, secondSign);
    totalPoints += points;
}

Console.WriteLine(totalPoints);

int GetMatchPoints(string firstSign, string secondSign)
{
    var actualSign = string.Empty;
    if (firstSign == "A" && secondSign == "X" ||
        firstSign == "C" && secondSign == "Y" ||
        firstSign == "B" && secondSign == "Z")
    {
        actualSign = "C";
    }
    else if(firstSign == "B" && secondSign == "X" ||
        firstSign == "A" && secondSign == "Y" ||
            firstSign == "C" && secondSign == "Z")
    {
        actualSign = "A";
    }
    else if (firstSign == "C" && secondSign == "X" ||
            firstSign == "B" && secondSign == "Y" ||
            firstSign == "A" && secondSign == "Z")
    {
        actualSign = "B";
    }

    var signPoints = signPointsMapping[actualSign];
    var winPoints = secondSign == "X" ? 0 : secondSign == "Y" ? 3 : 6;
    return signPoints + winPoints;
}