namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemManager;

public class LocalFileSystemManager(LocalFileSystem fileSystem) : IFileSystemManager
{
    private LocalFileSystem FileSystem { get; set; } = fileSystem;

    public bool IsAbsolutePath(string path) => Path.IsPathRooted(path);

    string IFileSystemManager.PathToAbsolute(string path)
    {
        return path.StartsWith(FileSystem.RootAddressee, StringComparison.Ordinal) ? path : FileSystem.RootAddressee + path;
    }

    public string CombineWithCurrentDirectory(string name)
    {
        return Path.Combine(FileSystem.CurrentDirectory, "\\", name);
    }

    public string ReadAllText(string path)
    {
        return File.ReadAllText(path);
    }

    public void Move(string source, string destination)
    {
        var fileInfo = new FileInfo(source);
        fileInfo.MoveTo(Path.Combine(destination, fileInfo.Name));
    }

    public bool Rename(string source, string name)
    {
        var directoryInfo = new DirectoryInfo(FileSystem.CurrentDirectory);

        foreach (FileInfo file in directoryInfo.GetFiles())
        {
            if (file.FullName == source)
            {
                file.MoveTo(CombineWithCurrentDirectory(name));
                return true;
            }
        }

        return false;
    }

    public void Copy(string source, string destination)
    {
        var fileInfo = new FileInfo(source);
        fileInfo.CopyTo(Combine(destination, fileInfo.Name));
    }

    public bool Delete(string source)
    {
        if (IsAbsolutePath(source))
        {
            var fileInfo = new FileInfo(source);
            fileInfo.Delete();

            return true;
        }

        var directoryInfo = new DirectoryInfo(FileSystem.CurrentDirectory);
        foreach (FileInfo file in directoryInfo.GetFiles())
        {
            if (file.FullName == CombineWithCurrentDirectory(source))
            {
                file.Delete();
                return true;
            }
        }

        return false;
    }

    public bool Exists(string directory)
    {
        throw new NotImplementedException();
    }

    public string Combine(string source, string destination)
    {
        return Path.Combine(source, destination);
    }
}