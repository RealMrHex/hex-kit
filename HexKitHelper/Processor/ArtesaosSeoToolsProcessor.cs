using HexKitHelper.Application;
using HexKitHelper.Executor;
using HexKitHelper.Interface;

namespace HexKitHelper.Processor
{
    class ArtesaosSeoToolsProcessor : IProcessor
    {
        public void configure(){}

        public void install()
        {
            string installCommand = "composer require artesaos/seotools";
            CMD.ExecuteInProject(installCommand);
        }

        public void publish()
        {
            string provider = @"Artesaos\SEOTools\Providers\SEOToolsServiceProvider";
            string publishCommand = $"php artisan vendor:publish --provider=\"{provider}\"";
            CMD.ExecuteInProject(publishCommand);
        }
    }
}
