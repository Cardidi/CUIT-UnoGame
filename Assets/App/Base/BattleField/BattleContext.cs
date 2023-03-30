using System;
using System.Linq;
using App.Base.BattleField.Events;
using App.Toolkit;
using UnityEngine;

namespace App.Base.BattleField
{
    /// <summary>
    /// Context which was used to control the hole game status.
    /// </summary>
    public class BattleContext
    {
        public IBattleMediator Mediator { get; }
        
        public AbstractBattleParticipantEntity[] Paritcipants { get; }
        
        public UpdatableContent<AbstractBattleParticipantEntity> CurrentPlayer { get; }
        
        public UpdatableContent<GameCard> CurrentCardRule { get; }

        public BattleContext(IBattleMediator mediator, Func<BattleContext, AbstractBattleParticipantEntity[]> entityCreator)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (entityCreator == null) throw new ArgumentNullException(nameof(entityCreator));
            var entities = entityCreator.Invoke(this);
            if (entities.Length < 2)
                throw new ArgumentException("Participants should not less than 2!", nameof(entities));

            Mediator = mediator;
            Paritcipants = entities;
            CurrentCardRule = new UpdatableContent<GameCard>(new GameCard(GameCardColor.ANY, GameCardType.ANY));
            CurrentPlayer = new UpdatableContent<AbstractBattleParticipantEntity>();
        }
        
    }
}