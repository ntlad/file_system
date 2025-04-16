namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGoToCommand(string path) : ICommand, IEquatable<TreeGoToCommand>
{
    private readonly string _path = path;

    public ResultType Execute(Workspace workspace)
    {
        if (workspace.FileSystem is null)
        {
            return new ResultType("There's nothing to the file system", Result.Failure);
        }

        if (workspace.FileSystem.IsAbsolutePath(_path))
        {
            workspace.FileSystem.CurrentDirectory = _path;
            return new ResultType(Result.Success);
        }

        workspace.FileSystem.CurrentDirectory = workspace.FileSystem.CombineWithCurrentDirectory(_path);
        return new ResultType(Result.Success);
    }

    public bool Equals(TreeGoToCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(_path, other._path, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((TreeGoToCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType());
    }
}