namespace App.GamePlay.Battle
{
    public enum CancelReason
    {
        BATTLE_END = 0x0,
        DEVICE_OFFLINE_TOO_LONG = 0x1,
        PLAYER_REQUEST_CANCEL = 0x2,
    }
}