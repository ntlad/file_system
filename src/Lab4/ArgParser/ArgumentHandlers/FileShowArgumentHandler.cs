using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;

public class FileShowArgumentHandler : ArgumentHandlerBase
{
    public override ICommand? Handle(IList<string> args)
    {
        ArgumentNullException.ThrowIfNull(args);

        return args is not ["file", "show", _, "-m", _]
            ? Next?.Handle(args)
            : args[4] == "console" ? new FileShowCommand(args[2], FileShowMode.Console) : Next?.Handle(args);
    }
}