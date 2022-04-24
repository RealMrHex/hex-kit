using HexKitHelper.Entity;
using Spectre.Console;
using System.Collections.Generic;

namespace HexKitHelper.Core
{
    class HexStorage
    {
        public static List<Package> PACKAGES = new List<Package>();

        public static Table PACKAGES_TABLE;

        public static List<string> PACKAGES_CHOICES = new List<string>();

        public static List<string> ACTIONS_LIST = new List<string>();

        public static List<string> PACKAGES_CONFIG_CHOICES = new List<string>();

        public static string USER_CHOICE;

        public static string PROJECT_NAME;

        public static string PROJECT_PATH;

        public static string ROOT_PATH;
    }
}
