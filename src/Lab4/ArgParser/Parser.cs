using Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ArgParser;

public class Parser
{
    private readonly IArgumentHandler _argumentHandler;

    public Parser(IArgumentHandler argumentHandler)
    {
        _argumentHandler = argumentHandler;
    }

    public ICommand? Parse(string argLine)
    {
        ArgumentNullException.ThrowIfNull(argLine);

        IList<string> args = [];

        foreach (string str in argLine.Split(" "))
            if (!string.IsNullOrEmpty(str)) args.Add(str);

        return _argumentHandler.Handle(args);
    }

    public ICommand? Parse(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        return _argumentHandler.Handle(args);
    }
}