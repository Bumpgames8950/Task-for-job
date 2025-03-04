using UnityEngine;
using UnityEngine.EventSystems;

public class MouseTouchInput : MonoBehaviour
{
    public int touchId = 0; 

    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            
            Touch touch = new Touch();
            touch.fingerId = touchId;
            touch.position = Input.mousePosition; 
            if (Input.GetMouseButtonDown(0))
            {
                touch.phase = TouchPhase.Began;
            }
            else
            {
                touch.phase = TouchPhase.Moved;
            }
            SimulateTouch(touch);
        }
        else
        {
       
            Touch touch = new Touch();
            touch.fingerId = touchId;
            touch.position = Input.mousePosition;
            touch.phase = TouchPhase.Ended;
            SimulateTouch(touch);
        }
    }

    
    void SimulateTouch(Touch touch)
    {
        
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = touch.position; 
        System.Collections.Generic.List<RaycastResult> raycastResults = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);
        foreach (RaycastResult result in raycastResults)
        {
            IPointerDownHandler downHandler = result.gameObject.GetComponent<IPointerDownHandler>();
            IDragHandler dragHandler = result.gameObject.GetComponent<IDragHandler>();
            IPointerUpHandler upHandler = result.gameObject.GetComponent<IPointerUpHandler>();

            if (touch.phase == TouchPhase.Began && downHandler != null)
            {
                downHandler.OnPointerDown(pointer);
            }
            else if (touch.phase == TouchPhase.Moved && dragHandler != null)
            {
                dragHandler.OnDrag(pointer);
            }
            else if (touch.phase == TouchPhase.Ended && upHandler != null)
            {
                upHandler.OnPointerUp(pointer);
            }
        }
    }
}
