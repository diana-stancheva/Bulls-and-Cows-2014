namespace BullsAndCows
{
    using System;
    using System.Linq;

    public class Command
    {
        private string commandName;

        private Command(string input)
        {
            this.TranslateInput(input);
        }

        public string CommandName
        {
            get
            {
                return this.commandName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this.commandName = value;
            }
        }

        public static Command Parse(string input)
        {
            return new Command(input);
        }

        private void TranslateInput(string input)
        {
            this.CommandName = input.ToLower();
        }
    }
}