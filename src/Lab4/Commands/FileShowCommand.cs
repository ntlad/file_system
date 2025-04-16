using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public enum FileShowMode
{
    Console,
}

public class FileShowCommand(string path, FileShowMode mode) : ICommand, IEquatable<FileShowCommand>
{
    private readonly FileShowMode _mode = mode;
    private string _path = path;

    public ResultType Execute(Workspace workspace)
    {
        if (workspace.FileSystem is null)
        {
            return new ResultType("There's nothing to the file system", Result.Failure);
        }

        if (!workspace.FileSystem.IsAbsolutePath(_path))
            _path = workspace.FileSystem.PathToAbsolute(workspace.FileSystem.CombineWithCurrentDirectory(_path));

        string? file;
        try
        {
            file = workspace.FileSystem.ReadAllText(_path);
        }
        catch (Exception e) when (e is SystemException)
        {
            file = null;
        }

        IPrinter printer = PrinterCreator.Create(_mode);
        if (file != null)
        {
            printer.Print(file);
            return new ResultType(Result.Success);
        }

        return new ResultType(Result.Failure);
    }

    public bool Equals(FileShowCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(_path, other._path, StringComparison.OrdinalIgnoreCase) && _mode == other._mode;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((FileShowCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType());
    }
}