using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersMovement : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float disappearX = 6.0f; // Adjust this value for the destination where the character disappears
    public float scaleSpeed = 0.3f; // Adjust the scale change speed
    public float minScale = 0.8f; // Minimum scale before stopping

    private bool movingRight = true;

    void Update()
    {
        MoveCharacter();
        ScaleCharacter();

        if (transform.position.x >= disappearX)
        {
            // If the character has reached the destination, make it disappear
            Destroy(gameObject);
        }
    }

    public void ExecuteCharacterMovement()
    {
        // Place the actions you want to occur when the button is clicked here.
        Debug.Log("Button clicked - Executing Character Movement!");
        // For example, you can change the character's direction when the button is clicked.
        movingRight = !movingRight;
    }

    private void MoveCharacter()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    private void ScaleCharacter()
    {
        if (transform.localScale.x > minScale)
        {
            Vector3 newScale = transform.localScale - new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
            transform.localScale = newScale;
        }
    }
}