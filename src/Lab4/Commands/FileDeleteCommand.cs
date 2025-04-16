namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand(string path) : ICommand, IEquatable<FileDeleteCommand>
{
    private readonly string _path = path;

    public ResultType Execute(Workspace workspace)
    {
        if (workspace.FileSystem is null)
        {
            return new ResultType("There's nothing to the file system", Result.Failure);
        }

        return !workspace.FileSystem.Delete(_path)
            ? new ResultType($"There is no file with path {_path}.", Result.Failure)
            : new ResultType(Result.Success);
    }

    public bool Equals(FileDeleteCommand? other)
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
        return Equals((FileDeleteCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType());
    }
}