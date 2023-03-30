using System;
using App.Base.BattleField.Events;
using UnityEngine;
using Zenject;

namespace App.Base.BattleField
{
    public class BattleEventDispatcher : IInitializable, ILateDisposable
    {
        [Inject]
        private SignalBus m_sigBus { get; set; }
        
        [Inject(Id = BaseConst.LOCAL_INFO)]
        private BattleContext m_context { get; set; }
        
        public void Initialize()
        {
            // Register as to_local event.
            m_sigBus.SubscribeToLocal<BattleEvent>(BattleEventHandler);
            m_sigBus.SubscribeToLocal<BattleParticipantEvent>(BattleParticipantEventHandler);
        }

        public void LateDispose()
        {
            m_sigBus.UnsubscribeToLocal<BattleEvent>(BattleEventHandler);
            m_sigBus.UnsubscribeToLocal<BattleParticipantEvent>(BattleParticipantEventHandler);
        }

        private void BattleEventHandler(BattleEvent evt)
        {
            if (evt.BattleID == m_context.Mediator.BattleID)
            {
                Debug.Log(BaseConst.DEBUG_TAG_BATTLEFIELD + $"Catch incoming battle event: {evt.BattleID}");
                m_context.Mediator.EventHandler(evt, m_context, m_sigBus);
            }
            else
            {
                Debug.LogWarning(BaseConst.DEBUG_TAG_BATTLEFIELD + $"Uncatched Incoming battle event call: BattleID not matched: {evt.BattleID}");
            }
        }

        private void BattleParticipantEventHandler(BattleParticipantEvent evt)
        {
            if (evt.BattleID == m_context.Mediator.BattleID)
            {
                var target = Array.Find(m_context.Paritcipants, m => m.Participant.ParticipantID == evt.ParticipantID);
                if (target == null)
                {
                    Debug.LogWarning(BaseConst.DEBUG_TAG_BATTLEFIELD + $"Uncatch incoming battle participant event call: BattleID not matched: {evt.ParticipantID}@{evt.BattleID}");
                }
                else
                {
                    Debug.Log(BaseConst.DEBUG_TAG_BATTLEFIELD + "Catch incoming battle event participant: {evt.ParticipantID}@{evt.BattleID}");   
                    target.Participant.EventHandler(evt, m_context, m_sigBus); 
                }
            }
            else
            {
                Debug.LogWarning(BaseConst.DEBUG_TAG_BATTLEFIELD + $"Uncatch incoming battle participant event call: BattleID not matched: {evt.ParticipantID}@{evt.BattleID}");
            }
        }
    }
}