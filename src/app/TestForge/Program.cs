// See https://aka.ms/new-console-template for more information

using TestForge.Console;
using TestForge.Core;
using TestForge.InteractiveConsole;

Console.WriteLine("Hello, World!");

IForgeConsole? forgeConsole = null;

if (args.Length == 0 || args[0] == "i")
{
    forgeConsole = new InteractiveForgeConsole(args);
}
else
{
    forgeConsole = new ForgeConsole(args);
}

forgeConsole.Start();
