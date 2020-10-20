using ConsoleUI.Commands;
using eie.App;
using eie.Commands.Custom;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleUI
{
    static class Shell
    {
        public static List<ICommand> Commands { get; private set; }
        public static bool WorkStatus { get; set; }

        public const bool ACTIVE = true;
        public const bool DISABLE = false;
        private const int COMMAND_NAME = 0;

        public static void Start()
        {
            WorkStatus = ACTIVE;

            PrintWarningMessage("Type 'help' to get a list of available commands");
            AppInfo.InitConfig();
            InitCommands();
            StartGettingCommands();
        }

        private static void InitCommands()
        {
            Commands = new List<ICommand>();

            Commands.Add(new HelpCommand());
            Commands.Add(new OutCommand());
            Commands.Add(new GetInfoCommand());
            Commands.Add(new NewVariantCommand());
            Commands.Add(new ChangeVariantCommand());
            Commands.Add(new OpenScriptCommand());
            Commands.Add(new RunScriptCommand());
            Commands.Add(new GetVariantsListCommand());
            Commands.Add(new SetMainDirCommand());
            Commands.Add(new ChangeEditorCommand());
            // add new commands here
        }

        private static void StartGettingCommands()
        {
            while (WorkStatus == ACTIVE)
            {
                string[] receivedCommand = GetCommand();

                bool commandIsFound = false;

                foreach (var command in Commands)
                    if (receivedCommand[COMMAND_NAME] == command.Name)
                    {
                        commandIsFound = true;
                        command.Execute(receivedCommand);
                    }

                if (!commandIsFound)
                    PrintErrorMessage("COMMAND NOT FOUND!");
            }
        }

        private static string[] GetCommand()
        {
            Console.Write(">>> ");
            return Console.ReadLine().Split(' ', 2);
        }

        public static void PrintSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + message + "\n");
            Console.ResetColor();
        }

        public static void PrintWarningMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + message + "\n");
            Console.ResetColor();
        }

        public static void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + message + "\n");
            Console.ResetColor();
        }
    }
}
