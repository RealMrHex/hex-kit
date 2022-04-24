using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Interface
{
    interface IProcessor
    {
        void install();

        void publish();

        void configure();
    }
}
