using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;

public class FileMoveArgumentHandler : ArgumentHandlerBase
{
    public override ICommand? Handle(IList<string> args)
    {
        ArgumentNullException.ThrowIfNull(args);

        return args is not ["file", "move", _, _]
            ? Next?.Handle(args)
            : new FileMoveCommand(args[2], args[3]);
    }
}