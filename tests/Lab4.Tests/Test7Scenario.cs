using Itmo.ObjectOrientedProgramming.Lab4.ArgParser;
using Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Xunit;

namespace Lab4.Tests;

public class Test7Scenario()
{
    [Fact]
    public void ParseFileCopyCommand_CopyFileToSpecificPath_Success()
    {
        var handler = new FileCopyArgumentHandler();
        var parser = new Parser(handler);
        ICommand? command = parser.Parse("file copy sourcePath destinationPath") ?? throw new ArgumentNullException(nameof(parser));

        var expected = new FileCopyCommand("sourcePath", "destinationPath");

        expected.Equals(command);
    }
}