using Itmo.ObjectOrientedProgramming.Lab4.ArgParser;
using Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Xunit;

namespace Lab4.Tests;

public class Test2Scenario()
{
    [Fact]
    public void ParseDisconnectCommand_DisonnectFromFileSystem_Success()
    {
        var handler = new DisconnectArgumentHandler();
        var parser = new Parser(handler);
        ICommand? command = parser.Parse("disconnect") ?? throw new ArgumentNullException(nameof(parser));

        var expected = new DisconnectCommand();

        expected.Equals(command);
    }
}