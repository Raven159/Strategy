using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading;

namespace UserControlSystem
{
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public CancellationTokenSource CancellationTokenSource { get; set; }

        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            CancellationTokenSource?.Cancel();
        }
    }
}
