using UnityEngine;

namespace Card
{
    [CreateAssetMenu(fileName = "deckData", menuName = "cards/DeckData", order = 0)]
    public class CardDeckData : ScriptableObject
    {
        public string deckName = "Test Deck";
        public CardData[] cards;
    }
}