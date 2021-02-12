using System.Collections.Generic;
using Card;
using UnityEngine;

namespace UI
{
    public class HandArea : MonoBehaviour
    {
        [SerializeField] private float cardSpacing = 10.0f;
        [SerializeField] private List<PlayingCard> controlledCards = new List<PlayingCard>();

        private RectTransform areaRectTransform;

        private void Start()
        {
            areaRectTransform = GetComponent<RectTransform>();
        }

        public void AddCard(PlayingCard playingCardToAdd)
        {
            playingCardToAdd.transform.SetParent(transform, false);
            playingCardToAdd.gameObject.SetActive(true);

            controlledCards.Add(playingCardToAdd);

            SpreadCards();
        }

        public void RemoveCard(PlayingCard playingCard)
        {
            controlledCards.Remove(playingCard);

            SpreadCards();
        }

        private void SpreadCards()
        {
            if (controlledCards.Count > 0)
            {
                RectTransform cardRect = controlledCards[0].GetComponent<RectTransform>();

                int cardCount = controlledCards.Count;
                Rect areaRect = areaRectTransform.rect;
                float areaWidth = areaRect.width;
                float cardWidth = cardRect.rect.width;

                float startPoint = (cardWidth * cardCount + cardSpacing * (cardCount - 1)) / 2.0f;
                if (startPoint > areaWidth / 2)
                {
                    Debug.Log("Too many cards, need to reduce something");
                }

                Vector3 pos = transform.position;
                for (int i = 0; i < cardCount; i++)
                {
                    controlledCards[i].transform.localPosition = new Vector3(
                        (areaRect.x + areaWidth / 2) - startPoint + ((cardWidth + cardSpacing) * i),
                        cardRect.rect.height / 2.0f,
                        0
                    );
                }
            }
        }
    }
}