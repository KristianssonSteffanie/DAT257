using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterSelection : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject prevButton;
    public StartGame startButton;
    public MainCharacter[] characters;

    public Image[] characterImages; 
    public int selectedCharacter = 0;

// Paging through characters using keys
    public void Update(){
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            this.NextCharacter();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            this.PreviousCharacter();
        }
        else if (Input.GetKeyDown(KeyCode.Return)){
            startButton.click();
        }
    }
    public void NextCharacter()
    {
        for (int i = 0; i < characters.Length; i++){
            characters[selectedCharacter].Disable();
        }
        characterImages[selectedCharacter].enabled = false;
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].ResetState();
        characterImages[selectedCharacter].enabled = true;
        Debug.Log("selected: " + selectedCharacter);
    }

    public void PreviousCharacter()
    {
        for (int i = 0; i < characters.Length; i++){
            characters[selectedCharacter].Disable();
        }
        characterImages[selectedCharacter].enabled = false;
        selectedCharacter--;
        if (selectedCharacter < 0){
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].ResetState();
        characterImages[selectedCharacter].enabled = true;
        Debug.Log("selected: " + selectedCharacter);
    }

    public void OnNextPointerEnter()
    {
        nextButton.GetComponentInChildren<Text>().fontSize = 110;
    }

    public void OnNextPointerExit()
    {
        nextButton.GetComponentInChildren<Text>().fontSize = 90;
    }

    public void OnPrevPointerEnter()
    {
        prevButton.GetComponentInChildren<Text>().fontSize = 110;
    }

    public void OnPrevPointerExit()
    {
        prevButton.GetComponentInChildren<Text>().fontSize = 90;
    }

}

