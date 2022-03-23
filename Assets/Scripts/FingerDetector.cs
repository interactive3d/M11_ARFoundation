
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering;

public class FingerDetector : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public int trackedFingerID;
    public UnityEvent onBegan;

    [System.Serializable]
    public class Vector3UnityEvent : UnityEvent<Vector3> { }
    public Vector3UnityEvent fingerScreenPoision;

    public UnityEvent onEnded;
    public UnityEvent onMoved;

    public void OnPointerDown(PointerEventData eventData)
    {
        TrackTouch(onBegan);
    }

    public void OnDrag(PointerEventData eventData)
    {
        TrackTouch();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TrackTouch(onEnded);
    }
    
    public void TrackTouch(UnityEvent uEvent = null)
    {
        Touch touch;

        for (int i = 0; i<Input.touchCount; i++)
        {
            touch = Input.GetTouch(i);
            if (touch.fingerId == trackedFingerID)
            {
                fingerScreenPoision?.Invoke(touch.position);
                uEvent?.Invoke();
            }
        }
    }

}

