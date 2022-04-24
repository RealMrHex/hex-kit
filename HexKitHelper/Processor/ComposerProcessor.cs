using HexKitHelper.Executor;
using HexKitHelper.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Processor
{
    class ComposerProcessor : IProcessor
    {
        private string vendor;

        public ComposerProcessor(string vendor) { this.vendor = vendor; }

        public void install() { CMD.ExecuteInProject($"composer require {vendor}"); }

        public void configure() { }

        public void publish() { }
    }
}
