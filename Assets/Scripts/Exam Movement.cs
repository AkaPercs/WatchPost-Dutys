using UnityEngine;

public class MoveRightCharacters : MonoBehaviour
{
    public float moveSpeed = 4f; // Adjust the speed as needed
    public float destroyAfterSeconds = 3f; // Set the duration after which characters should be destroyed
    private bool isMoving = false;
    private float timer = 0f;

    void Update()
    {
        if (isMoving)
        {
            MoveCharactersRight();
            UpdateTimer();
        }
    }

    // Function called when the button is clicked
    public void StartMovingCharacters()
    {
        isMoving = true;
    }

    void MoveCharactersRight()
    {
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");

        foreach (GameObject character in characters)
        {
            character.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
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

    // Function called to stop or reset the movement
    void ResetMovement()
    {
        isMoving = false;
        timer = 0f;
    }
}
