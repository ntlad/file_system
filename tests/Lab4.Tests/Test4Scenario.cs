using Itmo.ObjectOrientedProgramming.Lab4.ArgParser;
using Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Xunit;

namespace Lab4.Tests;

public class Test4Scenario()
{
    [Fact]
    public void ParseTreeListCommand_ShowTreeListOfCurrentFolder_Success()
    {
        var handler = new TreeListArgumentHandler();
        var parser = new Parser(handler);
        ICommand? command = parser.Parse("tree list -d 3") ?? throw new ArgumentNullException(nameof(parser));

        var expected = new TreeListCommand(3);

        expected.Equals(command);
    }
}