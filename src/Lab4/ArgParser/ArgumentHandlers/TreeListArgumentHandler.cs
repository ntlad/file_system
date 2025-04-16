using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;

public class TreeListArgumentHandler : ArgumentHandlerBase
{
    public override ICommand? Handle(IList<string> args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args is not ["tree", "list", "-d", _] && args is not ["tree", "list"]) return Next?.Handle(args);

        int depth = 1;
        if (args is not ["tree", "list", "-d", _]) return new TreeListCommand(depth);

        try
        {
            depth = int.Parse(args[3]);
            if (depth <= 0) return Next?.Handle(args);
        }
        catch (Exception e) when (e is ArgumentException || e is InvalidOperationException)
        {
            return Next?.Handle(args);
        }

        return new TreeListCommand(depth);
    }
}