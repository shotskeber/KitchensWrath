using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class basicreactionbuttons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    //variables
    public GameObject basetransform;
    public GameObject Controle;
    
    public void OnPointerEnter(PointerEventData data)
    {
        transform.localScale = new Vector3(0.85f, 1.2f, 1f);
        rotatebutton();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = basetransform.transform.localScale;
        transform.rotation = basetransform.transform.rotation;
    }

    public void OnSelect(BaseEventData data)
    {
        transform.localScale = new Vector3(0.85f, 1.2f, 1f);
        rotatebutton();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        transform.localScale = basetransform.transform.localScale;
        transform.rotation = basetransform.transform.rotation;
    }

    public void rotatebutton()
    {
        transform.Rotate(Vector3.forward * -5f);
        if(Controle)
        {
            transform.Rotate(Vector3.forward * 10f);
        }

    }
}
