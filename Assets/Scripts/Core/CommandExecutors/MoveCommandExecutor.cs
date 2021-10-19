using Abstractions.Commands.CommandsInterfaces;
using Core;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Abstractions.Commands.CommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;

        public override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            GetComponent<NavMeshAgent>().destination = command.Target;
            _animator.SetTrigger(Animator.StringToHash(AnimationTypes.Walk));
            _stopCommandExecutor.CancrllationTokenSource = new CancellationTokenSource();
            try
            {
                await _stop
                    .WithCancellation
                    (
                    _stopCommandExecutor
                    .CancellationTokenSource
                    .Token
                    );
            }
            catch
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<NavMeshAgent>().ResetPath();
            }
            _stopCommandExecutor.CancellationTokenSource = null;
            _animator.SetTrigger(Animation.StringToHash(AnimationTypes.Idle));
        }
    }
}