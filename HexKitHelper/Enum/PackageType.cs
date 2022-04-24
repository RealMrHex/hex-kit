using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Enum
{
    class PackageType
    {
        private PackageType(string value)
        {
            Value = value;
        }

        public string Value
        {
            get;
            private set;
        }

        public static PackageType KitAsset
        {
            get
            {
                return new PackageType("Kit Asset");
            }
        }

        public static PackageType FrontEndPackage
        {
            get
            {
                return new PackageType("Front-End Package");
            }
        }

        public static PackageType BackEndPackage {
            get
            {
                return new PackageType("Back-End Package");
            }
        }

        public static PackageType SingleFile
        {
            get
            {
                return new PackageType("Single File");
            }
        }
    }
}
