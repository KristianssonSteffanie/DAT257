using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterSelection : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject prevButton;
    public MainCharacter[] characters;
    public int selectedCharacter = 0;

    public void NextCharacter()
    {
        Debug.Log("next character..");
        characters[selectedCharacter].Disable();
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].ResetState();
        Debug.Log(characters[selectedCharacter]);
    }

    public void PreviousCharacter()
    {
        Debug.Log("previous character..");
        characters[selectedCharacter].Disable();
        selectedCharacter--;
        if (selectedCharacter < 0){
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].ResetState();
        Debug.Log(characters[selectedCharacter]);
    }

    public void OnNextPointerEnter()
    {
        nextButton.GetComponentInChildren<Text>().fontSize = 100;
    }

    public void OnNextPointerExit()
    {
        nextButton.GetComponentInChildren<Text>().fontSize = 90;
    }

    public void OnPrevPointerEnter()
    {
        prevButton.GetComponentInChildren<Text>().fontSize = 100;
    }

    public void OnPrevPointerExit()
    {
        prevButton.GetComponentInChildren<Text>().fontSize = 90;
    }

}

