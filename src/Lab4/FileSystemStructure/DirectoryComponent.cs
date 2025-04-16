using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public class DirectoryComponent(string name, IReadOnlyCollection<IFileSystemComponent> components) : IFileSystemComponent
{
    public string Name { get; } = name;

    public IReadOnlyCollection<IFileSystemComponent> Components { get; } = components;

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}