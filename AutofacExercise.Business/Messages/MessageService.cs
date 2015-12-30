using System;
using System.Collections.Generic;
using AutofacExercise.Business.Interfaces;

namespace AutofacExercise.Business.Messages
{
    public class MessageService : IMessageService
    {

        public MessageService()
        {
            SetupMessages();
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

        public string GetMessage()
        {
            var random = new Random();
            var index = random.Next(0, _messages.Count - 1);

            return _messages[index];
        }
    }
}