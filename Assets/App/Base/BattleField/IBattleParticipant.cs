using System;
using System.Collections.Generic;
using App.Base.BattleField.Events;
using App.Base.User;
using App.Toolkit;
using JetBrains.Annotations;
using Zenject;

namespace App.Base.BattleField
{
    public interface IBattleParticipant
    {
        public string ParticipantID { get; }
        
        public UserInfo ParticipantInfo { get; }

        public UpdatableContent<List<GameCard>> CardList { get; }

        public void EventHandler(BattleParticipantEvent evt, BattleContext ctx, SignalBus msgBus);
    }
}