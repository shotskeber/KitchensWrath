using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Onlinebuttonreaction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //variables

    public GameObject button;

    private Vector3 pos;

    private int timershake;

    private bool pointerenter;

    public void OnPointerEnter(PointerEventData data)
    {
        pointerenter = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerenter = false;
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
        
        if (pointerenter)
        {
            timershake += 1;
            if (timershake >= 5 && timershake <= 10)
            {
                button.transform.localPosition = new Vector3(126, 80, 0);
            }
            if (timershake >= 10 && timershake <= 15)
            {
                button.transform.localPosition = new Vector3(100, 80, 0);
            }
            if (timershake >= 15 && timershake <= 20)
            {
                button.transform.localPosition = new Vector3(113, 80, 0);
            }
            if (timershake == 50)
            {
                timershake = 0;
            }
        }
	}
}
