namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileCopyCommand(string sourcePath, string destinationPath) : ICommand, IEquatable<FileCopyCommand>
{
    private string _sourcePath = sourcePath;
    private string _destinationPath = destinationPath;

    public ResultType Execute(Workspace workspace)
    {
        if (workspace.FileSystem is null)
        {
            return new ResultType("There's nothing to the file system", Result.Failure);
        }

        if (!workspace.FileSystem.IsAbsolutePath(_sourcePath)) _sourcePath = workspace.FileSystem.PathToAbsolute(_sourcePath);
        if (!workspace.FileSystem.IsAbsolutePath(_destinationPath)) _destinationPath = workspace.FileSystem.PathToAbsolute(_destinationPath);

        try
        {
            workspace.FileSystem.Copy(_sourcePath, _destinationPath);
        }
        catch (Exception e) when (e is IOException)
        {
            return new ResultType(e.Message, Result.Failure);
        }

        return new ResultType(Result.Success);
    }

    public bool Equals(FileCopyCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(_sourcePath, other._sourcePath, StringComparison.OrdinalIgnoreCase) &&
               string.Equals(_destinationPath, other._destinationPath, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((FileCopyCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType());
    }
}