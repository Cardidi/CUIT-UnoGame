using App.Base.BattleField;
using App.Toolkit;
using UnityEngine;
using Zenject;

namespace App.GamePlay.Battle
{
    [CreateAssetMenu(fileName = "Card Face Configuration", menuName = "Uno/Card Face", order = 0)]
    public class CardFaceConfiguration : ScriptableObjectInstaller<CardFaceConfiguration>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CardFaceConfiguration>().FromInstance(this).AsSingle();
        }

        [SerializeField] private SerializedDictionary<GameCardColor, Color> m_colorMap;

        [SerializeField] private SerializedDictionary<GameCardType, Sprite> m_faceMap;
        
        [SerializeField] private SerializedDictionary<GameCardType, Sprite> m_iconMap;

        public SerializedDictionary<GameCardColor, Color> ColorMap => m_colorMap;

        public SerializedDictionary<GameCardType, Sprite> FaceMap => m_faceMap;
        
        public SerializedDictionary<GameCardType, Sprite> IconMap => m_iconMap;
    }
}