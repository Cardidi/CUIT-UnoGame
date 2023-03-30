using System;
using App.Base.BattleField.Events;
using Zenject;

namespace App.Base.BattleField
{
    public interface IBattleMediator
    {
        public string BattleID { get; }

        public void EventHandler(BattleEvent evt, BattleContext battleContext, SignalBus msgBus);
        
    }
}