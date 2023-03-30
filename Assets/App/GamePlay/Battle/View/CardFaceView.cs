using App.Base.BattleField;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace App.GamePlay.Battle.View
{
    public class CardFaceView : UIBehaviour
    {
        [SerializeField] private Image m_backgroundGraphic;

        [SerializeField] private Image m_iconGraphic;
        
        [Inject]
        private CardFaceConfiguration m_conf { get; set; }

        public void UpdateFace(GameCard card)
        {
            m_backgroundGraphic.color = m_conf.ColorMap[card.Color];
            m_backgroundGraphic.overrideSprite = m_conf.FaceMap[card.Type];
            m_iconGraphic.overrideSprite = m_conf.IconMap[card.Type];
        }
    }
}