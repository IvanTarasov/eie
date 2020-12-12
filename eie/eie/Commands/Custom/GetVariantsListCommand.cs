using ConsoleUI;
using eie.App;
using System;
using System.IO;

namespace eie.Commands.Custom
{
    class GetVariantsListCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public GetVariantsListCommand()
        {
            Name = "vars";
            Description = ": get variant list";
        }

        public void Execute(string[] args)
        {
            try
            {
                string path = AppInfo.GetMainDir();
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                var vars = dirInfo.GetDirectories();
                foreach (var variant in vars)
                    Console.WriteLine(variant.Name);
            }
            catch (Exception e)
            {
                Shell.PrintErrorMessage("ERROR: " + e.Message);
            }
            
        }
    }
}
