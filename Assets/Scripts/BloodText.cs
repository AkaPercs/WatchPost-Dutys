using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MoveTextOnClick : MonoBehaviour
{
    public Text uiText;
    private (string text, int number)[] fixedTexts = {
        ("Checking for foreign microorganisms", 1),
        ("Checking for toxic elements", 2),
        ("Observing irregularities in DNA", 3)
    };
    private string[][] possibleEndings = {
        new string[] { "Foreign microorganisms detected!", "No foreign microorganisms detected.", "Error. No data" },
        new string[] { "Unknown substances in blood stream!", "Elevated white blood cell count has been detected.", "No toxic elements detected." },
        new string[] { "No irregularities in DNA detected.", "Emergency! Alterations to DNA has been detected, eliminate immediately!" }
    };

    private RectTransform uiTextRect;

    public float appearanceDelay = 1f;
    public float disappearanceDelay = 3f;

    private void Start()
    {
        if (uiText == null)
        {
            Debug.LogError("UI Text component not assigned!");
            return;
        }

        uiTextRect = uiText.GetComponent<RectTransform>();

        // Make the text initially invisible
        uiText.enabled = false;

        // Set the initial text
        UpdateText();
    }

    private void UpdateText()
    {
        string finalText = "";

        // Loop through each fixed text
        for (int i = 0; i < fixedTexts.Length; i++)
        {
            int randomEndingIndex = Random.Range(0, possibleEndings[i].Length);
            string randomFixedText = fixedTexts[i].text;
            int fixedTextNumber = fixedTexts[i].number;
            string randomEnding = possibleEndings[i][randomEndingIndex];

            // Combine the fixed and random parts with the number
            finalText += $"[{fixedTextNumber}] {randomFixedText}... {randomEnding}\n\n"; // Adjusted formatting
        }

        // Set the text of the UI Text component
        uiText.text = finalText;
    }

    public void OnButtonClick()
    {
        StartCoroutine(ShowAndHideText());
    }

    private IEnumerator ShowAndHideText()
    {
        // Commented out the lines related to moving the UI Text
        // Vector2 newPosition = uiTextRect.anchoredPosition + new Vector2(10f, 0f);
        // uiTextRect.anchoredPosition = newPosition;

        // Show the text
        uiText.enabled = true;

        // Wait for the specified delay
        yield return new WaitForSeconds(appearanceDelay);

        // Hide the text after the delay
        uiText.enabled = false;

        // Set the initial text for the next iteration
        UpdateText();
    }
}
