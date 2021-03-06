﻿using ConsoleUI;
using eie.App;
using System;

namespace eie.Commands.Custom
{
    class ChangeEditorCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ChangeEditorCommand()
        {
            Name = "newedit";
            Description = "[fullpath_to_editor]: change custom code-editor";
        }

        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Shell.PrintErrorMessage("Path to editor don't recieved!");
                return;
            }

            string path = args[1];
            try
            {
                ConfigFile config = new ConfigFile();
                config.MainDir = AppInfo.GetMainDir();
                config.EditorPath = path;
                config.Save();

                Shell.PrintSuccessMessage("New editor in '" + path + "'!");
            }
            catch (Exception e)
            {
                Shell.PrintErrorMessage(e.Message);
            }
        }
    }
}
