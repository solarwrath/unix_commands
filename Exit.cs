using System;

namespace UNIX_COMMANDS {
	public class Exit : Command {
		public override string Name => "exit";

		public override void Execute(string[] arguments) {
			Environment.Exit(0);
		}
	}
}