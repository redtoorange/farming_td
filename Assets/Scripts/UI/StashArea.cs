using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class StashArea : MonoBehaviour
    {
        [SerializeField] private GameObject[] stashObjects = new GameObject[0];
        [SerializeField] private float stashAmount = 50.0f;
        [SerializeField] private bool stashed = false;
        [SerializeField] private float stashDuration = 0.25f;
        [SerializeField] private Ease easeType = Ease.Linear;

        private float startingY;
        private float stashedY;

        private RectTransform rectTransform;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            startingY = stashObjects[0].transform.position.y;
            stashedY = startingY - stashAmount;

            // Initially stash the UI
            stashed = true;
            foreach (GameObject stashObject in stashObjects)
            {
                RectTransform t = stashObject.GetComponent<RectTransform>();
                t.Translate(0, -stashAmount, 0);
            }
        }

        private void Update()
        {
            UpdateStashState();
        }

        private void UpdateStashState()
        {
            Vector2 mPos = Mouse.current.position.ReadValue();
            bool mouseInBounds = RectTransformUtility.RectangleContainsScreenPoint(
                rectTransform,
                mPos
            );

            // When game first starts, the mouse is always at 0,0 which puts it inbounds...
            if (stashed && mouseInBounds && !(mPos.x == 0 && mPos.y == 0))
            {
                SetStashState(false);
            }
            else if (!mouseInBounds || !Application.isFocused)
            {
                SetStashState(true);
            }
        }

        private void SetStashState(bool shouldStash)
        {
            if (stashed != shouldStash)
            {
                stashed = shouldStash;
                foreach (GameObject stashObject in stashObjects)
                {
                    stashObject.GetComponent<RectTransform>()
                        .DOMoveY(shouldStash ? stashedY : startingY, stashDuration)
                        .SetEase(easeType);
                }
            }
        }
    }
}