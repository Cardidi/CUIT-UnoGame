using Cysharp.Threading.Tasks;

namespace App.Base.User
{
    public interface IUserService
    {
        public bool HasLogin { get; }
        
        public UserInfo LoginUser { get; }

        public UniTask<bool> TryLogin(string username, string password);

        public UniTask<bool> TryLogout();

        public UserInfo[] FetchUserInfo(params uint[] uid);

        public UniTask RenewUserInfo(params uint[] uid);
    }
}