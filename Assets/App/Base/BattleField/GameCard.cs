using System;

namespace App.Base.BattleField
{

    /// <summary>
    /// Type of card
    /// </summary>
    public enum GameCardType
    {
        /// <summary>
        /// Used in game card rule, which can tell any card can be given.
        /// </summary>
        ANY = 0,
        
        NUMBER_0 = 1,
        NUMBER_1 = 2,
        NUMBER_2 = 3,
        NUMBER_3 = 4,
        NUMBER_4 = 5,
        NUMBER_5 = 6,
        NUMBER_6 = 7,
        NUMBER_7 = 8,
        NUMBER_8 = 9,
        NUMBER_9 = 10,
        SKIP = 11,
        REVERSE = 12,
        DRAW_2 = 13,
        DRAW_4 = 14,
        WILD = 15,
        
        /// <summary>
        /// This cards means that the card content was hidden.
        /// </summary>
        HIDE = 16
    }

    /// <summary>
    /// Color of card
    /// </summary>
    public enum GameCardColor
    {
        ANY = 0,
        RED = 1,
        GREED = 2,
        BLUE = 3,
        YELLOW = 4
    }
    
    /// <summary>
    /// The Serializable struct for game card.
    /// </summary>
    [Serializable]
    public struct GameCard
    {
        public static int CardCompare(GameCard l, GameCard r)
        {
            var type = l.Type - r.Type;
            var color = l.Color - r.Color;
            if (color != 0) return color;
            return type;
        }
        
        public readonly GameCardType Type;

        public readonly GameCardColor Color;

        public GameCard(GameCardColor color, GameCardType type)
        {
            Type = type;
            Color = color;
        }
    }
}