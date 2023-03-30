using System;
using System.Linq;
using App.Base.BattleField;
using App.Base.User;
using App.GamePlay.Battle.Events;
using Zenject;

namespace App.GamePlay.Battle
{
    public class InternalBattleInstaller : AbstractBattleInstaller<InternalBattleInstaller>
    {

        [Inject] private IUserService m_userService { get; set; }

        [Inject]
        private BattleStartConfiguration m_configuration { get; set; }

        private BattleContext Setup(BattleStartConfiguration configuration)
        {
            var mediator = new ServerBattleMediator(configuration.ServerGivenBattleId);
            // ReSharper disable once CoVariantArrayConversion
            return new BattleContext(mediator, ctx =>
            {
                var entities = configuration.Players.Select(p =>
                {
                    // Fetch user info
                    var usr = m_userService.FetchUserInfo(p.Item1)[0];
                    if (usr.Status.Value != UserStatus.CACHEING) m_userService.RenewUserInfo(usr.UID);
                    var participantId = p.Item2;
                    
                    if (usr.IsLocalPlayer)
                    {
                        var local = new DefaultBattleParticipantEntity(new LocalBattleParticipant(participantId, usr), ctx);
                        ConductPlayerLocal(local);
                        return local;
                    }
                    else
                    {
                        return new DefaultBattleParticipantEntity(new RemoteBattleParticipant(participantId, usr), ctx);
                    }
                }).ToArray();

                // Set local player as the first item in this array.
                var idx = Array.FindIndex(entities, e => e.IsLocalPlayer);
                for (int i = idx; i < entities.Length; i++)
                    (entities[i - idx], entities[i]) = (entities[i], entities[i - idx]);

                return entities;
            });
        }
        
        public override void InstallBindings()
        {
            DeclareEvents();
            var ctx = Setup(m_configuration);
            BindingContext(ctx);
            base.InstallBindings();
        }

        private void DeclareEvents()
        {
            // Battle Events
            Container.DeclareSignalWithInterfaces<BattleReadyEvent>();
            Container.DeclareSignalWithInterfaces<BattleCanceledEvent>();
            Container.DeclareSignalWithInterfaces<NextPlayerEvent>();
            Container.DeclareSignalWithInterfaces<BattleCardBeenShownEvent>();
            Container.DeclareSignalWithInterfaces<RequestBattleCanceledEvent>();
            Container.DeclareSignalWithInterfaces<SendBattleCardEvent>();
            
            // Battle Participant Events
            Container.DeclareSignalWithInterfaces<AddCardEvent>();
            Container.DeclareSignalWithInterfaces<RemoveCardEvent>();
            Container.DeclareSignalWithInterfaces<RefreshCardEvent>();
        }
    }
}