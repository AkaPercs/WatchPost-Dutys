using UnityEngine;

public class HexMoving : MonoBehaviour
{
    public float moveSpeed = 2.5f; // Adjust the speed as needed
    private bool isMoving = false;
    private float moveDuration = 5f; // Set the duration for movement in seconds
    private float timer = 0f;

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
        timer += Time.deltaTime;

        if (timer < moveDuration)
        {
            GameObject[] characters = GameObject.FindGameObjectsWithTag("Turret");

            foreach (GameObject character in characters)
            {
                character.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            // Movement duration reached, stop moving
            isMoving = false;
        }
    }
}
