using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TransformController : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public static GameObject draggablesprite;
    Vector3 startPosition;
    float zDistanceToCamera;
    Vector3 touchOffset;

    public void OnBeginDrag (PointerEventData eventData)
    {
        draggablesprite = gameObject;
        startPosition = transform.position;
        zDistanceToCamera = Mathf.Abs(startPosition.z - Camera.main.transform.position.z);
        touchOffset = startPosition - Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistanceToCamera));
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount > 1)
            return;

        transform.position = Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistanceToCamera))+touchOffset;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        draggablesprite = null;
        touchOffset = Vector3.zero;
    }
}
