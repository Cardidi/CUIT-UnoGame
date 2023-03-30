using App.Base.BattleField;
using App.Base.BattleField.Events;
using App.GamePlay.Battle.Events;
using UnityEngine;
using Zenject;

namespace App.GamePlay.Battle
{
    public class ServerBattleMediator : IBattleMediator
    {

        internal ServerBattleMediator(string battleID)
        {
            BattleID = battleID;
        }
        
        public string BattleID { get; }
        
        public void EventHandler(BattleEvent evt, BattleContext battleContext, SignalBus msgBus)
        {
            switch (evt)
            {
                case BattleReadyEvent e:
                    BattleReadyHandler(e, battleContext);
                    break;
                case BattleCanceledEvent e:
                    BattleCancelHandler(e, battleContext, msgBus);
                    break;
                case NextPlayerEvent e:
                    NextPlayerHandler(e, battleContext, msgBus);
                    break;
                case BattleCardBeenShownEvent e:
                    BattleCardShownHandler(e, battleContext, msgBus);
                    break;
                default:
                    Debug.Log(BattleConst.DEBUG_TAG + $"Uncatch event: {evt.GetType()}");
                    break;
            }
        }
        
        #region Events

        private void BattleReadyHandler(BattleReadyEvent e, BattleContext c)
        {                    
            if (c.StartedFlag.Value == true)
                Debug.LogWarning(BattleConst.DEBUG_TAG + "Recive secondary event of battle started!");
            else
                c.StartedFlag.Update(true);
        }
        
        private void BattleCancelHandler(BattleCanceledEvent e, BattleContext c, SignalBus b)
        {}
        
        private void NextPlayerHandler(NextPlayerEvent e, BattleContext c, SignalBus b)
        {}
        
        private void BattleCardShownHandler(BattleCardBeenShownEvent e, BattleContext c, SignalBus b)
        {}

        #endregion
    }
}