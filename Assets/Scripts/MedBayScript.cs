using UnityEngine;

public class MoveCharacters : MonoBehaviour
{
    public float moveSpeed = 2.5f; // Adjust the speed as needed
    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            MoveCharactersLeft();
        }
    }

    // Function called when the button is clicked
    public void StartMovingCharacters()
    {
        isMoving = true;
    }

    void MoveCharactersLeft()
    {
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");

        foreach (GameObject character in characters)
        {
            character.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
}

