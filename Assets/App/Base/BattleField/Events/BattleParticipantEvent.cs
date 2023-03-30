using System;

namespace App.Base.BattleField.Events
{
    public abstract class BattleParticipantEvent
    {
        public string BattleID { get; }
        
        public string ParticipantID { get; }

        private BattleParticipantEvent()
        {
            throw new InvalidOperationException("Could not perform default constructor!");
        }
        
        protected BattleParticipantEvent(string battleID, string participantID)
        {
            battleID = battleID.Trim();
            participantID = participantID.Trim();
            if (string.IsNullOrEmpty(battleID)) throw new ArgumentNullException(nameof(battleID));
            if (string.IsNullOrEmpty(participantID)) throw new ArgumentNullException(nameof(participantID));

            BattleID = battleID;
            ParticipantID = participantID;
        }
    }
}