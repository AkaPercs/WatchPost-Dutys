using System.Collections;
using System.Collections.Generic; // Add this line for the generic Queue type
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float timeBetweenMoves = 2f;

    private Queue<Character> characterQueue = new Queue<Character>();
    private int currentSpawnIndex = 0;

    void Start()
    {
        // Spawn initial characters
        SpawnCharacter();
    }

    void SpawnCharacter()
    {
        // Check if there are more spawn points
        if (currentSpawnIndex < spawnPoints.Length)
        {
            // Spawn a new character at the next spawn point
            GameObject characterObject = new GameObject("Character");
            characterObject.transform.position = spawnPoints[currentSpawnIndex].position;

            // Attach the Character script to the character object
            Character character = characterObject.AddComponent<Character>();
            characterQueue.Enqueue(character);

            // Increment the spawn index for the next character
            currentSpawnIndex++;

            // Start moving the characters in sequence
            StartCoroutine(MoveCharacters());
        }
        else
        {
            Debug.Log("All characters spawned.");
        }
    }

    IEnumerator MoveCharacters()
    {
        while (characterQueue.Count > 0)
        {
            Character currentCharacter = characterQueue.Dequeue();
            currentCharacter.isMoving = true;

            yield return new WaitForSeconds(timeBetweenMoves);

            currentCharacter.isMoving = false;

            // Spawn the next character in line
            SpawnCharacter();
        }
    }
}
