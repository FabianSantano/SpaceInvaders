using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowMovement : MonoBehaviour
{
    public float speed = .5f; // Horizontal movement speed
    public float horizontalDistance = 2f; // Horizontal distance the row moves
    public float verticalDistance = 0.5f; // Vertical distance the row moves down
    private int timesToMoveRight = 3; // Number of times to move right before moving down
    public int moveCount = 0; // Counter for horizontal movements
    private bool moveRight = true; // Flag to indicate direction of movement
    public GameMangerScript gm;

    void Update()
    {
        
        if (gm.killed == 4)
        {
            speed = speed + .5f;
            gm.killed = 0;
            
        }
        // Move the row horizontally
        transform.Translate(Vector3.right * speed * Time.deltaTime * (moveRight ? 1 : -1));

        // Check if the row has moved far enough horizontally
        if (Mathf.Abs(transform.position.x) >= horizontalDistance)
        {
            // Reset horizontal movement
            transform.Translate(Vector3.right * -speed * Time.deltaTime * (moveRight ? 1 : -1)); // Move back

            // Increment move count
            moveCount++;

            // Change direction
            moveRight = !moveRight;

            // Check if it's time to move down
            if (moveCount >= timesToMoveRight)
            {
                // Move down
                transform.Translate(Vector3.down * verticalDistance);

                // Reset move count
                moveCount = 0;
                gm.hasFiredShot = false;
            }
            
        }
        
    }
}
