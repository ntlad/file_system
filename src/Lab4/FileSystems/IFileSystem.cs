namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    public string RootAddressee { get; set; }

    public string CurrentDirectory { get; set; }

    public string PathToAbsolute(string path);

    public bool IsAbsolutePath(string path);

    public string CombineWithCurrentDirectory(string name);

    public string Combine(string source, string destination);

    public string ReadAllText(string path);

    public void Move(string source, string destination);

    public bool Rename(string source, string name);

    public void Copy(string source, string destination);

    public bool Delete(string source);

    public bool Exists(string directory);
}