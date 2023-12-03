using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSystem : MonoBehaviour
{
    public Transform spawnPoint; // Set this in the Unity editor to your spawn point
    public GameObject characterPrefab; // Set this in the Unity editor to your character prefab
    public int maxQueueSize = 5; // Adjust the maximum queue size as needed

    private Queue<GameObject> characterQueue = new Queue<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCharacter();
        }
    }

    void SpawnCharacter()
    {
        if (characterQueue.Count < maxQueueSize)
        {
            GameObject newCharacter = Instantiate(characterPrefab, CalculateSpawnPosition(), Quaternion.identity);
            characterQueue.Enqueue(newCharacter);
            UpdateQueuePositions();
        }
        else
        {
            Debug.Log("Queue is full. Cannot spawn more characters.");
        }
    }

    void UpdateQueuePositions()
    {
        int index = 0;
        foreach (GameObject character in characterQueue)
        {
            if (character != null) // Ensure the character still exists
            {
                Vector3 newPosition = CalculateSpawnPosition() + new Vector3(index * 2f, 0f, 0f);
                character.transform.position = newPosition;
                index++;
            }
        }
    }

    Vector3 CalculateSpawnPosition()
    {
        // Calculate the spawn position based on the spawn point's position
        return spawnPoint.position + new Vector3(characterQueue.Count * 2f, 0f, 0f);
    }
}
