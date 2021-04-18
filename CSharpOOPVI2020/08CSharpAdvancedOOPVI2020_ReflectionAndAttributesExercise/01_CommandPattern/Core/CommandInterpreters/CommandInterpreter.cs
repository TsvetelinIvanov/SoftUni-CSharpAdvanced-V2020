using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.CommandInterpreters
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandLine = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandLine[0] + "Command";            
            string[] arguments = commandLine.Skip(1).ToArray();

            Type commandType = Assembly.GetCallingAssembly().GetTypes().Where(t => typeof(ICommand).IsAssignableFrom(t) && t.IsClass).FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());     
            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            ICommand command = (ICommand)Activator.CreateInstance(commandType);
            string result = command.Execute(arguments);

            return result;
        }
    }
}