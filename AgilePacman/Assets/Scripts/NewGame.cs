using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject button;
    bool gameIsStarted;
    public GameObject canvas;
    public GameObject selectionCanvas;
    public GameObject pausMenuCanvas;


    // Start is called before the first frame update
    void Start()
    {
        //gameIsStarted = false;
        canvas.SetActive(true);
        selectionCanvas.SetActive(false);
        pausMenuCanvas.SetActive(false);

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void click()
    {
        canvas.SetActive(false);
        selectionCanvas.SetActive(true);
        // Debug.Log("init new game..");
        // Time.timeScale = 1;
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