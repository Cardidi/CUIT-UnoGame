namespace App.Base.User
{
    public class UserLoginEvent : UserEvent
    {
        public bool Successful { get; }

        public UserLoginEvent(uint uID, bool successful) : base(uID) => Successful = successful;
    }
}