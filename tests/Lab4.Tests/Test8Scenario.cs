using Itmo.ObjectOrientedProgramming.Lab4.ArgParser;
using Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Xunit;

namespace Lab4.Tests;

public class Test8Scenario()
{
    [Fact]
    public void ParseFileDeleteCommand_DeleteFileFromPath_Success()
    {
        var handler = new FileDeleteArgumentHandler();
        var parser = new Parser(handler);
        ICommand? command = parser.Parse("file delete path") ?? throw new ArgumentNullException(nameof(parser));

        var expected = new FileDeleteCommand("path");

        expected.Equals(command);
    }
}