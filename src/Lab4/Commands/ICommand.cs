namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    public ResultType Execute(Workspace workspace);
}