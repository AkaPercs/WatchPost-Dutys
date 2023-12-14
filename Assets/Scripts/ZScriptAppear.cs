using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleTextVisibility : MonoBehaviour
{
    public Text hiddenText;

    void Start()
    {
        if (hiddenText == null)
        {
            Debug.LogError("Text component not assigned!");
            return;
        }

        // Make the text initially invisible
        hiddenText.text = "";
    }

    public void ToggleVisibility()
    {
        // Toggle the visibility of the text
        if (hiddenText.text == "")
        {
            hiddenText.text = "Your Text Here"; // Set the text you want to display
            StartCoroutine(HideTextAfterDelay());
        }
        else
        {
            hiddenText.text = "";
        }
    }

    IEnumerator HideTextAfterDelay()
    {
        // Wait for a certain duration before hiding the text again
        yield return new WaitForSeconds(3f); // Adjust the duration as needed

        // Ensure the text is still supposed to be visible before hiding it again
        if (hiddenText.text != "")
        {
            hiddenText.text = "";
        }
    }
}
