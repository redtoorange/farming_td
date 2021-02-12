using UnityEngine;

namespace Card
{
    [CreateAssetMenu(fileName = "cardData", menuName = "cards/CardData", order = 0)]
    public class CardData : ScriptableObject
    {
        public string cardName = "Test Card";
        public Sprite cardImage = null;
        public string cardDescription = "Test Card";
    }
}