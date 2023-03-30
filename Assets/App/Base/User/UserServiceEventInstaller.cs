using Zenject;

namespace App.Base.User
{
    public class UserServiceEventInstaller : Installer<UserServiceEventInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<UserLoginEvent>();
            Container.DeclareSignal<UserLogoutEvent>();
            Container.DeclareSignal<UserForceQuitEvent>();
        }
    }
}