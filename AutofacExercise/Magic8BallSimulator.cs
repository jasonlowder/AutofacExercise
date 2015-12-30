using System;
using System.Collections.Generic;

namespace AutofacExercise
{
    internal class Magic8BallSimulator
    {

        public Magic8BallSimulator()
        {
            SetupMessages();
        }

        public void Run()
        {
            PrintWelcome();

            PrintInputPrompt();
            GetInput();

            while (!ExitWasRequested())
            {
                GetMessage();
                PrintMessage();
                PrintInputPrompt();
                GetInput();
            }

            PrintExit();
        }

        private List<string> _messages = new List<string>();

        private void SetupMessages()
        {
            _messages = new List<string>() { 
				"Signs point to yes.", 
				"Yes.",
				"Reply hazy, try again.", 
				"Without a doubt.", 
				"My sources say no.", 
				"As I see it, yes.", 
				"You may rely on it.", 
				"Concentrate and ask again.", 
				"Outlook not so good.", 
				"It is decidedly so.", 
				"Better not tell you now.", 
				"Very doubtful.", 
				"Yes - definitely.", 
				"It is certain.", 
				"Cannot predict now.", 
				"Most likely.", 
				"Ask again later.", 
				"My reply is no.", 
				"Outlook good.", 
				"Don't count on it."
			};
        }

        private string _message = string.Empty;

        private void GetMessage()
        {
            var random = new Random();
            var index = random.Next(0, _messages.Count - 1);

            _message = _messages[index];
        }

        private void PrintMessage()
        {
            Console.WriteLine(_message);
        }

        private void PrintInputPrompt()
        {
            Console.Write("Ask a Question, or press [Enter] to exit >> ");
        }

        private string _input = "place-holder input";

        private void GetInput()
        {
            _input = Console.ReadLine();
        }

        private void PrintWelcome()
        {
            Console.WriteLine("Welcome to the Magic 8 Ball simulator");
        }

        private void PrintExit()
        {
            Console.WriteLine("Goodbye");
        }

        private bool ExitWasRequested()
        {
            return string.IsNullOrEmpty(_input);
        }
    }
}