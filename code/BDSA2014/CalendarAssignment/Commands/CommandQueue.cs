using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAssignment.Commands
{
    class CommandQueue
    {
        private List<ICommand> _commands = new List<ICommand>();
        private int _currentCommand;

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public ICommand RemoveCommand()
        {
            var lastCommand = _commands.Last();
            _commands.Remove(lastCommand);
            return lastCommand;
        }

        /// <summary>
        /// Executes the command, currently at.
        /// </summary>
        /// <returns>Return true, if nothing went wrong and there are still commands left. Returns false if nothing went wrong, but no more commands are left. Throws an ApplicationException, if something went wrong.</returns>
        public bool Execute()
        {
            var success = _commands[_currentCommand].Execute();
            if (success)
            {
                _currentCommand++;
                return _currentCommand < _commands.Count;
            }
            _currentCommand--;
            throw new ApplicationException("Command: " + _commands[_currentCommand] + " could not execute!");
        }

        public bool Undo()
        {
            var success = _commands[_currentCommand].Undo();
            if (success)
            {
                _currentCommand--;
                return _currentCommand >= 0;
            }
            throw new ApplicationException("Command: " + _commands[_currentCommand] + " could not undo!");
        }

    }
}
