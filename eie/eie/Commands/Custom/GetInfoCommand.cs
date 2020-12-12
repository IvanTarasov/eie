using ConsoleUI;
using eie.App;
using System;
using System.IO;

namespace eie.Commands.Custom
{
    class GetInfoCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public GetInfoCommand()
        {
            Name = "info";
            Description = ": get application info";
        }

        public void Execute(string[] args)
        {
            try
            {
                Console.WriteLine("Main directory: " + AppInfo.GetMainDir());
                Console.WriteLine("Opened variant: " + AppInfo.OpenedVariant);
                Console.WriteLine("Number of variants: " + GetNumberOfVariants());
            }
            catch (Exception e)
            {
                Shell.PrintErrorMessage("ERROR: " + e.Message);
            }
        }

        private int GetNumberOfVariants()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(AppInfo.GetMainDir());
            return dirInfo.GetDirectories().Length;
        }
    }
}
