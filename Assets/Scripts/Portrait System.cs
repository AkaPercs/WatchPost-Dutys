using UnityEngine;

public class PortraitSystem : MonoBehaviour
{
    // Reference to the parent GameObject where the character portraits will be instantiated
    public Transform portraitParent;

    // Array of character prefabs. Add your character prefab objects here.
    public GameObject[] characterPrefabs;

    // Index to keep track of the current character
    private int currentCharacterIndex = 0;

    // Reference to the current character instance
    private GameObject currentCharacterInstance;

    private void Start()
    {
        // Instantiate the initial character portrait
        UpdatePortrait();
    }

    private void Update()
    {
        // Check for the "P" key press
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Check if the current character instance exists before destroying it
            if (currentCharacterInstance != null)
            {
                Destroy(currentCharacterInstance);
            }

            // Increment the character index
            currentCharacterIndex++;

            // If the index goes beyond the array length, loop back to the first character
            if (currentCharacterIndex >= characterPrefabs.Length)
            {
                currentCharacterIndex = 0;
            }

            // Instantiate the new character portrait
            UpdatePortrait();
        }
    }

    // Function to update the displayed character portrait
    private void UpdatePortrait()
    {
        // Check if the portraitParent reference is set
        if (portraitParent != null)
        {
            // Instantiate the prefab and set it as the current character instance
            currentCharacterInstance = Instantiate(characterPrefabs[currentCharacterIndex], portraitParent);
        }
        else
        {
            // Log an error if the portraitParent reference is not set
            Debug.LogError("PortraitParent reference not set!");
        }
    }
}