using System;
using System.Collections.Generic;
using System.Linq;
using App.Base.BattleField;
using App.Base.BattleField.Events;
using App.Base.User;
using App.GamePlay.Battle.Events;
using App.Toolkit;
using UnityEngine;
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
            switch (evt)
            {
                case AddCardEvent e:
                {
                    RenewCardList(CardList.Value.Count + e.List.Length);
                } break;
                case RemoveCardEvent e:
                {
                    RenewCardList(CardList.Value.Count - e.List.Length);
                } break;
                case RefreshCardEvent e:
                {
                    RenewCardList(e.List.Length);
                } break;
                
                default:
                    Debug.Log(BattleConst.DEBUG_TAG + $"Uncatch event: {evt.GetType()}");
                    break;
            }
        }
    }
}