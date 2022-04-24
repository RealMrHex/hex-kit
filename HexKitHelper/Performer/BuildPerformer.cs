using HexKitHelper.Application;
using HexKitHelper.Core;
using HexKitHelper.Entity;
using HexKitHelper.Executor;
using HexKitHelper.Processor;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Performer
{
    class BuildPerformer
    {
        static bool existingProject = false;
        public static void RUN()
        {
            promptToBuild();
        }


        static void promptToBuild()
        {
            if (!AnsiConsole.Confirm("[indianred1]Are you sure[/] for building project?"))
                return;

            initProjectStatus();
        }

        static void initProjectStatus()
        {
            AnsiConsole.WriteLine();
            existingProject = AnsiConsole.Confirm("Is it an [indianred1 underline]EXISTING[/] project?");

            Console.WriteLine();
            Bridge.Rule("Setup");

            if (existingProject)
                fetchProjectPath();
            else
                applyNewProject();
        }

        static void fetchProjectPath()
        {
            Bridge.Write("[indianred1]We strongly warn you that using this tool on an existing project may cause unexpected errors![/]");
            Console.WriteLine();

            Bridge.Write("Please [underline skyblue1]TYPE[/] your [gold1]PROJECT PATH[/] or [underline skyblue1]Drag & Drop[/] your [gold1]PROJECT Directory[/]!");

        GetPath:
            AnsiConsole.WriteLine();
            string path = AnsiConsole.Ask<string>("PATH >>> ");

            path = path.Replace("\"", "");

            if (CMD.IsPathExists(path))
            {
                if (!CMD.IsDirectoryEmpty(path))
                {
                    if (CMD.IsLaravelProject(path))
                    {
                        if (path.EndsWith("/") || path.EndsWith(@"\"))
                            path = path.Remove(path.Length - 1, 1);

                        HexStorage.PROJECT_PATH = path;
                        build();
                    }
                    else
                    {
                        Bridge.Write("[indianred1]503 Err >>> Only laravel projects are acceptable.[/]");
                        goto GetPath;
                    }
                }
                else
                {
                    Bridge.Write("[indianred1]403 Err >>> Path is not a project.[/]");
                    goto GetPath;
                }
            }
            else
            {
                Bridge.Write("[indianred1]404 Err >>> Path not found.[/]");
                goto GetPath;
            }
        }

        static void applyNewProject()
        {
            Bridge.Write("Please [underline skyblue1]TYPE[/] your [gold1]PROJECT PATH[/] or [underline skyblue1]Drag & Drop[/] your [gold1]PROJECT Directory[/]!");

        GetPath:
            AnsiConsole.WriteLine();
            string path = AnsiConsole.Ask<string>("PATH >>> ");
            path = path.Replace("\"", "");

            if (CMD.IsPathExists(path))
            {
                if (path.EndsWith("/") || path.EndsWith(@"\"))
                    path = path.Remove(path.Length - 1, 1);

                HexStorage.ROOT_PATH = path;
                Bridge.Write("[greenyellow]Well Done![/]");
                AnsiConsole.WriteLine();

                promptForNewName();
            }
            else
            {
                Bridge.Write("[indianred1]404 Err >>> Path not found.[/]");
                goto GetPath;
            }
        }

        static void promptForNewName()
        {
            Bridge.Write("Type a name for your project!");
            string name;
            string tmpPath;
            for (; ; )
            {
                AnsiConsole.WriteLine();
                name = AnsiConsole.Ask<string>("Name >>> ");
                tmpPath = HexStorage.ROOT_PATH + "\\" + name;
                if (!CMD.IsPathExists(tmpPath) || CMD.IsDirectoryEmpty(tmpPath))
                {
                    break;
                }
                Bridge.Write("[indianred1]403 Err >>> There is a directory with this name![/]");
            }
            HexStorage.PROJECT_NAME = name;
            HexStorage.PROJECT_PATH = tmpPath;
            BuildPerformer.build();
        }

        private static void build()
        {
            Console.Clear();
            Bridge.Banner("HEX Kit");
            AnsiConsole.WriteLine();
            if (BuildPerformer.existingProject)
            {
                Bridge.Rule("Installing Packages");
            }
            else
            {
                Bridge.Rule("Creating New Project");
            }
            Bridge.Write("[greenyellow]Great[/], We are goin to build something [red1]AMAZING[/] FOR YOU!");
            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Markup("[rapidblink indianred1]Please wait until we serve the project for you![/]", null));
            AnsiConsole.WriteLine();
            if (!BuildPerformer.existingProject)
            {
                AnsiConsole.WriteLine();
                Bridge.Write("[skyblue1]Creating new project[/]");
                new NewProjectProcessor().install();
            }
            if (!BuildPerformer.existingProject)
            {
                Bridge.Rule("Installing Packages");
            }
            foreach (Package package in HexStorage.PACKAGES)
            {
                if (package.Install || package.Publish || package.Configure)
                {
                    Bridge.Write($"[skyblue1]Working on[/] [greenyellow]{package.Name}[/] [skyblue1]>>>[/] " +
                        $"[salmon1]{package.Vendor}[/] [skyblue1]FROM[/] [gold1]{package.Srource.Value}[/]");
                }

                if (package.Install && package.CanInstall)
                {
                    Bridge.Write("[rapidblink skyblue1]Installing...[/]");
                    package.Processor.install();
                }

                if (package.Publish && package.CanPublish)
                {
                    Bridge.Write("[rapidblink skyblue1]Publishing...[/]");
                    package.Processor.publish();
                }

                if (package.Configure && package.CanConfigure)
                {
                    Bridge.Write("[rapidblink skyblue1]Configuring...[/]");
                    package.Processor.configure();
                }
            }

            AnsiConsole.WriteLine();
            Bridge.Banner("HEX Kit");
            AnsiConsole.WriteLine();
            Bridge.Rule("Result");
            Bridge.Write("[skyblue1]Rocket launched, Serving your project...[/]");
            CMD.Serve();
            Bridge.OpenBrowser("http://localhost:8000");
            Bridge.OpenBrowser("https://github.com/RealMrHex/hex-kit");
            Bridge.Write("[skyblue1]Browse : [/][greenyellow]http://localhost:8000[/]");
            AnsiConsole.WriteLine();
            Bridge.Write("[gold1]Star me on GitHub[/]");
            AnsiConsole.WriteLine();
            Bridge.Write("[skyblue1]Press any key to see the menu![/]");
            Console.ReadKey();
        }

    }
}