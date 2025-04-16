using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;

public interface IArgumentHandler
{
    IArgumentHandler SetNext(IArgumentHandler nextHandler);

    ICommand? Handle(IList<string> args);
}