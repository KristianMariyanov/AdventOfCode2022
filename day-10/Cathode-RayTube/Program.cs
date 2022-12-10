
using System.Text;

var registryNumber = 1;
var circleCount = 0;
var signalStrength = 0;
var signalStrengthSum = 0;
var commandWaitingList = new List<int>();
var spriteIndex = 1;
var sb = new StringBuilder();
while (true)
{
    var row = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(row))
    {
        break;

        // wait to finish all circles
    }

    var currentMultiplier = 0;

    // start of circle
    int circleCounts;
    if (row.StartsWith("noop"))
    {
        // do nothing
        circleCounts = 1;
    }
    else
    {
        if (!string.IsNullOrWhiteSpace(row))
        {
            var commandParam = row?.Split(" ");
            var number = int.Parse(commandParam[1]);
            commandWaitingList.Add(number);
        }
        circleCounts = 2;
    }

    //currentMultiplier = DoCicle(circleCounts);
    //Part1(currentMultiplier);

    DrawImage(circleCounts);

    for (int i = 0; i < commandWaitingList.Count; i++)
    {
        var currentItem = commandWaitingList[i];

        registryNumber += currentItem;
        spriteIndex = registryNumber;

    }

    commandWaitingList.Clear();

}

Console.WriteLine(sb);

void Part1(int currentMultiplier)
{
    signalStrength = registryNumber * currentMultiplier;
    if (currentMultiplier != 0)
    {

        //Console.WriteLine($"Multipier:" + currentMultiplier + " SignalStrength:" + signalStrength + " RegistryNumber:" + registryNumber);
        signalStrengthSum += signalStrength;
    }
    
    for (int i = 0; i < commandWaitingList.Count; i++)
    {
        var currentItem = commandWaitingList[i];
        
        registryNumber += currentItem;

    }

    commandWaitingList.Clear();
    //end of circle
}

int DoCicle(int count)
{
    var currentMultiplier = 0;
    for (int i = 0; i < count; i++)
    {
        circleCount++; 
        if ((circleCount == 20 || (circleCount - 20) % 40 == 0))
        {
            currentMultiplier = circleCount;
        }
    }

    return currentMultiplier;   

}
void DrawImage(int count)
{
    var charsToDraw = 0;
    for (int i = 0; i < count; i++)
    {
        if (circleCount % 40 == 0)
        {
            circleCount = 0;
            sb.AppendLine();
        }

        if (spriteIndex - 1 <= circleCount && circleCount <= spriteIndex + 1)
        {
            sb.Append("#");
        }
        else
        {
            sb.Append(".");
        }

        circleCount++;
    }

}

Console.WriteLine(registryNumber);
Console.WriteLine(signalStrengthSum);