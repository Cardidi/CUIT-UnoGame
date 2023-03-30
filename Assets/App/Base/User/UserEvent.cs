using System;

namespace App.Base.User
{
    public class UserEvent
    {
        public uint UID { get; }
        
        private UserEvent()
        {
            throw new InvalidOperationException("Could not perform default constructor!");
        }

        protected UserEvent(uint uID)
        {
            uID = uID;
            if (uID == 0) throw new ArgumentNullException(nameof(uID));

            UID = uID;
        }
    }
}