using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Printers;

public class PrinterCreator
{
    public static IPrinter Create(FileShowMode mode)
    {
        if (mode == FileShowMode.Console)
        {
            return new ConsolePrinter();
        }

        return new ConsolePrinter();
    }
}