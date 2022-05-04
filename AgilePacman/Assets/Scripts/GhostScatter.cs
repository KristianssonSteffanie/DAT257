using UnityEngine;

public class GhostScatter : GhostBehavior
{

    private void OnDisable()
    {
        this.ghost.chase.Enable();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        // check that node is not null, enabled and the ghost not frightened
        if (node != null && this.enabled && !this.ghost.frightened.enabled) {
            // pick a random direction
            int index = Random.Range(0, node.availableDirections.Count);
            
            // don't backtrack (hit wall always goes the opposite way, if not the only way)
            if (node.availableDirections[index] == -this.ghost.movement.direction && node.availableDirections.Count > 1) {
                index++;
                
                // if index is last, restart at 0
                if (index >= node.availableDirections.Count) {
                    index = 0;
                }
            }
            this.ghost.movement.SetDirection(node.availableDirections[index]);
        }
    }
}
