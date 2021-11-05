using Abstractions;
using Zenject;

namespace Core
{
    public class CoreInstaller : MonoInstaller
    {
        private IGameStatus _gameStatus;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TimeModel>().AsSingle();
            Container.Bind<IGameStatus>().FromInstance(_gameStatus);
        }
    }
}