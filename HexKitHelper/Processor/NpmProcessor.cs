using HexKitHelper.Executor;
using HexKitHelper.Interface;

namespace HexKitHelper.Processor
{
    class NPMProcessor : IProcessor
    {
        private string vendor;

        public NPMProcessor(string vendor) { this.vendor = vendor; }

        public void install() { CMD.ExecuteInProject($"npm install {vendor}"); }

        public void configure() { }

        public void publish() { }
    }
}
