using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Buttonlocalstart : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //variables

    public GameObject nohover;
    public GameObject hover;

	void Start ()
    {
		
	}

    public void OnPointerEnter(PointerEventData data)
    {
        nohover.SetActive(false);
        hover.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover.SetActive(false);
        nohover.SetActive(true);
    }

    void Update ()
    {
		
	}
}
