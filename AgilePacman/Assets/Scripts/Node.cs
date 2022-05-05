using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask obsticleLayer;
    public List<Vector2> availableDirections { get; private set; }
    
    // create list of all available directions when started
    private void Start()
    {
        this.availableDirections = new List<Vector2>();

        // Possible directions
        CheckAvailableDirection(Vector2.up);
        CheckAvailableDirection(Vector2.down);
        CheckAvailableDirection(Vector2.left);
        CheckAvailableDirection(Vector2.right);
    }

    // check if therese a wall nearby
    private void CheckAvailableDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.5f, 0.0f, direction, 1.1f, this.obsticleLayer);
        
        if (hit.collider == null) {
            this.availableDirections.Add(direction);
        }
    }
}
