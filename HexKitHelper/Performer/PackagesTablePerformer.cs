using HexKitHelper.Core;
using HexKitHelper.Entity;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Performer
{
    class PackagesTablePerformer
    {
        private static bool isOdd;

        public static void RUN()
        {
            initPackagesTable();
            addPackagesToTable();
        }

        private static void initPackagesTable()
        {
            HexStorage.PACKAGES_TABLE = new Table();
            Table packages_TABLE = HexStorage.PACKAGES_TABLE;
            packages_TABLE.RoundedBorder();
            packages_TABLE.AddColumns("Name", "Vendor", "Type", "Source", "Install?", "Publish?");
        }

        private static void addPackagesToTable()
        {
            foreach (Package package in HexStorage.PACKAGES)
            {
                HexStorage.PACKAGES_TABLE.AddRow(
                    GetFormattedText(package.Name, "check"),
                    GetFormattedText(package.Vendor, "check"),
                    GetFormattedText(package.Type.Value, "check"),
                    GetFormattedText(package.Srource.Value, "check"),
                    GetFormattedLogic(package.Install, package.CanInstall),
                    GetFormattedLogic(package.Publish, package.CanPublish)
                 );
                isOdd = !isOdd;
            }
        }

        private static Markup GetFormattedLogic(bool logic, bool can)
        {
            if (!can)
            {
                return new Markup("[navajowhite1]! Off[/]", null);
            }
            if (!logic)
            {
                return new Markup("[indianred1]x No[/]", null);
            }
            return new Markup("[greenyellow]√ Yes[/]", null);
        }

        private static Markup GetFormattedText(string text, string color = "check")
        {
            if (color.Equals("check"))
                color = (isOdd ? "orange1" : "grey93");

            return new Markup($"[{color}]{text}[/]");
        }

        
    }
}
