using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public GameObject button;
    public GameObject selectionCanvas;
    public GameObject gameOverCanvas;
    public GameObject pausMenuCanvas;
    public CharacterSelection selected;
    public bool isPausMenu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void click()
    {
        Time.timeScale = 1;
        if(!isPausMenu){
            selectionCanvas.SetActive(false);
            GameManager.finalCharacter = selected.selectedCharacter;
            Debug.Log("final: " + GameManager.finalCharacter);
            pausMenuCanvas.SetActive(true);
        }
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

