using UnityEngine;

public class GhostFrightened : GhostBehavior
{
    public SpriteRenderer body;
    public SpriteRenderer blue;
    public SpriteRenderer white;
    public bool eaten { get; private set; }

    public override void Enable(float duration)
    {
        base.Enable(duration);

        // change the body of ghost
        this.body.enabled = false;
        this.blue.enabled = true;
        this.white.enabled = false;

        Invoke(nameof(Flash), duration / 2.0f);

    }

    public override void Disable()
    {
        base.Disable();

        // change the body of ghost
        this.body.enabled = true;
        this.blue.enabled = false;
        this.white.enabled = false;
    }

    // Switch between white and blue
    private void Flash()
    {
        if (!this.eaten) {
            this.blue.enabled = false;
            this.white.enabled = true;
            this.white.GetComponent<AnimatedSprite>().Restart();
        }
    }

    private void Eaten()
    {
        this.eaten = true;
        
        // Update position to home
        Vector3 position = this.ghost.home.inside.position;
        position.z = this.ghost.home.inside.position.z;
        this.ghost.transform.position = position;

        // we are now home
        this.ghost.home.Enable(this.duration);
        this.body.enabled = false;
        this.blue.enabled = true; // usually its the eyes but we donot have eyes like the og
        this.white.enabled = false;
    }

    private void OnEnable()
    {
        this.blue.GetComponent<AnimatedSprite>().Restart();
        this.ghost.movement.speedMultiplier = 0.5f;
        this.eaten = false;
    }

    private void OnDisable()
    {
        this.ghost.movement.speedMultiplier = 1.0f;
        this.eaten = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("MainCharacter"))
        {
            if (this.enabled) {
                Eaten();
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        // check that node is not null, enabled
        if (node != null && this.enabled) {

            Vector2 direction = Vector2.zero; // set direction to 0
            float maxDistance = float.MinValue; // check min path to home

            // loop through all directions
            foreach (Vector2 availableDirection in node.availableDirections) {

                // new position, IF moving in that dir
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);
                float distance = (this.ghost.target.position - newPosition).sqrMagnitude; // count the distance

                // if distance is less then minDist, change direction and minDist=distance
                if (distance > maxDistance) {
                    direction = availableDirection;
                    maxDistance = distance;
                }
            }
            this.ghost.movement.SetDirection(direction);
        }
    }

}
