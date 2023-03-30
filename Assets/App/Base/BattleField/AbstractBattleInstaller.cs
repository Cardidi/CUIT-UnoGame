using System;
using App.Base.BattleField.Events;
using Zenject;

namespace App.Base.BattleField
{
    public abstract class AbstractBattleInstaller<T> : Installer<T> where T : Installer<T>
    {

        protected void ConductPlayerLocal(AbstractBattleParticipantEntity playerEntity)
        {
            if (playerEntity.IsLocalPlayer)
            {
                Container.Bind<AbstractBattleParticipantEntity>()
                    .WithId(BaseConst.LOCAL_INFO)
                    .FromInstance(playerEntity)
                    .AsSingle();

                Container.Bind<IBattleParticipant>()
                    .WithId(BaseConst.LOCAL_INFO)
                    .FromInstance(playerEntity.Participant)
                    .AsSingle();

                return;
            }

            throw new ArgumentException("Given participant is not local player!", nameof(playerEntity));
        }

        protected void BindingContext(BattleContext ctx)
        {
            Container.Bind<BattleContext>().WithId(BaseConst.LOCAL_INFO).FromInstance(ctx).AsSingle().NonLazy();
        }
        

        public override void InstallBindings()
        {
            Container.Bind<BattleEventDispatcher>().FromNew().AsSingle().NonLazy();
        }
    }
}