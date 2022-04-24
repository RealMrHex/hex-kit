using HexKitHelper.Core;
using HexKitHelper.Entity;
using Spectre.Console;
using System;

namespace HexKitHelper.Application
{
    class Kit
    {
        public Kit()
        {
            for(; ; )
            {
                Bridge.init();

                Bridge.Rule("Summury");

                Bridge.Table(HexStorage.PACKAGES_TABLE);

                Bridge.Rule("Actions");

                Bridge.MakeMenu();

                Bridge.HandleCommand();
            }
        }
    }
}
