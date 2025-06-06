namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand, IEquatable<DisconnectCommand>
{
    public ResultType Execute(Workspace workspace)
    {
        workspace.FileSystem = null;
        return new ResultType(Result.Success);
    }

    public bool Equals(DisconnectCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((DisconnectCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType());
    }
}