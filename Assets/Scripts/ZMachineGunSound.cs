using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundScript : MonoBehaviour
{
    public AudioClip machineGunSE; // Rename to match your audio clip
    private AudioSource audioSource;
    public float delayTime = 1.0f; // Set your desired delay time in seconds
    public Button yourButton; // Reference to your UI button

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = machineGunSE; // Set the audio clip

        // Make sure to attach the method to the button click event
        yourButton.onClick.AddListener(PlayDelayedSound);
    }

    private void PlayDelayedSound()
    {
        audioSource.PlayDelayed(delayTime);
    }
}
