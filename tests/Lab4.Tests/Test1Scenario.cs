using Itmo.ObjectOrientedProgramming.Lab4.ArgParser;
using Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Xunit;

namespace Lab4.Tests;

public class Test1Scenario()
{
    [Fact]
    public void ParseConnectCommand_ConnectToFileSystem_Success()
    {
        var handler = new ConnectArgumentHandler();
        var parser = new Parser(handler);

        ICommand? command = parser.Parse(["connect", "addressee", "-m", "local"]) ?? throw new ArgumentException("Command could not be parsed.");

        var expected = new ConnectCommand("addressee", FileSystemMode.Local);

        expected.Equals(command);
    }
}