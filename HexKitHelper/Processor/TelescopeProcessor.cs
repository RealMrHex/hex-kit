using HexKitHelper.Application;
using HexKitHelper.Executor;
using HexKitHelper.Interface;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Processor
{
    class TelescopeProcessor : IProcessor
    {
        bool isLocal = true;

        public TelescopeProcessor(bool isLocal = true)
        {
            this.isLocal = isLocal;
        }

        public void configure() {}

        public void install()
        {
            string installCommand = "composer require laravel/telescope" + (isLocal ? " --dev" : "");
            CMD.ExecuteInProject(installCommand);
        }

        public void publish()
        {

            string configCommand = "php artisan telescope:install";

            Bridge.Write("[greenyellow]    * Assets...[/]");
            CMD.ExecuteInProject(configCommand);
        }
    }
}
