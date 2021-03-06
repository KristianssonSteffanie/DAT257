using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject canvas;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        canvas.SetActive(true);
        Debug.Log("open settings..");
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
