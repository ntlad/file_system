using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;

public abstract class ArgumentHandlerBase : IArgumentHandler
{
    protected IArgumentHandler? Next { get; set; }

    public IArgumentHandler SetNext(IArgumentHandler nextHandler)
    {
        if (Next is null)
        {
            Next = nextHandler;
        }
        else
        {
            Next.SetNext(nextHandler);
        }

        return this;
    }

    public abstract ICommand? Handle(IList<string> args);
}