using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;

public class FileCopyArgumentHandler : ArgumentHandlerBase
{
    public override ICommand? Handle(IList<string> args)
    {
        ArgumentNullException.ThrowIfNull(args);

        return args is not ["file", "copy", _, _]
            ? Next?.Handle(args)
            : new FileCopyCommand(args[2], args[3]);
    }
}