using HexKitHelper.Executor;
using HexKitHelper.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Processor
{
    class TailwindCssProcessor : IProcessor
    {
        public void configure()
        {
            
        }

        public void install()
        {
            string installCommand = "NPM install -D tailwindcss autoprefixer postcss";
            CMD.ExecuteInProject(installCommand);
        }

        public void publish()
        {
            string installCommand = "npx tailwindcss init";
            CMD.ExecuteInProject(installCommand);
        }
    }
}
