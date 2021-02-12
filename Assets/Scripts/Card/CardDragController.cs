using UI;
using UnityEngine;

namespace Card
{
    public class CardDragController : MonoBehaviour
    {
        [SerializeField] private HandArea handArea;

        private void OnEnable()
        {
            PlayingCard.OnBeginDragging += HandleBeginDragging;
            PlayingCard.OnEndDragging += HandleEndDragging;
        }

        private void OnDisable()
        {
            PlayingCard.OnBeginDragging -= HandleBeginDragging;
            PlayingCard.OnEndDragging -= HandleEndDragging;
        }


        private void HandleBeginDragging(PlayingCard playingCard)
        {
            handArea.RemoveCard(playingCard);
            playingCard.transform.SetParent(transform, false);
        }

        private void HandleEndDragging(PlayingCard playingCard)
        {
            handArea.AddCard(playingCard);
        }
    }
}