using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField]
    private Mouse mouse;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.x > 0) mouse.ChangeLine(1);
            else mouse.ChangeLine(-1);

        }
        else
        {
            bool isGround = Ground.Is_ground;
            if ((eventData.delta.y > 0) && (isGround)) StartCoroutine(mouse.DoJump());
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
