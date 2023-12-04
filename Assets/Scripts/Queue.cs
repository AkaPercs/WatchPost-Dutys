using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueSystem : MonoBehaviour
{
    public Transform spawnPoint; // Set this in the Unity editor to your spawn point
    public GameObject characterPrefab; // Set this in the Unity editor to your character prefab
    public int maxQueueSize = 5; // Adjust the maximum queue size as needed
    public float backgroundSpawnOffset = -1.0f; // Adjust this offset to spawn characters in the background
    public float spawnDelay = 2.0f; // Adjust the delay in seconds

    private Queue<GameObject> characterQueue = new Queue<GameObject>();
    private int characterCounter = 1; // Counter for unique character names

    void Start()
    {
        // Assuming you have a button GameObject with a Button component attached
        Button yourUIButton = FindObjectOfType<Button>();

        // Attach a method to the button's onClick event
        yourUIButton.onClick.AddListener(SpawnCharacter);
    }

    void Update()
    {
        if (Input.GetKeyDown("o") || Input.GetKeyDown(KeyCode.O))
        {
            SpawnCharacter();
        }
    }

    void SpawnCharacter()
    {
        InvokeRepeating("SpawnCharacterDelayed", 0f, spawnDelay);
    }

    void SpawnCharacterDelayed()
    {
        if (characterQueue.Count < maxQueueSize)
        {
            GameObject newCharacter = Instantiate(characterPrefab, CalculateSpawnPosition(), Quaternion.identity);
            newCharacter.name = "Character" + characterCounter; // Set a unique name for each character
            characterCounter++;

            characterQueue.Enqueue(newCharacter);
            UpdateQueuePositions();
        }
        else
        {
            Debug.Log("Queue is full. Cannot spawn more characters.");
            CancelInvoke("SpawnCharacterDelayed"); // Stop repeating if the queue is full
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
        // Calculate the spawn position based on the spawn point's position with a background offset on the Z-axis
        return spawnPoint.position + new Vector3(0f, 0f, backgroundSpawnOffset);
    }
}
