using HexKitHelper.Enum;

namespace HexKitHelper.Entity
{
    class Package
    {
        private string        _name;
        private string        _vendor;
        private PackageType   _type;
        private PackageSource _srource;
        private dynamic       _processor;
        private bool          _install;
        private bool          _publish;
        private bool          _configure;
        private bool          _canInstall;
        private bool          _canPublish;
        private bool          _canConfigure;

        public Package(string name, string vendor, PackageType type, PackageSource srource, dynamic processor, bool install = false, bool publish = false, bool configure = false, bool canInstall = true, bool canPublish = true, bool canConfigure = false)
        {
            this._name = name;
            this._vendor = vendor;
            this._type = type;
            this._srource = srource;
            this._processor = processor;
            this._install = install;
            this._publish = publish;
            this._configure = configure;
            this._canInstall = canInstall;
            this._canPublish = canPublish;
            this._canConfigure = canConfigure;
        }

        public string Name             { get => _name;         set => _name = value;         }
        public string Vendor           { get => _vendor;       set => _vendor = value;       }
        public dynamic Processor       { get => _processor;    set => _processor = value;    }
        public bool Install            { get => _install;      set => _install = value;      }
        public bool Publish            { get => _publish;      set => _publish = value;      }
        public bool Configure          { get => _configure;    set => _configure = value;    }
        public bool CanInstall         { get => _canInstall;   set => _canInstall = value;   }
        public bool CanPublish         { get => _canPublish;   set => _canPublish = value;   }
        public bool CanConfigure       { get => _canConfigure; set => _canConfigure = value; }
        internal PackageType Type      { get => _type;         set => _type = value;         }
        internal PackageSource Srource { get => _srource;      set => _srource = value;      }
    }
}
