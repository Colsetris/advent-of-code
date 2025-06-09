namespace Day1.Tests;

using System.Text;
using Xunit;

public class ProgramTest
{
    [Fact]
    public void Main_NoArguments_PrintsErrorMessage()
    {
        var output = new StringBuilder();
        Console.SetOut(new StringWriter(output));

        Program.Main(Array.Empty<string>());

        Assert.Contains("Please provide the input file path.", output.ToString());
    }

    [Fact]
    public void Main_ValidInputFile_PrintsCorrectDistance()
    {
        string tempFile = Path.GetTempFileName();
        File.WriteAllLines(tempFile,
        [
            "3   4",
            "4   3",
            "2   5",
            "1   3",
            "3   9",
            "3   3"
        ]);

        var output = new StringBuilder();
        Console.SetOut(new StringWriter(output));

        Program.Main([tempFile]);

        Assert.Contains("Total distance between lists: 11", output.ToString());

        File.Delete(tempFile);
    }
}

