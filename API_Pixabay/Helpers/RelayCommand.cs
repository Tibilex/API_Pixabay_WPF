using System;

namespace API_Pixabay.Helpers
{
    public class RelayCommand : CommandBase
    {
        private Action<string> _execute;
        public RelayCommand(Action<string> execute)
        {
            _execute = execute;
        }
        public override void Execute(object parameter)
        {
            _execute.Invoke(parameter as string);
        }
    }
}
