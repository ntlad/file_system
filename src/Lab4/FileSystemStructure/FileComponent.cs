using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public class FileComponent(string name) : IFileSystemComponent
{
    public string Name { get; } = name;

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}