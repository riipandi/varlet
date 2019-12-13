using McMaster.Extensions.CommandLineUtils;
using System.Collections.Generic;

namespace VarletCli
{
    [Command("image", Description = "Manage images"), Subcommand(typeof(List))]
    public class CmdCreateApp
    {
        private int OnExecute(IConsole console)
        {
            console.Error.WriteLine("You must specify an action. See --help for more details.");
            return 1;
        }

        [Command("ls", Description = "List images", ThrowOnUnexpectedArgument = false)]
        private class List
        {
            [Option(Description = "Show all containers (default shows just running)")]
            public bool All { get; }

            private IReadOnlyList<string> RemainingArguments { get; }

            private void OnExecute(IConsole console)
            {
                console.WriteLine(string.Join("\n",
                    "IMAGES",
                    "--------------------",
                    "microsoft/dotnet:2.0"));
            }
        }
    }
}
