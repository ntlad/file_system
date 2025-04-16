namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand(string path, string name) : ICommand, IEquatable<FileRenameCommand>
{
    private readonly string _name = name;
    private readonly string _path = path;

    public ResultType Execute(Workspace workspace)
    {
        if (workspace.FileSystem is null)
        {
            return new ResultType("There's nothing to the file system", Result.Failure);
        }

        return !workspace.FileSystem.Rename(workspace.FileSystem.PathToAbsolute(_path), _name)
            ? new ResultType($"There is no file with path {_path}.", Result.Failure)
            : new ResultType(Result.Success);
    }

    public bool Equals(FileRenameCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(_path, other._path, StringComparison.OrdinalIgnoreCase) &&
               string.Equals(_name, other._name, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((FileRenameCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType());
    }
}