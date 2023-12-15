using UnityEngine;

public class CharacterDestroyer : MonoBehaviour
{
    // Reference to the CharacterSpawner script
    private CharacterSpawner characterSpawner;

    public float delayInSeconds = 2f; // Adjust this value to set the delay

    private void Start()
    {
        // Find and store a reference to the CharacterSpawner script
        characterSpawner = FindObjectOfType<CharacterSpawner>();

        if (characterSpawner == null)
        {
            Debug.LogError("CharacterSpawner script not found in the scene.");
        }
    }

    // Example: Call this function to destroy the character with a delay
    public void DestroyCharacterByFunction()
    {
        // Use Invoke to call DestroyCurrentCharacter after a specified delay
        Invoke("DestroyCurrentCharacter", delayInSeconds);
    }

    // Function to destroy the current character using the CharacterSpawner script
    void DestroyCurrentCharacter()
    {
        if (characterSpawner != null)
        {
            // Call the DestroyCharacter function from the CharacterSpawner script
            characterSpawner.DestroyCharacter();
        }
        else
        {
            Debug.LogError("CharacterSpawner reference is null. Make sure the CharacterDestroyer is in the same scene as CharacterSpawner.");
        }
    }
}
