using HexKitHelper.Application;
using HexKitHelper.List;

namespace HexKitHelper.Core
{
    public class HexEngine
    {
        /// <summary>
        /// Start HexKit
        /// </summary>
        public static void Fly()
        {
            ListInitializer.run();

            new Kit();
        }
    }
}
