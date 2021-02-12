using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class HoverColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image backgroundImage = null;
        [SerializeField] private Color normalColor = Color.white;
        [SerializeField] private Color hoverColor = Color.red;


        public void OnPointerEnter(PointerEventData eventData)
        {
            backgroundImage.color = hoverColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            backgroundImage.color = normalColor;
        }
    }
}