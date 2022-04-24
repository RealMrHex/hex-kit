using HexKitHelper.Core;
using HexKitHelper.Performer;
using Spectre.Console;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace HexKitHelper.Application
{
    class Bridge
    {
        public static void init()
        {
            Console.Clear();

            //Packages table
            PackagesTablePerformer.RUN();

            //Menu
            MenuPerformer.RUN();
        }

        #region Interface
        public static void Rule(string title, string color = "lightgoldenrod2_1", string lineColor = "lightgoldenrod2_1")
        {
            Rule rule = new Rule($"[{color}]{title}[/]");
            rule.Centered();
            rule.RuleStyle(lineColor);
            AnsiConsole.Write(rule);
            AnsiConsole.WriteLine();
        }

        public static void Table(Table table)
        {
            AnsiConsole.Write(table);
            AnsiConsole.WriteLine();
        }

        public static void MakeMenu()
        {
            MenuPerformer.MakeMenu();
        }

        public static void Write(string text)
        {
            AnsiConsole.Write(new Markup(text));
            AnsiConsole.WriteLine();
        }

        public static void Banner(string text)
        {
            AnsiConsole.Write(new FigletText(text)
                .Centered()
                .Color(Color.GreenYellow));
        }
        #endregion

        public static void HandleCommand()
        {
            if (HexStorage.ACTIONS_LIST.Contains(HexStorage.USER_CHOICE))
                ActionPerformer.RUN();
            else
                PackageConfigPerformer.RUN();

        }

        public static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", "/c start " + url)
                    {
                        CreateNoWindow = true
                    });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else
                {
                    if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        throw;
                    }
                    Process.Start("open", url);
                }
            }
        }
    }
}
