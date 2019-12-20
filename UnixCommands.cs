using System;

namespace UNIX_COMMANDS {
	internal class UnixCommands {
		private static void Main(string[] args) {
			var commandPool = CommandPool.GetInstance();

			while (true) {
				var userInput = Console.ReadLine().Trim().Split();

				var inputCommandName = userInput[0];

				var arguments = new string[userInput.Length - 1];
				Array.Copy(userInput, 1, arguments, 0, userInput.Length - 1);

				var currentCommand = commandPool.FindCommand(inputCommandName);

				if (currentCommand == null)
					Console.WriteLine("There are no such commands!");
				else
					currentCommand.Execute(arguments);
			}
		}
	}
}