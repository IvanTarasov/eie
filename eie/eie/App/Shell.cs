using ConsoleUI.Commands;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    static class Shell
    {
        public static List<ICommand> Commands { get; private set; }
        public static string WorkStatus { get; set; }

        public const string ACTIVE = "ACTIVE";
        public const string DISABLE = "DISABLE";

        public static void Start()
        {
            WorkStatus = ACTIVE;
            InitCommands();
            StartGettingCommands();
        }

        private static void InitCommands()
        {
            Commands = new List<ICommand>();

            Commands.Add(new HelpCommand());
            Commands.Add(new OutCommand());
            // add new commands here
        }

        private static void StartGettingCommands()
        {
            while (WorkStatus == ACTIVE)
            {
                string commandEntered = GetCommand();
                bool commandIsFound = false;

                foreach (var command in Commands)
                    if (commandEntered == command.Name)
                    {
                        commandIsFound = true;
                        command.Execute();
                    }

                if (!commandIsFound)
                    Console.WriteLine("COMMAND NOT FOUND!");
            }
        }

        private static string GetCommand()
        {
            Console.Write(">>> ");
            string command = Console.ReadLine();

            return command;
        }

        public static string GetData(string dataType)
        {
            Console.Write(dataType.ToUpper() + ": ");
            string data = Console.ReadLine();

            return data;
        }
    }
}
