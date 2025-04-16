using Itmo.ObjectOrientedProgramming.Lab4.ArgParser;
using Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Xunit;

namespace Lab4.Tests;

public class Test9Scenario()
{
    [Fact]
    public void ParseFileRenameCommand_RenameFileWithPath_Success()
    {
        var handler = new FileRenameArgumentHandler();
        var parser = new Parser(handler);
        ICommand? command = parser.Parse("file rename path name") ?? throw new ArgumentNullException(nameof(parser));

        var expected = new FileRenameCommand("path", "name");

        expected.Equals(command);
    }
}