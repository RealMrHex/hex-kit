using HexKitHelper.Application;
using HexKitHelper.Executor;
using HexKitHelper.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Processor
{
    class SpatieLaravelPermissionProcessor : IProcessor
    {
        public void configure(){}

        public void install()
        {
            string installCommand = "composer require spatie/laravel-permission";
            CMD.ExecuteInProject(installCommand);
        }

        public void publish()
        {
            string provider = @"Spatie\Permission\PermissionServiceProvider";
            string publishCommand = $"php artisan vendor:publish --provider=\"{provider}\"";
            CMD.ExecuteInProject(publishCommand);

            Bridge.Write("[skyblue1]    * Optimizing project...[/]");

            CMD.ExecuteInProject("php artisan optimize:clear");
        }
    }
}
