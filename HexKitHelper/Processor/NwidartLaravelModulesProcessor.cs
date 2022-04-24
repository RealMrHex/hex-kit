using HexKitHelper.Executor;
using HexKitHelper.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Processor
{
    class NwidartLaravelModulesProcessor: IProcessor
    {
        public void configure()
        {
        }

        public void install()
        {
            CMD.ExecuteInProject("composer require nwidart/laravel-modules");
        }

        public void publish()
        {
            string provider = "Nwidart\\Modules\\LaravelModulesServiceProvider";
            CMD.ExecuteInProject("php artisan vendor:publish --provider=\"" + provider + "\"");
        }
    }
}
