using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace VarletCli
{
        [Command("containers", Description = "Manage containers"),
         Subcommand(typeof(List)),
         Subcommand(typeof(Run))]
        public class CmdSiteManager
        {
            private int OnExecute(IConsole console)
            {
                console.Error.WriteLine("You must specify an action. See --help for more details.");
                return 1;
            }

            [Command(Description = "List containers"), HelpOption]
            private class List
            {
                [Option(Description = "Show all containers (default shows just running)")]
                public bool All { get; }

                private void OnExecute(IConsole console)
                {
                    console.WriteLine(string.Join("\n",
                        "CONTAINERS",
                        "----------------",
                        "jubilant_jackson",
                        "lucid_torvalds"));
                }
            }

            [Command("run", Description = "Run a command in a new container", AllowArgumentSeparator = true, ThrowOnUnexpectedArgument = false)]
            private class Run
            {
                [Required(ErrorMessage = "You must specify the image name")]
                [Argument(0, Description = "The image for the new container")]
                public string Image { get; }

                [Option("--name", Description = "Assign a name to the container")]
                public string Name { get; }

                /// <summary>
                /// When ThrowOnUnexpectedArgument is valids, any unrecognized arguments
                /// will be collected and set in this property, when set.
                /// </summary>
                public string[] RemainingArguments { get; }

                private void OnExecute(IConsole console)
                {
                    console.WriteLine(
                        $"Would have run {Image} (name = {Name}) with args => {ArgumentEscaper.EscapeAndConcatenate(RemainingArguments)}");
                }
            }
        }
}
