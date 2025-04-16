namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class LocalFileSystem(string addressee) : IFileSystem
{
    public string RootAddressee { get; set; } = addressee;

    public string CurrentDirectory { get; set; } = addressee;

    public bool IsAbsolutePath(string path) => Path.IsPathRooted(path);

    string IFileSystem.PathToAbsolute(string path)
    {
        return path.StartsWith(RootAddressee, StringComparison.Ordinal) ? path : RootAddressee + path;
    }

    public string CombineWithCurrentDirectory(string name)
    {
        return Path.Combine(CurrentDirectory, "\\", name);
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
        var directoryInfo = new DirectoryInfo(CurrentDirectory);

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

        var directoryInfo = new DirectoryInfo(CurrentDirectory);
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