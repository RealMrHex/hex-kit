using HexKitHelper.Executor;
using HexKitHelper.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Processor
{
    class LivewireModularProcessor: IProcessor
    {
        public void configure()
        {
        }

        public void install()
        {
            CMD.ExecuteInProject("composer require mhmiton/laravel-modules-livewire");
        }

        public void publish()
        {
            CMD.ExecuteInProject("php artisan vendor:publish --tag=modules-livewire-config");
        }
    }
}
