using System;
using System.Collections.Generic;

namespace UNIX_COMMANDS {
	public class CommandPool {
		private static CommandPool   instance;
		public         List<Command> Commands;

		private CommandPool() {
			Commands = new List<Command>();

			InitializeCommands();

			instance = this;
		}

		private void InitializeCommands() {
			//For each assembly
			Array.ForEach(AppDomain.CurrentDomain.GetAssemblies(),
			              assembly => {
				              //Get all types that derive from Command and are not abstract
				              var commandTypes = Array.FindAll(assembly.GetTypes(),
				                                               type => type.IsSubclassOf(typeof(Command)) &&
				                                                       !type.IsAbstract);

				              //Add their instance from the parameterless constructor to the pool
				              Array.ForEach(commandTypes,
				                            type => {
					                            Commands.Add((Command) type
					                                                  .GetConstructor(Type.EmptyTypes)
					                                                  .Invoke(Type.EmptyTypes));
				                            });
			              });
		}

		public void AddCommand(Command command) {
			Commands.Add(command);
		}

		public bool CommandExists(string commandName) {
			return Commands.Exists(command => command.Name == commandName);
		}

		public Command FindCommand(string commandName) {
			//Consider throwing exception if null maybe??

			return Commands.Find(command => { return command.Name == commandName; });
		}

		public static CommandPool GetInstance() {
			if (instance != null) return instance;

			return new CommandPool();
		}
	}
}