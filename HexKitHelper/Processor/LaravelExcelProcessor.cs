using HexKitHelper.Executor;
using HexKitHelper.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Processor
{
    class LaravelExcelProcessor : IProcessor
    {
        public void configure()
        {
            throw new NotImplementedException();
        }

        public void install()
        {
            CMD.ExecuteInProject("composer require maatwebsite/excel");
        }
        public void publish()
        {
            string provider = "Maatwebsite\\Excel\\ExcelServiceProvider";
            CMD.ExecuteInProject("php artisan vendor:publish --provider=\"" + provider + "\" --tag=config");
        }
    }
}
