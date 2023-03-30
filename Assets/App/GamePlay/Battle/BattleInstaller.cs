using Zenject;

namespace App.GamePlay.Battle
{
    public class BattleInstaller : MonoInstaller<BattleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<BattleStartConfiguration>().FromNew().AsSingle().NonLazy();
            InternalBattleInstaller.Install(Container);
        }
    }
}