using UnityEngine;

public class GhostChase : GhostBehavior
{
    private void OnDisable()
    {
        this.ghost.scatter.Enable();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        // check that node is not null, enabled and the ghost not frightened
        if (node != null && this.enabled && !this.ghost.frightened.enabled) {

            Vector2 direction = Vector2.zero; // set direction to 0
            float minDistance = float.MaxValue; // check largest possible value to get shortest path to target

            // loop through all directions
            foreach (Vector2 availableDirection in node.availableDirections) {

                // new position, IF moving in that dir
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);
                float distance = (this.ghost.targets[this.ghost.selectedTarget].position - newPosition).sqrMagnitude; // count the distance

                // if distance is less then minDist, change direction and minDist=distance
                if (distance < minDistance) {
                    direction = availableDirection;
                    minDistance = distance;
                }
            }
            this.ghost.movement.SetDirection(direction);
        }
    }

}
