using UnityEngine;

public class MoveRightCharacters : MonoBehaviour
{
    public float moveSpeed = 2.5f; // Adjust the speed as needed
    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            MoveCharactersRight();
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
}