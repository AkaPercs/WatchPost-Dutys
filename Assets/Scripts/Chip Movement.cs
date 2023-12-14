using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Adjust the movement speed
    public float rightDistance = 2.4f; // Adjust the distance to move right
    public float downDistance = 1.8f; // Adjust the distance to move down
    public float opacityChangeSpeed = 1.5f; // Adjust the speed of opacity change

    private bool moveRight = true;
    private bool moveDown = false;
    private Vector3 initialPosition;
    private Renderer objectRenderer;
    private Color objectColor;

    void Start()
    {
        initialPosition = transform.position;
        objectRenderer = GetComponent<Renderer>();
        objectColor = objectRenderer.material.color;
        objectColor.a = 0; // Start with 0 opacity
        objectRenderer.material.color = objectColor;
    }

    void Update()
    {
        if (moveRight)
        {
            // Move to the right
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= initialPosition.x + rightDistance)
            {
                // When the object reaches the desired right position, stop moving right.
                moveRight = false;
                moveDown = true;
            }
        }
        else if (moveDown)
        {
            // Move downward
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            if (transform.position.y <= initialPosition.y - downDistance)
            {
                // When the object reaches the desired down position, stop moving down.
                moveDown = false;
            }
        }

        // Increase opacity gradually
        if (objectColor.a < 1.0f)
        {
            objectColor.a += opacityChangeSpeed * Time.deltaTime;
            objectRenderer.material.color = objectColor;
        }
    }
}