using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VictoryScreenButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitClick()
    {
        Debug.Log("exit game..");
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.fontSize = 80;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.fontSize = 61;
    }
}
