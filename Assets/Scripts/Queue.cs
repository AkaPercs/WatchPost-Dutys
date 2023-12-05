using System.Collections;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Array of different character prefabs

    private int currentCharacterIndex = 0; // Index to track the current character
    private bool isCharacterSpawned = false; // Flag to check if a character is already spawned

    // Start is called before the first frame update
    void Start()
    {
        // You can remove this if you don't want to automatically start spawning characters
        StartCoroutine(SpawnNextCharacterAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        // Check for space bar press and make sure a character is not already spawned
        if (Input.GetKeyDown(KeyCode.Space) && !isCharacterSpawned)
        {
            SpawnNextCharacter();
        }
    }

    // Method to spawn the next character
    void SpawnNextCharacter()
    {
        if (currentCharacterIndex < characterPrefabs.Length)
        {
            GameObject characterPrefab = characterPrefabs[currentCharacterIndex];
            GameObject character = Instantiate(characterPrefab, transform.position, Quaternion.identity);

            // You can customize the spawn position and rotation as needed
            character.transform.position = transform.position;
            character.transform.rotation = Quaternion.identity;

            // Increment the character index for the next spawn
            currentCharacterIndex++;

            // Set the flag to indicate that a character is spawned
            isCharacterSpawned = true;

            // Start a coroutine to reset the flag after a delay (optional)
            StartCoroutine(ResetSpawnFlag());
        }
    }

    // Coroutine to reset the character spawn flag after a delay (optional)
    IEnumerator ResetSpawnFlag()
    {
        yield return new WaitForSeconds(2.0f);
        isCharacterSpawned = false;
    }

    // Coroutine to spawn the next character after a delay (optional)
    IEnumerator SpawnNextCharacterAfterDelay()
    {
        yield return new WaitForSeconds(2.0f);
        SpawnNextCharacter();
    }
}
