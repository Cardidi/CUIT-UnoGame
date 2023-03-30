using System;
using Zenject;

namespace App.Base
{
    public static class BaseExtend
    {
        public static void FireToRemote(this SignalBus msgBus, object msg)
            => msgBus.FireId(BaseConst.SIGNAL_CHANEL_TO_REMOTE, msg);

        public static void FireToLocal(this SignalBus msgBus, object msg)
            => msgBus.FireId(BaseConst.SIGNAL_CHANEL_TO_LOCAL, msg);

        public static void SubscribeToRemote<T>(this SignalBus msgBus, Action<T> callback)
            => msgBus.SubscribeId<T>(BaseConst.SIGNAL_CHANEL_TO_REMOTE, callback);
        
        public static void SubscribeToLocal<T>(this SignalBus msgBus, Action<T> callback)
            => msgBus.SubscribeId<T>(BaseConst.SIGNAL_CHANEL_TO_LOCAL, callback);
        
        public static void UnsubscribeToRemote<T>(this SignalBus msgBus, Action<T> callback)
            => msgBus.UnsubscribeId<T>(BaseConst.SIGNAL_CHANEL_TO_REMOTE, callback);
        
        public static void UnsubscribeToLocal<T>(this SignalBus msgBus, Action<T> callback)
            => msgBus.UnsubscribeId<T>(BaseConst.SIGNAL_CHANEL_TO_LOCAL, callback);
    }
}