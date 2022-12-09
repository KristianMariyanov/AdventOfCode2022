
var tailVisitedPositions = new HashSet<(int x, int y)>();
var tailPositions = Enumerable.Range(0, 9).Select(i => (x: 0, y: 0)).ToList();
(int x, int y) headPosition = (0, 0);
(int x, int y) tailPosition = (0, 0);
while (true)
{
    var row = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(row))
    {
        break;
    }

    var parts = row.Split(' ');
    var direction = parts[0];
    var distance = int.Parse(parts[1]);

    // Part1(direction, distance);
    Part2(direction, distance);
}

Console.WriteLine(tailVisitedPositions.Count);
void Part2(string direction, int distance)
{
    for (int i = 0; i < distance; i++)
    {
        switch (direction)
        {
            case "U":
                headPosition.y++;
                break;
            case "D":
                headPosition.y--;
                break;
            case "L":
                headPosition.x--;
                break;
            case "R":
                headPosition.x++;
                break;
        }
        var currentHead = headPosition;
        for (int j = 0; j < tailPositions.Count; j++)
        {
            tailPositions[j] = GetTailNewPosition(currentHead, tailPositions[j]);
            currentHead = tailPositions[j];
        }
        

        tailVisitedPositions.Add(tailPositions.Last());
    }
}

void Part1(string direction, int distance)
{
    for(int i = 0; i < distance; i++)
    {
        switch (direction)
        {
            case "U":
                headPosition.y++;
                break;
            case "D":
                headPosition.y--;
                break;
            case "L":
                headPosition.x--;
                break;
            case "R":
                headPosition.x++;
                break;
        }
        tailPosition = GetTailNewPosition(headPosition, tailPosition);

        tailVisitedPositions.Add(tailPosition);
    }
}

(int x, int y) GetTailNewPosition((int x, int y) headPosition, (int x, int y) tailPosition)
{
    var tailNewPosition = tailPosition;
    if (Math.Abs(headPosition.x - tailPosition.x) <= 1 && Math.Abs(headPosition.y - tailPosition.y) <= 1)
    {
        return tailPosition;
    }
    else
    {
        if (Math.Abs(headPosition.x - tailPosition.x) == 2 && headPosition.y == tailPosition.y)
        {
            if (headPosition.x - tailPosition.x == 2)
            {
                tailNewPosition = (tailPosition.x + 1, tailPosition.y);
            }
            else
            {
                tailNewPosition = (tailPosition.x - 1, tailPosition.y);
            }
        }
        else if(Math.Abs(headPosition.y - tailPosition.y) == 2 && headPosition.x == tailPosition.x)
        {
            if (headPosition.y - tailPosition.y == 2)
            {
                tailNewPosition = (tailPosition.x, tailPosition.y + 1);
            }
            else
            {
                tailNewPosition = (tailPosition.x, tailPosition.y - 1);
            }
        }
        else if(Math.Abs(headPosition.y - tailPosition.y) == 2)
        {
            var newX = 0;
            if (headPosition.x > tailPosition.x)
            {

                newX = tailPosition.x + 1;
            }
            else
            {
                newX = tailPosition.x - 1;
            }

            if (headPosition.y - tailPosition.y == 2)
            {

                tailNewPosition = (newX, tailPosition.y + 1);
            }
            else
            {
                tailNewPosition = (newX, tailPosition.y - 1);
            }
        }
        else if (Math.Abs(headPosition.x - tailPosition.x) == 2)
        {
            var newY = 0;
            if (headPosition.y > tailPosition.y)
            {

                newY = tailPosition.y + 1;
            }
            else
            {
                newY = tailPosition.y - 1;
            }

            if (headPosition.x - tailPosition.x == 2)
            {

                tailNewPosition = (tailPosition.x + 1, newY);
            }
            else
            {
                tailNewPosition = (tailPosition.x - 1, newY);
            }
        }
    }

    return tailNewPosition;
}