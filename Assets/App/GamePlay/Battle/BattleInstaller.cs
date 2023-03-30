using Zenject;

namespace App.GamePlay.Battle
{
    public class BattleInstaller : MonoInstaller<BattleInstaller>
    {
        public override void InstallBindings()
        {
            InternalBattleInstaller.Install(Container);
        }
    }
}