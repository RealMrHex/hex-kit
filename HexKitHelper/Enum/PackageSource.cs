using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Enum
{
    class PackageSource
    {
        private PackageSource(string value)
        {
            Value = value;
        }

        public string Value
        {
            get;
            private set;
        }

        public static PackageSource Kit
        {
            get
            {
                return new PackageSource("Kit");
            }
        }
        public static PackageSource Composer
        {
            get
            {
                return new PackageSource("Composer");
            }
        }

        public static PackageSource NPM
        {
            get
            {
                return new PackageSource("NPM");
            }
        }
    }
}
