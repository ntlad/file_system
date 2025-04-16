using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;

public class FileDeleteArgumentHandler : ArgumentHandlerBase
{
    public override ICommand? Handle(IList<string> args)
    {
        ArgumentNullException.ThrowIfNull(args);

        return args is not ["file", "delete", _]
            ? Next?.Handle(args)
            : new FileDeleteCommand(args[2]);
    }
}