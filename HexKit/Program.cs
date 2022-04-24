using HexKitHelper.Core;
using System;

namespace HexKit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Hex-Kit | Next Generation of laravel starter kits.";
            Console.SetWindowSize(Console.LargestWindowWidth - 80, Console.LargestWindowHeight - 20);
            HexEngine.Fly();
        }
    }
}
