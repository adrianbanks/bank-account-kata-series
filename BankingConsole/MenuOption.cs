using System;

namespace BankingConsole
{
    internal class MenuOption
    {
        public ConsoleKey ActivatingKey { get; }

        public string Description { get; }

        public IMenuAction Action { get; }

        public MenuOption(ConsoleKey activatingKey, string description, IMenuAction action)
        {
            Action = action;
            ActivatingKey = activatingKey;
            Description = description;
        }

        public void Print()
        {
            Console.WriteLine("  {0}. {1}", ActivatingKey, Description);
        }
    }
}