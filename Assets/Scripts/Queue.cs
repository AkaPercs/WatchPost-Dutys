using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Array of different character prefabs
    public Button medbayButton; // Reference to the UI button for the medbay
    public KeyCode spawnKey = KeyCode.Space; // Key to spawn the character

    private int currentCharacterIndex = 0; // Index to track the current character
    private bool isCharacterSpawned = false; // Flag to check if a character is already spawned

    private GameObject currentCharacter; // Reference to the currently spawned character

    private void Start()
    {
        // Subscribe to the button click event
        medbayButton.onClick.AddListener(SpawnNextCharacter);
    }

    void Update()
    {
        // Check for the space bar press
        if (Input.GetKeyDown(spawnKey))
        {
            SpawnNextCharacter();
        }
    }

    // Method to spawn the next character
    void SpawnNextCharacter()
    {
        // If a character is already spawned, and it's not destroyed, do not spawn the next one
        if (currentCharacter != null && currentCharacter.activeSelf)
        {
            return;
        }

        // If a character is already spawned, destroy it before spawning the next one
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }

        if (currentCharacterIndex < characterPrefabs.Length)
        {
            GameObject characterPrefab = characterPrefabs[currentCharacterIndex];
            currentCharacter = Instantiate(characterPrefab, transform.position, Quaternion.identity);

            // You can customize the spawn position and rotation as needed
            currentCharacter.transform.position = transform.position;
            currentCharacter.transform.rotation = Quaternion.identity;

            // Increment the character index for the next spawn
            currentCharacterIndex++;

            // Set the flag to indicate that a character is spawned
            isCharacterSpawned = true;

            // Reset the movement script
            MoveCharacters moveScript = FindObjectOfType<MoveCharacters>();
            if (moveScript != null)
            {
                moveScript.ResetMovement();
            }
        }
    }
}