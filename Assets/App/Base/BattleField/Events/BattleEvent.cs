using System;

namespace App.Base.BattleField.Events
{
    public abstract class BattleEvent
    {
        public string BattleID { get; }
        
        private BattleEvent()
        {
            throw new InvalidOperationException("Could not perform default constructor!");
        }

        protected BattleEvent(string battleID)
        {
            battleID = battleID.Trim();
            if (string.IsNullOrEmpty(battleID)) throw new ArgumentNullException(nameof(battleID));

            BattleID = battleID;
        }
    }
}