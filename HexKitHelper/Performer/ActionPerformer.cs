using HexKitHelper.Application;
using HexKitHelper.Core;
using HexKitHelper.List;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Performer
{
    class ActionPerformer
    {
        public static void RUN()
        {
            switch(HexStorage.USER_CHOICE.ToLower())
            {
                case "build":
                    BuildPerformer.RUN();
                    break;
                case "reset":
                    ListInitializer.run();
                    break;
                case "about":
                    about();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    return;
            }
        }

        private static void about()
        {
            Bridge.OpenBrowser("https://t.me/LogCats");
            Bridge.Banner("Mr Hex");
            AnsiConsole.Write(new Markup("Made with [red1]LOVE[/] & [green1]COFFEE[/] By [salmon1]Armin Hooshmand[/] A.K.A [salmon1]MrHex[/]", null));
            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Markup("Contact me on [skyblue1]Telegram[/] >>> t.me/LogCats", null));
            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Markup("[dim]Press any key to return back to the menu![/]", null));
            Console.ReadKey();
        }
    }
}
