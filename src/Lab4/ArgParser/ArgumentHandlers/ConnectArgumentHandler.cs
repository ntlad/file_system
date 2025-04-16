using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;

public class ConnectArgumentHandler : ArgumentHandlerBase
{
    public override ICommand? Handle(IList<string> args)
    {
        ArgumentNullException.ThrowIfNull(args);

        return args is not ["connect", _, "-m", _]
            ? Next?.Handle(args)
            : args[3] == "local" ? new ConnectCommand(args[1], FileSystemMode.Local) : Next?.Handle(args);
    }
}