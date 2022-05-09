using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public GameObject button;
    public GameObject selectionCanvas;

    // Start is called before the first frame update
    void Start()
    {
        selectionCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void click()
    {
        selectionCanvas.SetActive(false);
        // Debug.Log("init start game..");
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
