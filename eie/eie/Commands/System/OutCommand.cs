﻿namespace ConsoleUI.Commands
{
    class OutCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public OutCommand()
        {
            Name = "out";
            Description = "close application";
        }

        public void Execute()
        {
            Shell.WorkStatus = Shell.DISABLE;
        }
    }
}
