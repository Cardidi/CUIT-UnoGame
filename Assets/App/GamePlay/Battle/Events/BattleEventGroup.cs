using System;
using App.Base.BattleField;
using App.Base.BattleField.Events;

namespace App.GamePlay.Battle.Events
{
    
    // To Local
    
    public class BattleReadyEvent : BattleEvent
    {
        public BattleReadyEvent(string battleID) : base(battleID) {}
    }

    public class BattleCanceledEvent : BattleEvent
    {
        public String Reason { get; }

        public BattleCanceledEvent(string reason, string battleID) : base(battleID)
        {
            Reason = reason;
        }
    }
    
    public class NextPlayerEvent : BattleEvent
    {
        public string ParticipantId { get; }
        
        public NextPlayerEvent(string participantId, string battleID) : base(battleID)
        {
            ParticipantId = participantId;
        }
    }
    
    public class BattleCardBeenShownEvent : BattleEvent
    {
        
        public GameCard Rule { get; }
        
        public GameCard[] List { get; }
        
        public BattleCardBeenShownEvent(GameCard[] list, GameCard rule, string battleID) : base(battleID)
        {
            List = list;
            Rule = rule;
        }
    }
    
    // To Remote

    public class RequestBattleCanceledEvent : BattleEvent
    {
        public RequestBattleCanceledEvent(string battleID) : base(battleID)
        {
        }
    }

    public class SendBattleCardEvent : BattleEvent
    {

        public GameCard[] List { get; }
        
        public SendBattleCardEvent(GameCard[] list, string battleID) : base(battleID)
        {
            List = list;
        }
    }
}