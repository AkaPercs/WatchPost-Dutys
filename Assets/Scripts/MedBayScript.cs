using UnityEngine;

public class MoveCharacters : MonoBehaviour
{
    public float moveSpeed = 4f; // Adjust the speed as needed
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

        // Schedule the destruction of objects after 5 seconds
        Invoke("DestroyObjects", 5f);
    }

    void MoveCharactersLeft()
    {
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");

        foreach (GameObject character in characters)
        {
            character.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    void DestroyObjects()
    {
        // Find all objects with the "Character" tag and destroy them
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");

        foreach (GameObject character in characters)
        {
            Destroy(character);
        }
    }
}
