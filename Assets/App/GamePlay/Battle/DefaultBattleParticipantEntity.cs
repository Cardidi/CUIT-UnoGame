using App.Base.BattleField;

namespace App.GamePlay.Battle
{
    public class DefaultBattleParticipantEntity : AbstractBattleParticipantEntity
    {
        public DefaultBattleParticipantEntity(RemoteBattleParticipant participant, BattleContext ctx) :
            base(participant, ctx, false)
        {}
        
        public DefaultBattleParticipantEntity(LocalBattleParticipant participant, BattleContext ctx) :
            base(participant, ctx, true)
        {}
    }
}