using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Load the "Hallway Music" audio clip from the Resources folder
        AudioClip hallwayMusic = Resources.Load<AudioClip>("Hallway Music");

        // Check if the audio clip is loaded successfully
        if (hallwayMusic != null)
        {
            // Assign the loaded audio clip to the AudioSource
            audioSource.clip = hallwayMusic;

            // Play the audio
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Audio clip 'Hallway Music' not found in Resources folder!");
        }
    }
}
