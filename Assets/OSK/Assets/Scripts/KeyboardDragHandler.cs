using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

<<<<<<< HEAD
public class KeyboardDragHandler : MonoBehaviour, IDragHandler
{



    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    #endregion





=======
public class KeyboardDragHandler : MonoBehaviour, IDragHandler
{



    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    #endregion





>>>>>>> 412baaf9dd887cf70f5fc9e95d429f39a5b0a210
}