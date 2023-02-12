using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForge.InteractiveConsole
{
    class StringChooser
    {
        public static string PromptForChoice(string[] options)
        {
            var result = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Which to work with?")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                        .AddChoices(options));

            return result;
        }
    }
}
