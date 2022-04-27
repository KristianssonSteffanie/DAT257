using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        Debug.Log("exit game..");
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.GetComponentInChildren<Text>().fontSize = 36;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.GetComponentInChildren<Text>().fontSize = 28;
    }
}
