using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    bool gameIsStarted;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        gameIsStarted = false;
        canvas.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void click()
    {
        canvas.SetActive(false);
        Debug.Log("init new game..");
        Time.timeScale = 1;
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