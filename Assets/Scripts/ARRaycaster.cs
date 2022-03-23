// using System.Collections;
// using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARRaycaster : MonoBehaviour
{
    public ARRaycastManager manager;

    [System.Serializable]
    public class Vector3UnityEvent : UnityEvent<Vector3> { }
    public Vector3UnityEvent hitPosition;

    private List<ARRaycastHit> raycastHitList = new List<ARRaycastHit>();

    public void PerformARRaycast(Vector3 clickScreenPosition)
    {
        bool hasHitPlane = manager.Raycast(clickScreenPosition, raycastHitList, TrackableType.All);
        if (hasHitPlane)
        {
            hitPosition?.Invoke(raycastHitList[0].pose.position);
        }
        raycastHitList.Clear();
    }
}
