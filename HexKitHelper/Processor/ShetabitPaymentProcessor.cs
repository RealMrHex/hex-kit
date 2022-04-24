using HexKitHelper.Application;
using HexKitHelper.Executor;
using HexKitHelper.Interface;

namespace HexKitHelper.Processor
{
    class ShetabitPaymentProcessor: IProcessor
    {
        public void configure(){}

        public void install()
        {
            string installCommand = "composer require shetabit/payment";
            CMD.ExecuteInProject(installCommand);
        }

        public void publish()
        {
            string provider = @"Shetabit\Payment\Provider\PaymentServiceProvider";
            string publishCommand = $"php artisan vendor:publish --provider=\"{provider}\"";
            CMD.ExecuteInProject(publishCommand);
        }
    }
}
