using System;
using System.Collections.Generic;
using App.Base.BattleField;
using App.Base.BattleField.Events;
using App.Base.User;
using App.Toolkit;
using Zenject;

namespace App.GamePlay.Battle
{
    public class RemoteBattleParticipant : IBattleParticipant
    {
        
        public RemoteBattleParticipant(string id, UserInfo info)
        {
            ParticipantID = id;
            ParticipantInfo = info;
        }
        
        public string ParticipantID { get; }
        
        public UserInfo ParticipantInfo { get; }
        
        public UpdatableContent<List<GameCard>> CardList { get; }

        private void RenewCardList(int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            var val = CardList.CachedValue;
            
            // Resize list to targeting length
            while (val.Count > count)
                val.RemoveAt(0);
            while (val.Count < count)
                val.Add(new GameCard(GameCardColor.ANY, GameCardType.HIDE));
            
            CardList.Update();
        }
        
        public void EventHandler(BattleParticipantEvent evt, BattleContext ctx, SignalBus msgBus)
        {
            throw new System.NotImplementedException();
        }

        #region Events

        

        #endregion
    }
}