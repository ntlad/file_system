using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public enum FileSystemMode
{
    Local,
}

public class ConnectCommand(string address, FileSystemMode mode) : ICommand, IEquatable<ConnectCommand>
{
    private readonly string _address = address;
    private readonly FileSystemMode _mode = mode;

    public ResultType Execute(Workspace workspace)
    {
        if (Directory.Exists(_address))
        {
            workspace.FileSystem = FileSystemCreator.Create(_address, _mode);
            return new ResultType(Result.Success);
        }

        return new ResultType("The path doesn't exists.", Result.Failure);
    }

    public bool Equals(ConnectCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(_address, other._address, StringComparison.OrdinalIgnoreCase) && _mode == other._mode;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ConnectCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType());
    }
}