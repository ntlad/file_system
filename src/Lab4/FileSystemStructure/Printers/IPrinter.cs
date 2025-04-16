namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Printers;

public interface IPrinter
{
    void Print(string text);

    public void PrintWithoutBreak(string text);
}