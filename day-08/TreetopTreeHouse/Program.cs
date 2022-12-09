using System;
using System.Collections.Generic;

var matrix = new List<List<(int, bool)>>();

while (true)
{
    var line = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(line))
    {
        break;
    }

    //leave if empty row 
    var col = new List<(int, bool)>();
    matrix.Add(col);
    foreach (var c in line)
    {
        var num = int.Parse(c.ToString());
        col.Add((num, false));
    }
}

Part2();
void Part1()
{
    var total = 0;

    for (int i = 0; i < matrix.Count; i++)
    {
        var max = int.MinValue;
        for (int j = 0; j < matrix[i].Count; j++)
        {
            if (max < matrix[i][j].Item1)
            {
                max = matrix[i][j].Item1;
                matrix[i][j] = (matrix[i][j].Item1, true);
            }
        }
    }

    for (int i = 0; i < matrix[0].Count; i++)
    {
        var max = int.MinValue;
        for (int j = 0; j < matrix.Count; j++)
        {
            if (max < matrix[j][i].Item1)
            {
                max = matrix[j][i].Item1;
                matrix[j][i] = (matrix[j][i].Item1, true);
            }
        }

    }

    // reverse for
    for (int i = matrix.Count - 1; i >= 0; i--)
    {
        var max = int.MinValue;
        for (int j = matrix[i].Count - 1; j >= 0; j--)
        {
            if (max < matrix[i][j].Item1)
            {
                max = matrix[i][j].Item1;
                matrix[i][j] = (matrix[i][j].Item1, true);
            }
        }
    }

    for (int i = matrix[0].Count - 1; i >= 0; i--)
    {
        var max = int.MinValue;
        for (int j = matrix.Count - 1; j >= 0; j--)
        {
            if (max < matrix[j][i].Item1)
            {
                max = matrix[j][i].Item1;
                matrix[j][i] = (matrix[j][i].Item1, true);
            }
        }
    }

    Console.WriteLine(matrix.Sum(x => x.Sum(y => y.Item2 ? 1 : 0)));

}

void Part2()
{
    var maxScore = 0;
    for (int i = 0; i < matrix.Count; i++)
    {
        for (int j = 0; j < matrix[i].Count; j++)
        {
            var up = GoUp(i, j);
            var down = GoDown(i, j);
            var left = GoLeft(i, j);
            var right= GoRight(i, j);
            var score = (up * down * left * right);
            if (score > maxScore)
            {
                maxScore = score;
            }
        }
    }

    Console.WriteLine(maxScore);

    int GoUp(int i, int j)
    {
        var currentRow = i;
        var maxNumber = matrix[i][j].Item1;
        var treeNumber = 0;
        while (currentRow > 0)
        {
            currentRow = currentRow - 1;
            if (matrix[currentRow][j].Item1 < maxNumber)
            {
                treeNumber++;
            }
            else
            {
                treeNumber++;
                break;
            }
        }
        
        return treeNumber;
    }

    int GoDown(int i, int j)
    {
        var currentRow = i;
        var currentNumber = matrix[i][j].Item1;
        var treeNumber = 0;
        while (currentRow < matrix.Count - 1)
        {
            currentRow = currentRow + 1;
            if (matrix[currentRow][j].Item1 < currentNumber)
            {
                treeNumber++;
            }
            else
            {
                treeNumber++;
                break;
            }
        }

        return treeNumber;
    }

    int GoLeft(int i, int j)
    {
        var currentCol = j;
        var currentNumber = matrix[i][j].Item1;
        var treeNumber = 0;
        while (currentCol > 0)
        {
            currentCol = currentCol - 1;
            if (matrix[i][currentCol].Item1 < currentNumber)
            {
                treeNumber++;
            }
            else
            {
                treeNumber++;
                break;
            }
        }

        return treeNumber;
    }

    int GoRight(int i, int j)
    {
        var currentCol = j;
        var currentNumber = matrix[i][j].Item1;
        var treeNumber = 0;
        while (currentCol < matrix[i].Count - 1)
        {
            currentCol = currentCol + 1;
            if (matrix[i][currentCol].Item1 < currentNumber)
            {
                treeNumber++;
            }
            else
            {
                treeNumber++;
                break;
            }
        }

        return treeNumber;
    }
}