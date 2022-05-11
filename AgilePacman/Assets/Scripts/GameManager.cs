using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public MainCharacter[] characters;
    public int selectedCharacter = 0;

    // public MainCharacter mainCharacter;
    public Transform pellets;
    public int ghostMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }

    private void Start() 
    {
        NewGame();
    }

    private void Update() 
    {
        if (this.lives <= 0 && Input.anyKeyDown) {
            NewGame();
        }
        
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

// loop through all pellets and turn them back on
    private void NewRound()
    {
        // loop through every child of pellets-form
        foreach (Transform pellet in this.pellets) {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

// reset the state of main character and ghosts when main character dies
    private void ResetState() 
    {
        ResetGhostMultiplier();

        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].ResetState();
        }
        for (int i = 0; i < this.characters.Length; i++) {
            if(i != selectedCharacter){
                this.characters[i].Disable();
            }
        }

        this.characters[selectedCharacter].ResetState();

    }

    private void GameOver()
    {
        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].gameObject.SetActive(false);
        }

        this.characters[selectedCharacter].gameObject.SetActive(false);

    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    public int GetScore()
    {
        return this.score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void GhostEaten(Ghost ghost)
    {
        int points = ghost.points * this.ghostMultiplier;
        SetScore(this.score + points);
        this.ghostMultiplier++;
    }

    public void MainCharacterEaten()
    {
        this.characters[selectedCharacter].gameObject.SetActive(false);


        SetLives(this.lives - 1);

        if (this.lives > 0) {
            Invoke(nameof(ResetState),3.0f);
        } else {
            GameOver();
        }
    }

    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);

        SetScore(this.score + pellet.points);

        if (!HasRemaningPellets())
        {
            this.characters[selectedCharacter].gameObject.SetActive(false);
            //Invoke(nameof(NewRound), 3.0f);
            NextLevel();
        }
    }

    public void PowerPellet(PowerPellet pellet)
    {
        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].frightened.Enable(pellet.duration);
        }

        PelletEaten(pellet);
        CancelInvoke();
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);

    }

    private bool HasRemaningPellets()
    {
        foreach (Transform pellet in this.pellets)
        {
            if(pellet.gameObject.activeSelf){
                return true;
            }        
        }
        return false;
    }

    private void ResetGhostMultiplier()
    {
        this.ghostMultiplier = 1;
    }


    private void NextLevel()
    {
        // check if current level done then go to loadingscreen
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("FirstLevel")) {
         SceneManager.LoadScene ("BewteenLevels");
        }
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("SecondLevel")) {
         SceneManager.LoadScene ("BewteenLevels");
        }
    }

}
