namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Visitors;

public interface IFileSystemComponentVisitor
{
    void Visit(FileComponent component);

    void Visit(DirectoryComponent component);
}