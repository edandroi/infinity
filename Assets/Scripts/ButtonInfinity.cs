using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonInfinity : MonoBehaviour,  IPointerEnterHandler
{

    public GameObject particles;

    private bool touched = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!touched)
        {
            Instantiate(particles, Services.Player.transform.position, Quaternion.identity);
            touched = true;
        }
        Services.GameManager.nextScene = true;
    }
}
