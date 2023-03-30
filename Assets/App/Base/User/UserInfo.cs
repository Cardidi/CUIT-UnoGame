using System;
using App.Toolkit;
using JetBrains.Annotations;
using UnityEngine.Analytics;

namespace App.Base.User
{

    public enum UserGender
    {
        NOT_GIVEN = 1,
        MAN = 2,
        FEMAN = 3
    }

    public enum UserStatus
    {
        // This user is not existed.
        INVALID = 0,
        
        /// <summary>
        /// This status means that this user has not being cache in local, and we should wait for information arrival.
        /// </summary>
        CACHEING = 1,
        OFFLINE = 2,
        ACTIVE = 3,
        
        // This user can not do anything. (Limited login)
        LOCK = 5
    }
    
    [Serializable]
    public class UserInfo
    {

        public bool IsLocalPlayer => !String.IsNullOrEmpty(SessionID);
        
        /// <summary>
        /// The Unique id which was used to indicate the user.
        /// </summary>
        public uint UID { get; }
        
        /// <summary>
        /// The id which was used to identify requestor. Given by server. <br />
        /// If this string is null or empty, which means this info is not your login account.
        /// </summary>
        [CanBeNull]
        public string SessionID { get; }

        public UpdatableContent<string> DisplayName { get; } 
        
        public UpdatableContent<UserGender> Gender { get; }
        
        public UpdatableContent<UserStatus> Status { get; }

        public UserInfo(uint uid, string sessionID = null, string displayName = default, UserGender gender = UserGender.NOT_GIVEN)
        {
            UID = uid;
            SessionID = sessionID?.Trim();
            DisplayName = new UpdatableContent<string>(displayName);
            Gender = new UpdatableContent<UserGender>(gender);
            Status = new UpdatableContent<UserStatus>(UserStatus.CACHEING);
        }
    }
}