using HexKitHelper.Application;
using HexKitHelper.Executor;
using HexKitHelper.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Processor
{
    class LivewireProcessor:IProcessor
    {
        public void configure()
        {
        }

        public void install()
        {
            CMD.ExecuteInProject("composer require livewire/livewire");
        }

        public void publish()
        {
            string command = "php artisan livewire:publish --config";
            string assetsCommand = "php artisan livewire:publish --assets";

            Bridge.Write("[greenyellow]    * Configs...[/]");
            CMD.ExecuteInProject(command);

            Bridge.Write("[greenyellow]    * Assets...[/]");
            CMD.ExecuteInProject(assetsCommand);
        }
    }
}
