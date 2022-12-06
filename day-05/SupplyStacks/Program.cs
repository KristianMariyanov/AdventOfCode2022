// each 4 chars of the line is a separate elemnt of the array

using System.Collections;

var piles = Enumerable.Range(0, 9).Select(x => new Stack<char>()).ToList();
while (true)
{
    var row = Console.ReadLine();
    if (row.Contains('1'))
    {
        // reading the empty line between the piles and movements
        Console.ReadLine();
        break;
    }

    for (int i = 0; i < row.Length; i += 4)
    {
        var currentChar = row[i + 1];
        if (currentChar != ' ')
        {
            var index = i == 0 ? 0 : i / 4;
            piles[index].Push(currentChar);
        }
    }
}
piles = piles.Select(x => new Stack<char>(x.ToList())).ToList();

while (true)
{
    var row = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(row))
    {
        break;
    }

    var instructionNumbers = row
        .Replace("move", string.Empty)
        .Replace("from", string.Empty)
        .Replace("to", string.Empty)
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    var moveNumber = int.Parse(instructionNumbers[0]);
    var fromPileIndex = int.Parse(instructionNumbers[1]) - 1;
    var toPileIndex = int.Parse(instructionNumbers[2]) - 1;

    Part2(moveNumber, fromPileIndex, toPileIndex);
}

void Part1(int moveNumber, int fromPileIndex, int toPileIndex)
{
    for (int i = 0; i < moveNumber; i++)
    {
        if (piles[fromPileIndex].TryPop(out char charForMoving))
        {
            piles[toPileIndex].Push(charForMoving);
        }
    }
}

void Part2(int moveNumber, int fromPileIndex, int toPileIndex)
{
    var allCrates = new List<char>();
    for (int i = 0; i < moveNumber; i++)
    {
        if (piles[fromPileIndex].TryPop(out char charForMoving))
        {
            allCrates.Add(charForMoving);
        }
    }

    allCrates.Reverse();
    foreach (var crate in allCrates)
    {
        piles[toPileIndex].Push(crate);
    }
}

Console.WriteLine(string.Join(string.Empty, piles.Select(p => p.Count > 0 ? p.Pop().ToString() : string.Empty).ToList()));
