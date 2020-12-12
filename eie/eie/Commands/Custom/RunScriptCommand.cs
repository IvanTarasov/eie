using ConsoleUI;
using eie.App;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;

namespace eie.Commands.Custom
{
    class RunScriptCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public RunScriptCommand()
        {
            Name = "run";
            Description = "[task_name]: run task of current variant";
        }

        private ScriptEngine Engine = Python.CreateEngine();

        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Shell.PrintErrorMessage("Argument don't recieved!");
                return;
            }

            if (AppInfo.OpenedVariant != null)
            {
                try
                {
                    string task = args[1];
                    string path = AppInfo.GetMainDir() + "\\" + AppInfo.OpenedVariant + "\\" + task + "\\" + task + ".py";

                    Shell.PrintWarningMessage("[" + path + "]");
                    Engine.ExecuteFile(path);
                    Shell.PrintSuccessMessage("Script '" + task + "' successfully completed!");
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
