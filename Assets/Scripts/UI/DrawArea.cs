using System;
using System.Collections.Generic;
using Card;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace UI
{
    public class DrawArea : MonoBehaviour, IPointerClickHandler
    {
        public static event Action CardsEmpty;

        [SerializeField] private HandArea cardParent = null;
        [SerializeField] private CardDeckData initialDeck = null;
        [FormerlySerializedAs("cardPrefab")]
        [SerializeField] private Card.PlayingCard playingCardPrefab = null;

        private List<Card.PlayingCard> remainingCards;

        private void Start()
        {
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            // Spawn new cards
            remainingCards = new List<Card.PlayingCard>();
            for (int i = 0; i < initialDeck.cards.Length; i++)
            {
                Card.PlayingCard newPlayingCard = Instantiate(playingCardPrefab, transform);
                newPlayingCard.SetCardData(initialDeck.cards[i]);
                newPlayingCard.gameObject.SetActive(false);
                remainingCards.Add(newPlayingCard);
            }

            // Shuffle the cards
            // int n = remainingCards.Count;
            // while (n > 1)
            // {
            //     n--;
            //     int k = Random.Range(0, n + 1);
            //     Card value = remainingCards[k];
            //     remainingCards[k] = remainingCards[n];
            //     remainingCards[n] = value;
            // }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (remainingCards.Count > 0)
                {
                    DrawCard();
                }
            }
        }

        private void DrawCard()
        {
            int k = Random.Range(0, remainingCards.Count);
            Card.PlayingCard playingCard = remainingCards[k];
            remainingCards.RemoveAt(k);

            cardParent.AddCard(playingCard);

            if (remainingCards.Count == 0)
            {
                CardsEmpty?.Invoke();
            }
        }
    }
}