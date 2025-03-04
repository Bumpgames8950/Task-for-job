using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 

public class Joystick : MonoBehaviour,IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform background;   
    public RectTransform handle;      
    public float dragRadius = 50f;   
    public Vector2 Output { get; private set; } 

    private Vector2 _startPosition; 

    void Start()
    {
        
        _startPosition = background.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData); 
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 rawPosition = eventData.position - (Vector2)GetComponent<RectTransform>().position;
        Vector2 fixedPosition = rawPosition.magnitude > dragRadius ? rawPosition.normalized * dragRadius : rawPosition;

        handle.anchoredPosition = fixedPosition;
        Output = fixedPosition / dragRadius;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handle.anchoredPosition = Vector2.zero;
        Output = Vector2.zero;
    }
}
