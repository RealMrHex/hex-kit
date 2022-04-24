using HexKitHelper.Application;
using HexKitHelper.Executor;
using HexKitHelper.Interface;

namespace HexKitHelper.Processor
{
    class AlexusmaiLaravelFileManagerProcessor : IProcessor
    {
        public void configure(){}

        public void install()
        {
            string installCommand = "composer require alexusmai/laravel-file-manager";
            CMD.ExecuteInProject(installCommand);
        }

        public void publish()
        {
            string configCommand = "php artisan vendor:publish --tag=fm-config";
            string assetsCommand = "php artisan vendor:publish --tag=fm-assets";

            Bridge.Write("[greenyellow]    * Configs...[/]");
            CMD.ExecuteInProject(configCommand);

            Bridge.Write("[greenyellow]    * Assets...[/]");
            CMD.ExecuteInProject(assetsCommand);
        }
    }
}
