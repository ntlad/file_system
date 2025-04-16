using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand(int depth = 1) : ICommand, IEquatable<TreeListCommand>
{
    private readonly int _depth = depth;

    public ResultType Execute(Workspace workspace)
    {
        if (workspace.FileSystem is null)
        {
            return new ResultType("There's nothing to the file system", Result.Failure);
        }

        var factory = new FileSystemComponentFactory();
        IFileSystemComponent component = factory.Create(workspace.FileSystem.CurrentDirectory);

        var visitor = new ConsoleVisitor(_depth);
        component.Accept(visitor);

        return new ResultType(Result.Success);
    }

    public bool Equals(TreeListCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _depth == other._depth;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((TreeListCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType());
    }
}