using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;

public class TreeGoToArgumentHandler : ArgumentHandlerBase
{
    public override ICommand? Handle(IList<string> args)
    {
        ArgumentNullException.ThrowIfNull(args);

        return args is not ["tree", "goto", _]
            ? Next?.Handle(args)
            : new TreeGoToCommand(args[2]);
    }
}