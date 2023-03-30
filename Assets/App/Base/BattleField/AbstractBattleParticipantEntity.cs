namespace App.Base.BattleField
{
    public abstract class AbstractBattleParticipantEntity
    {
        public virtual bool IsLocalPlayer { get; protected set; }
        
        public virtual IBattleParticipant Participant { get; protected set; }
        
        public virtual BattleContext JoinedBattleContext { get; protected set; }

        protected AbstractBattleParticipantEntity(
            IBattleParticipant participant,
            BattleContext ctx,
            bool isLocalPlayer)
        {
            IsLocalPlayer = isLocalPlayer;
            Participant = participant;
            JoinedBattleContext = ctx;
        }
    }
}