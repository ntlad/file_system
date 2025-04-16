using Itmo.ObjectOrientedProgramming.Lab4.ArgParser;
using Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Xunit;

namespace Lab4.Tests;

public class Test5Scenario()
{
    [Fact]
    public void ParseFileShowCommand_ShowFileFromSpecificPath_Success()
    {
        var handler = new FileShowArgumentHandler();
        var parser = new Parser(handler);
        ICommand? command = parser.Parse("file show path -m console") ?? throw new ArgumentNullException(nameof(parser));

        var expected = new FileShowCommand("path", FileShowMode.Console);

        expected.Equals(command);
    }
}