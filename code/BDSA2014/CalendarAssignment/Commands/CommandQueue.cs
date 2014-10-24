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
        /**
         * Pre conditions:
         * context CommandQueue::Execute() pre:
         *      The state is valid
         * context CommandQueue::Execute() pre:
         *      _currentCommand > 1
         * 
         * Post conditions:
         * context CommandQueue::Execute() post:
         *      The state is valid
         * context CommandQueue::Execute() post:
         *      isCommandExecuted()
         * All commands were executed, or none
         */
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

        /**
         * Pre conditions:
         * context CommandQueue::Undo() pre:
         *      isStateValid()
         *      
         * context CommandQueue::Undo() pre:
         *      _currentCommand > 1
         *      
         * Post condition:
         * context CommandQueue::Undo() post:
         *      isStateValid()
         * context CommandQueue::Undo() post:
         *      wasCommandUndone()
         */
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
