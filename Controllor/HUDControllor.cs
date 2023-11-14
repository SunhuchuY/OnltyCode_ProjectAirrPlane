using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class HUDControllor : MonoBehaviour
{
    [SerializeField] private TMP_Text speedText;


    private void Start()
    {
        EventBus.Subscribe( EventType.Hud, HUD_Text);
    }

    private void HUD_Text()
    {
        Debug.Log("HUDTEXT");
        speedText.text = $"{GameManager.Instance.planeControllor.GetSpeed()}km/h";
    }

}
