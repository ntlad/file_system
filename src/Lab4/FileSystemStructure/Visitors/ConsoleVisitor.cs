using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Visitors;

public class ConsoleVisitor(int depth) : IFileSystemComponentVisitor
{
    private readonly ConsolePrinter _consolePrinter = new ConsolePrinter();

    private int _depth;

    public void Visit(FileComponent component)
    {
        WriteWithIndentation(component.Name);
    }

    public void Visit(DirectoryComponent component)
    {
        WriteWithIndentation(component.Name);

        if (_depth >= depth) return;

        ++_depth;

        foreach (IFileSystemComponent currentComponent in component.Components)
        {
            currentComponent.Accept(this);
        }

        --_depth;
    }

    private void WriteWithIndentation(string name)
    {
        if (_depth != 0)
        {
            _consolePrinter.PrintWithoutBreak(string.Concat(Enumerable.Repeat("   ", _depth)));
            _consolePrinter.PrintWithoutBreak("|–> ");
        }

        _consolePrinter.Print(name);
    }
}