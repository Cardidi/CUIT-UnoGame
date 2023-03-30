using App.Base.BattleField;
using App.Base.BattleField.Events;
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
            throw new System.NotImplementedException();
        }
        
        #region Events

        

        #endregion
    }
}