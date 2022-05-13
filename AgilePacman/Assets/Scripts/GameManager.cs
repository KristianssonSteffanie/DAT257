using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public MainCharacter[] characters;
    public int selectedCharacter = 0;
    public CharacterSelection selected;
    public Transform pellets;
    public int ghostMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }
    public GameObject gameOver;
    public GameObject restartButton;
    public NewGame newgame;

    private void Start() 
    {
        
        NewGame();
    }

    private void Update() 
    {
        // Making sure that the selectedCharacter integer is updated after character selection.
        // This prevents the character from changing back to the smurf after each time you die.
        this.selectedCharacter = selected.selectedCharacter;

        if (this.lives <= 0 && Input.anyKeyDown) {
            //NewGame();
            gameOver.SetActive(true);
        if(restartButton.clicked==true)
        NewGame();
        gameOver.SetActive(false);


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
            Invoke(nameof(NewRound), 3.0f);
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

}
