using HexKitHelper.Application;
using HexKitHelper.Core;
using HexKitHelper.Executor;
using HexKitHelper.Interface;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Processor
{
    class NewProjectProcessor : IProcessor
    {
        public void configure()
        {
        }

        public void install()
        {
            CMD.RUN("cd " + HexStorage.ROOT_PATH + " && composer create-project laravel/laravel " + HexStorage.PROJECT_NAME);
            AnsiConsole.WriteLine();
            Bridge.Write("[greenyellow]Laravel Installed Successfully![/]");
            AnsiConsole.WriteLine();
        }

        public void publish()
        {
        }
    }
}
