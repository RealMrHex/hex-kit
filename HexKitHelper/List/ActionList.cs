using HexKitHelper.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.List
{
    class ActionList
    {
        private static List<string> _actions;

        private static void _init()
        {
            _actions = new List<string>()
            {
                "Build", "Reset", "About", "Exit"
            };
        }

        public static void dispatch()
        {
            _init();

            HexStorage.ACTIONS_LIST = _actions;
        }
    }
}
