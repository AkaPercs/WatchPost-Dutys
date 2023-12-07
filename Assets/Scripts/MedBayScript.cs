using UnityEngine;

public class MoveCharacters : MonoBehaviour
{
    public float moveSpeed = 4f; // Adjust the speed as needed
    public float destroyAfterSeconds = 3f; // Set the duration after which characters should be destroyed
    private bool isMoving = false;
    private float timer = 0f;

    void Update()
    {
        if (isMoving)
        {
            MoveCharactersLeft();
            UpdateTimer();
        }
    }

    // Function called to start moving characters
    public void StartMovingCharacters()
    {
        isMoving = true;
    }

    // Function called to stop or reset the movement
    public void ResetMovement()
    {
        isMoving = false;

        // Additional reset logic if needed
        timer = 0f;
    }

    void MoveCharactersLeft()
    {
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");

        foreach (GameObject character in characters)
        {
            character.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    void UpdateTimer()
    {
        timer += Time.deltaTime;

        // Check if the timer has exceeded the specified duration
        if (timer >= destroyAfterSeconds)
        {
            DestroyCharacters();
        }
    }

    void DestroyCharacters()
    {
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");

        foreach (GameObject character in characters)
        {
            Destroy(character);
        }

        // Optionally, reset variables for reuse
        ResetMovement();
    }
}
