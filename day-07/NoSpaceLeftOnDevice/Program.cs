
var root = new TreeNode("/");

//skip first cd, since our root is already created;
Console.ReadLine();

var currentNode = root;
while (true)
{
    var row = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(row))
    {
        // populate all directory sizes
        while(currentNode != root)
        {
            currentNode.Parent.Size += currentNode.Size;
            currentNode = currentNode.Parent;
        }    
        break;
    }

    if (row == "$ ls" || row.StartsWith("dir"))
    {
        continue;
    }   
    else if(row.StartsWith("$ cd"))
    {
        if (row.Contains(".."))
        {
            currentNode.Parent.Size += currentNode.Size;
            currentNode = currentNode.Parent;
        }
        else
        {
            var dirName = row.Split(" ").Last();
            //currentNode.Children = currentNode.Children ?? new();
            var newNode = new TreeNode(dirName) { Parent = currentNode };
            currentNode.Children.Add(newNode);
            currentNode = newNode;
        }
        // change directory
    }
    else
    {
        var size = long.Parse(row.Split(" ")[0]);
        currentNode.Size += size;
    }
}
Part2();

void Part1()
{
    Console.WriteLine(GetSize());
}

void Part2()
{
    const int totalSize = 70_000_000;
    const int needForUpdate = 30_000_000;
    var leftForDeletion = needForUpdate - (totalSize - root.Size);

    long diff = long.MaxValue;
    TreeNode node = null;
    void FindCloser(TreeNode currentNode = null)
    {
        if (currentNode == null)
        {
            currentNode = root;
        }

        var potentialClearingSpace = leftForDeletion - currentNode.Size;
        if (potentialClearingSpace < diff && leftForDeletion < currentNode.Size)
        {
            diff = Math.Abs(potentialClearingSpace);
            node = currentNode;
        }

        foreach (var child in currentNode.Children)
        {
            FindCloser(child);
        }
    }

    FindCloser();
    Console.WriteLine(node.Size);
}

long GetSize(TreeNode currentNode = null)
{
    long total = 0;
    if (currentNode == null)
    {
        currentNode = root;
    }
    
    if (currentNode.Size <= 100_000)
    {

        total += currentNode.Size;
    }
    
    foreach (var child in currentNode.Children)
    {
        total += GetSize(child);
    }

    return total;
}




// treenode
public class TreeNode
{
    public string Name { get; set; }

    public List<TreeNode> Children { get; set; }

    public TreeNode Parent { get; set; }

    public long Size { get; set; }

    public TreeNode(string name)
    {
        Name = name;
        Children = new();
    }
}