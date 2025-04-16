using Itmo.ObjectOrientedProgramming.Lab4.ArgParser;
using Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Xunit;

namespace Lab4.Tests;

public class Test3Scenario()
{
    [Fact]
    public void ParseTreeGoToCommand_SwitchToNewFolder_Success()
    {
        var handler = new TreeGoToArgumentHandler();
        var parser = new Parser(handler);
        ICommand? command = parser.Parse("tree goto path") ?? throw new ArgumentNullException(nameof(parser));

        var expected = new TreeGoToCommand("path");

        expected.Equals(command);
    }
}