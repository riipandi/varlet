using System.IO;
using McMaster.Extensions.CommandLineUtils;
using Variety;
using VarletCli.Handler;

namespace VarletCli
{
    [Command(
        Name = "varlet",
        Description = "Varlet is minimalism web development stack."),
        Subcommand(typeof(CmdVersionHandler), typeof(CmdLinkHandler), typeof(CmdUnlinkHandler))
    ]
    class Program
    {
        public static void Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        private int OnExecute(CommandLineApplication app, IConsole console)
        {
            console.WriteLine("\nYou must specify a subcommand!\n");
            app.ShowHelp();
            return 1;
        }
    }
}
