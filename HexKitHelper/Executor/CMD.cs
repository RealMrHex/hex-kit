using HexKitHelper.Application;
using HexKitHelper.Core;
using Spectre.Console;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace HexKitHelper.Executor
{
    class CMD
    {
        public static void RUN(string Command)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + Command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            Process process = Process.Start(processInfo);

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine(e.Data);
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine(e.Data);
            process.BeginErrorReadLine();

            process.WaitForExit();

            process.Close();
        }

        public static void Serve()
        {
            string cmd = $"title Served By Hex Kit && cd {HexStorage.PROJECT_PATH} && " + "php artisan serve";
            var start = Process.Start("CMD.exe", "/c " + $"start cmd.exe @cmd /k \"{cmd}\"");
        }

        public static void ExecuteInProject(string Command)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + $"cd {HexStorage.PROJECT_PATH} && " + Command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            Process process = Process.Start(processInfo);

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine(e.Data);
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine(e.Data);
            process.BeginErrorReadLine();

            process.WaitForExit();

            Bridge.Write("[greenyellow]Task Done![/]");

            process.Close();
        }

        public static bool IsPathExists(string path)
        {
            return Directory.Exists(path);
        }

        public static bool IsLaravelProject(string path)
        {
            if (path.EndsWith("/") || path.EndsWith(@"\"))
                path = path.Remove(path.Length - 1, 1);

            string artisanPath = path + @"\artisan";

            string vendorPath  = path + @"\vendor\laravel";

            return File.Exists(artisanPath) && IsPathExists(vendorPath);
        }

        public static bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
    }
}
