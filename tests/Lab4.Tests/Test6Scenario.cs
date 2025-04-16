using Itmo.ObjectOrientedProgramming.Lab4.ArgParser;
using Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Xunit;

namespace Lab4.Tests;

public class Test6Scenario()
{
    [Fact]
    public void ParseFileMoveCommand_MoveFileFromOnePathToAnother_Success()
    {
        var handler = new FileMoveArgumentHandler();
        var parser = new Parser(handler);
        ICommand? command = parser.Parse("file move sourcePath destinationPath") ?? throw new ArgumentNullException(nameof(parser));

        var expected = new FileMoveCommand("sourcePath", "destinationPath");

        expected.Equals(command);
    }
}