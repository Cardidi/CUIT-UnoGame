using System;

namespace App.Base.User
{
    public class UserForceQuitEvent : UserEvent
    {
        public String QuitMessage { get; }

        protected UserForceQuitEvent(uint uID, string message) : base(uID) => QuitMessage = message;
    }
}