using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Ghost : MonoBehaviour
{
    public Movement movement { get; private set; }
    public GhostHome home { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened frightened { get; private set; }
    public GhostBehavior initialBehavior;
    public Transform[] targets;
    public CharacterSelection selected;
    public int selectedTarget = 0;
    public int points = 200;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.home = GetComponent<GhostHome>();
        this.scatter = GetComponent<GhostScatter>();
        this.chase = GetComponent<GhostChase>();
        this.frightened = GetComponent<GhostFrightened>();
    }

    private void Start()
    {
        ResetState();
    }
    private void Update(){
        // Making sure that the ghost target the correct main character.
        this.selectedTarget = selected.selectedCharacter;
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();

        this.frightened.Disable();
        this.chase.Disable();
        this.scatter.Enable();
        
        if (this.home != this.initialBehavior) {
            this.home.Disable();
        }
        if (this.initialBehavior != null) {
            this.initialBehavior.Enable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("MainCharacter"))
        {
            if (this.frightened.enabled) {
                FindObjectOfType<GameManager>().GhostEaten(this);
            } else {
                FindObjectOfType<GameManager>().MainCharacterEaten();
                //FindObjectOfType<LifeCount>().LoseLife();
            }
        }
    }


}
