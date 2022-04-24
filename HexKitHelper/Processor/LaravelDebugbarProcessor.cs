using HexKitHelper.Executor;
using HexKitHelper.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Processor
{
    class LaravelDebugbarProcessor: IProcessor
    {
        public void configure()
        {
        }

        public void install()
        {
            CMD.ExecuteInProject("composer require barryvdh/laravel-debugbar --dev");
        }

        public void publish()
        {
            string provider = "Barryvdh\\Debugbar\\ServiceProvider";
            CMD.ExecuteInProject("php artisan vendor:publish --provider=\"" + provider + "\"");
        }
    }
}
