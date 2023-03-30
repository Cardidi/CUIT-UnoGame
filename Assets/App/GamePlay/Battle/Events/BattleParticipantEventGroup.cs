using App.Base.BattleField;
using App.Base.BattleField.Events;

namespace App.GamePlay.Battle.Events
{
    
    // To Local
    
    public class AddCardEvent : BattleParticipantEvent
    {
        public GameCard[] List { get; }
        
        public AddCardEvent(GameCard[] list, string battleID, string participantID) : base(battleID, participantID)
        {
            List = list;
        }
    }
    
    public class RemoveCardEvent : BattleParticipantEvent
    {
        public GameCard[] List { get; }
        
        public RemoveCardEvent(GameCard[] list, string battleID, string participantID) : base(battleID, participantID)
        {
            List = list;
        }
    }
    
    public class RefreshCardEvent : BattleParticipantEvent
    {
        public GameCard[] List { get; }
        
        public RefreshCardEvent(GameCard[] list, string battleID, string participantID) : base(battleID, participantID)
        {
            List = list;
        }
    }
}