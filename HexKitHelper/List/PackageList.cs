using HexKitHelper.Core;
using HexKitHelper.Entity;
using HexKitHelper.Enum;
using HexKitHelper.Processor;
using System.Collections.Generic;

namespace HexKitHelper.List
{
    class PackageList
    {
        private static List<Package> _packages;

        private static void _init()
        {
            _packages = new List<Package>()
            {
                new Package("TailwindCSS", "tailwindcss", PackageType.FrontEndPackage, PackageSource.NPM, new TailwindCssProcessor()),
                new Package("AlpineJS", "alpinejs", PackageType.FrontEndPackage, PackageSource.NPM, new NPMProcessor("alpinejs"), false, false, false, true, false, false),
                new Package("Verta JDate", "hekmatinasser/verta", PackageType.BackEndPackage, PackageSource.Composer, new ComposerProcessor("hekmatinasser/verta"), false, false, false, true, false, false),
                new Package("Morilog JDate V3", "morilog/jalali:3.*", PackageType.BackEndPackage, PackageSource.Composer, new ComposerProcessor("morilog/jalali:3.*"), false, false, false, true, false, false),
                new Package("Morilog JDate V2", "morilog/jalali", PackageType.BackEndPackage, PackageSource.Composer, new ComposerProcessor("morilog/jalali"), false, false, false, true, false, false),
                new Package("Spatie Laravel Permission", "spatie/laravel-permission", PackageType.BackEndPackage, PackageSource.Composer, new SpatieLaravelPermissionProcessor()),
                new Package("Nwidart Laravel Modules", "nwidart/laravel-modules", PackageType.BackEndPackage, PackageSource.Composer, new NwidartLaravelModulesProcessor()),
                new Package("Livewire", "livewire/livewire", PackageType.BackEndPackage , PackageSource.Composer, new LivewireProcessor()),
                new Package("Livewire Modular", "mhmiton/laravel-modules-livewire", PackageType.BackEndPackage, PackageSource.Composer, new LivewireModularProcessor()),
                new Package("AlexusMai Laravel File Manager", "alexusmai/laravel-file-manager", PackageType.BackEndPackage, PackageSource.Composer, new AlexusmaiLaravelFileManagerProcessor()),
                new Package("Shetabit Payment", "shetabit/payment", PackageType.BackEndPackage, PackageSource.Composer, new ShetabitPaymentProcessor()),
                new Package("Telescope Production Ver.", "laravel/telescope", PackageType.BackEndPackage, PackageSource.Composer, new TelescopeProcessor(false)),
                new Package("Telescope Developer  Ver.", "laravel/telescope --dev", PackageType.BackEndPackage, PackageSource.Composer, new TelescopeProcessor()),
                new Package("Laravel Debugbar", "barryvdh/laravel-debugbar --dev", PackageType.BackEndPackage, PackageSource.Composer, new LaravelDebugbarProcessor()),
                new Package("MaatWebsite Excel", "maatwebsite/excel", PackageType.BackEndPackage, PackageSource.Composer, new LaravelDebugbarProcessor()),
            };
        }

        public static void dispatch()
        {
            _init();

            HexStorage.PACKAGES = _packages;
        }
    }
}
