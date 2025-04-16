using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class FileSystemCreator
{
    public static IFileSystem Create(string addressee, FileSystemMode mode)
    {
        if (mode == FileSystemMode.Local)
        {
            return new LocalFileSystem(addressee);
        }

        return new LocalFileSystem(addressee);
    }
}