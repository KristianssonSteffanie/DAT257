using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoToMainMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    public GameManager gameManager;
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
        Debug.Log("going to main menu");
        Time.timeScale = 0;
        gameManager.NewGame();
        SceneManager.LoadScene("FirstLevel");
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
