using ConsoleUI;
using eie.App;
using System;

namespace eie.Commands.Custom
{
    class OpenScriptCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public OpenScriptCommand()
        {
            Name = "open";
            Description = "[task_name]: open script file";
        }

        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Shell.PrintErrorMessage("Argument don't recieved!");
                return;
            }

            if (AppInfo.OpenedVariant != null)
            {
                string task = args[1];
                string path = AppInfo.GetMainDir() + "\\" + AppInfo.OpenedVariant + "\\" + task + "\\" + task + ".py";
                try
                {
                    System.Diagnostics.Process.Start(AppInfo.GetEditorPath(), path);
                }
                catch (Exception e)
                {
                    Shell.PrintErrorMessage("Error: " + e.Message);
                }

            }
            else
            {
                Shell.PrintErrorMessage("Select variant!");
            }
        }
    }
}
