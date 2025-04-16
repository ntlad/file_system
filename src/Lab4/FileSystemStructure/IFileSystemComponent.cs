using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public interface IFileSystemComponent
{
    string Name { get; }

    void Accept(IFileSystemComponentVisitor visitor);
}