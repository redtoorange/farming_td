using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Card
{
    public class PlayingCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public static event Action<PlayingCard> OnBeginDragging;
        public static event Action<PlayingCard> OnEndDragging;

        [SerializeField] private int cardId = -1;
        [SerializeField] private TMP_Text cardTitle = null;
        [SerializeField] private Image cardImage = null;
        [SerializeField] private TMP_Text cardDescription = null;

        private CardData cardData;
        private bool dragging = false;

        private Vector2 draggingOffset = Vector2.zero;

        public void SetCardData(CardData data)
        {
            cardData = data;

            cardTitle.text = cardData.cardName;
            cardImage.sprite = cardData.cardImage;
            cardDescription.text = cardData.cardDescription;
        }

        private void Update()
        {
            if (dragging)
            {
                Vector2 mPos = Mouse.current.position.ReadValue();
                transform.position = mPos + draggingOffset;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                dragging = true;
                draggingOffset = (Vector2) transform.position - eventData.position;
                OnBeginDragging?.Invoke(this);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                dragging = false;
                OnEndDragging?.Invoke(this);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }
    }
}