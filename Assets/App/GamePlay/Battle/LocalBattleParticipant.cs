using System.Collections.Generic;
using App.Base.BattleField;
using App.Base.BattleField.Events;
using App.Base.User;
using App.Toolkit;
using Zenject;

namespace App.GamePlay.Battle
{
    public class LocalBattleParticipant : IBattleParticipant
    {

        public LocalBattleParticipant(string id, UserInfo info)
        {
            ParticipantID = id;
            ParticipantInfo = info;
        }
        
        public string ParticipantID { get; }
        public UserInfo ParticipantInfo { get; }
        
        public UpdatableContent<List<GameCard>> CardList { get; }

        public void EventHandler(BattleParticipantEvent evt, BattleContext ctx, SignalBus msgBus)
        {
            throw new System.NotImplementedException();
        }
        
        #region Events

        

        #endregion
    }
}