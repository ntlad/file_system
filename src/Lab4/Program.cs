using Itmo.ObjectOrientedProgramming.Lab4.ArgParser;
using Itmo.ObjectOrientedProgramming.Lab4.ArgParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var workspace = new Workspace();
        IFileSystem fileSystem = FileSystemCreator.Create("D:\\ychimsya\\oop\\ntlad\\src\\Lab4\\FileSystemStructure", FileSystemMode.Local);
        workspace.FileSystem = fileSystem;

        var handler = new TreeListArgumentHandler();
        var parser = new Parser(handler);

        ICommand? command = parser.Parse("tree list -d 3") ?? throw new ArgumentException("Invalid command");

        ResultType result = command.Execute(workspace);

        var printer = new ConsolePrinter();
        if (result.Result is Result.Success)
        {
            printer.Print("Success!");
            return;
        }

        printer.Print(result.Message);
    }
}