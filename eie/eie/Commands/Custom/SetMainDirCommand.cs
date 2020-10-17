using ConsoleUI;
using eie.App;
using System;
using System.IO;

namespace eie.Commands.Custom
{
    class SetMainDirCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public SetMainDirCommand()
        {
            Name = "smd";
            Description = "[path]: set main directory";
        }

        public void Execute(string[] args) 
        {
            if (args.Length < 2)
            {
                Shell.PrintErrorMessage("Argument don't recieved!");
                return;
            }

            string pathToDir = args[1];
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(pathToDir);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                Directory.CreateDirectory(pathToDir + "\\eie");

                // create config file
                ConfigFile config = new ConfigFile();
                config.MainDir = pathToDir + "\\eie";
                config.Save();

                Shell.PrintSuccessMessage("Now main directory is '" + pathToDir + "\\eie'");
            }
            catch (Exception e)
            {
                Shell.PrintErrorMessage("ERROR: " + e.Message);
            }
        }
    }
}
