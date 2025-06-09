public class Program
{
    public static int DistanceBetweenPair((int left, int right) pair) => Math.Abs(pair.left - pair.right);

    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the input file path.");
            return;
        }

        string filePath = args[0];
        string[] lines = File.ReadAllLines(filePath);

        List<int> leftColumn = [];
        List<int> rightColumn = [];

        foreach (var line in lines)
        {
            var numbers = line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries);
            if (numbers.Length == 2)
            {
                int left = int.Parse(numbers[0]);
                int right = int.Parse(numbers[1]);
                leftColumn.Add(left);
                rightColumn.Add(right);
            }
        }

        leftColumn.Sort();
        rightColumn.Sort();

        int sumDistances = leftColumn.Zip(rightColumn, (l, r) => (l, r))
            .Select(DistanceBetweenPair)
            .Sum();

        Console.WriteLine($"Total distance between lists: {sumDistances}");
    }
}
