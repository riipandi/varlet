using McMaster.Extensions.CommandLineUtils;
using VarletCli.Handler;

namespace VarletCli
{
    [Command(
        Name = "varlet",
        Description = "Varlet is minimalism web development stack."),
        Subcommand(
            typeof(CmdStartHandler), typeof(CmdStopHandler), typeof(CmdRestartHandler),
            typeof(CmdInstallHandler), typeof(CmdLinkHandler), typeof(CmdUnlinkHandler),
            typeof(CmdShareHandler), typeof(CmdNewHandler), typeof(CmdVersionHandler)
        )
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
