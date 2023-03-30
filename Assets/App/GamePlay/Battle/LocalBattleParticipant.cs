using System.Collections.Generic;
using App.Base.BattleField;
using App.Base.BattleField.Events;
using App.Base.User;
using App.GamePlay.Battle.Events;
using App.Toolkit;
using UnityEngine;
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
            switch (evt)
            {
                case AddCardEvent e:
                {
                    CardList.Value.AddRange(e.List);
                    CardList.Update();
                } break;
                case RemoveCardEvent e:
                {
                    foreach (var c in e.List)
                        CardList.Value.Remove(c);
                    CardList.Update();
                } break;
                case RefreshCardEvent e:
                {
                    CardList.Value.Clear();
                    CardList.Value.AddRange(e.List);
                    CardList.Update();
                } break;
                
                default:
                    Debug.Log(BattleConst.DEBUG_TAG + $"Uncatch event: {evt.GetType()}");
                    break;
            }
        }
        
    }
}