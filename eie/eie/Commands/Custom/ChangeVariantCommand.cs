using ConsoleUI;
using eie.App;
using System;
using System.IO;

namespace eie.Commands.Custom
{
    class ChangeVariantCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ChangeVariantCommand()
        {
            Name = "var";
            Description = "[var_name]: open exist variant";
        }

        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Shell.PrintErrorMessage("Variant name don't recieved!");
                return;
            }

            string varName = args[1];
            try
            {
                DirectoryInfo variant = new DirectoryInfo(AppInfo.GetMainDir() + "\\" + varName);
                if (variant.Exists)
                {
                    AppInfo.ChangeVariant(varName);
                    Shell.PrintSuccessMessage("Variant '" + varName + "' is currently used");
                }
                else Shell.PrintErrorMessage("Variant '" + varName + "' does not exist");
            }
            catch (Exception e)
            {
                Shell.PrintErrorMessage("ERROR: " + e.Message);
            }
        }
    }
}
