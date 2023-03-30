using System;

namespace App.GamePlay.Battle
{
    public struct BattleStartConfiguration
    {

        /// <summary>
        /// The battle id which was given by server
        /// </summary>
        public string ServerGivenBattleId;
        
        /// <summary>
        /// The set of participant id and user info. <br />
        /// Left is uid and right is participant id.
        /// </summary>
        public Tuple<uint, string>[] Players;
    }
}