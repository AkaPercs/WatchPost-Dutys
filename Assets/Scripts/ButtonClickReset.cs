using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    private Button button;

    void Start()
    {
        // Get the Button component attached to the GameObject
        button = GetComponent<Button>();

        // Attach the custom method to the button click event
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // Your custom logic when the button is clicked

        // Immediately reset the button to its normal state
        ResetButtonState();
    }

    void ResetButtonState()
    {
        // You may need to reset the button's appearance or behavior here
        // For example, you can change the button's color, disable interactions, etc.

        // Example: Resetting the color to the normal state
        ColorBlock colors = button.colors;
        colors.normalColor = new Color(1f, 1f, 1f, 1f);  // Adjust the color as needed
        button.colors = colors;

        // Example: Disabling interactions for a short time (optional)
        button.interactable = false;
        Invoke("EnableButtonInteractivity", 0.1f);  // Enable interactions after a short delay
    }

    void EnableButtonInteractivity()
    {
        // Enable button interactions
        button.interactable = true;
    }
}
