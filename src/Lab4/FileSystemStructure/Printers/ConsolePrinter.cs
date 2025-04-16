namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Printers;

public class ConsolePrinter : IPrinter
{
    public void PrintWithoutBreak(string text)
    {
        Console.Write(text);
    }

    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}