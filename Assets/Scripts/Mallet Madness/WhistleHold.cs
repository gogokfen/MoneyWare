using UnityEngine;
using UnityEngine.EventSystems;

public class WhistleHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public MalletMadness malletMadness;

    public void OnPointerDown(PointerEventData eventData)
    {
        malletMadness.Whistling(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        malletMadness.Whistling(false);
    }
}
