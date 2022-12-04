static int Priority(char c) => c >= 'a' && c <= 'z' ? c - 'a' + 1 : c - 'A' + 27;

// List of rucksacks with items in two compartments
string[] rucksacks = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw".Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

var a = Part2(rucksacks);
Console.WriteLine(a);


static int Part1(string[] input)
{
    var total = 0;
    foreach (var line in input)
    {
        var part1 = line.Substring(0, line.Length / 2);
        var part2 = line.Substring(line.Length / 2);
        var common = part1.Intersect(part2);

        total += Priority(common.Single());
    }

    return total;
}
static int Part2(string[] input)
{
    var groupNumber = 0;

    var total = 0;
    while (true)
    {
        var currentGroup = input.Skip(groupNumber * 3).Take(3).ToList();
        if (!currentGroup.Any())
        {
            break;
        }
        var common = currentGroup[0].Intersect(currentGroup[1]).Intersect(currentGroup[2]);
        groupNumber++;


        total += Priority(common.Single());
    }

    return total;
}