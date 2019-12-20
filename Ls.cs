using System;

namespace UNIX_COMMANDS {
	public class Ls : Command {
		public override string Name => "ls";

		public override void Execute(string[] arguments) {
			if (arguments.Length == 0)
				Console.WriteLine("ls outputs current directory");
			else
				Console.WriteLine($"ls does something according to arguments. Arguments: {{{string.Join(", ", arguments)}}}");
		}
	}
}